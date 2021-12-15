using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AudioAnalyzer
{
    public class ChartSelectionHelper
    {
        /// <summary>
        /// Hvor få pixels en markering skal være,
        /// for at blive registreret som en *deselection*.
        /// </summary>
        private const int DeselectionThreshhold = 10;

        private readonly Chart chart;
        /// <summary>
        /// Markørens position da et tryk *blev startet* (onmousedown).
        /// Er null, når det første tryk fandt sted før 0 på x-aksen.
        /// </summary>
        private int? startPixelX;
        private VerticalLineAnnotation rangeLine1, rangeLine2;

        public bool Selected => SelectionLength > 0;
        public double SelectionStart { get; private set; }
        public double SelectionLength { get; private set; }

        private int maxXDrag => chart.Width - 1;

        /// <summary>
        /// Bliver kaldt hver gang musen bevæger sig og er i gang med at markere.
        /// </summary>
        public event Action OnUpdatedSelection;
        /// <summary>
        /// Bliver kaldt når museknappen slippes og markeringen er fuldført.
        /// </summary>
        public event Action OnFinishedSelection;
        /// <summary>
        /// Bliver kaldt når markeringen er fjernet.
        /// </summary>
        public event Action OnDeselection;

        public ChartSelectionHelper(Chart chart)
        {
            this.chart = chart;

            rangeLine1 = new VerticalLineAnnotation
            {
                IsInfinitive = true,
                LineColor = Color.Red
            };
            chart.Annotations.Add(rangeLine1);
            rangeLine2 = new VerticalLineAnnotation
            {
                IsInfinitive = true,
                LineColor = Color.Red
            };
            chart.Annotations.Add(rangeLine2);

            chart.MouseDown += (sender, e) => ChartMouseDown(e);
            chart.MouseUp += (sender, e) => ChartMouseUp(e);
            chart.MouseMove += (sender, e) => ChartMouseMove(e);
        }

        public void Deselect()
        {
            rangeLine1.Visible = false;
            rangeLine2.Visible = false;
            SelectionLength = 0;

            OnDeselection?.Invoke();
        }

        private void ChartMouseDown(MouseEventArgs e)
        {
            // Håndter kun venstre klik
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            Deselect();

            /*
            Axis ax = chart.ChartAreas[0].AxisX;
            double positionX = ax.PixelPositionToValue(e.Location.X);

            if (positionX < 0)
            {
                startPixelX = null;
            }
            else
            {
                startPixelX = e.Location.X;
            }*/
        }

        private void ChartMouseUp(MouseEventArgs e)
        {
            if (chart.Series[0].Points.Count == 0)
            {
                return;
            }

            if (startPixelX is null || Math.Abs(startPixelX.Value - e.Location.X) <= DeselectionThreshhold)
            {
                Deselect();
                return;
            }

            // Håndter kun venstre klik
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            startPixelX = null;
            OnFinishedSelection?.Invoke();
        }

        private void ChartMouseMove(MouseEventArgs e)
        {
            // Hvis grafen er tom er der ikke noget at lave
            if (chart.Series[0].Points.Count == 0)
            {
                return;
            }

            // Håndter kun venstre klik
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            Axis ax = chart.ChartAreas[0].AxisX;

            int newPixelX = e.Location.X;
            
            // Trækker udenfor grafen, ignorer indtil de er indenfor.
            if (newPixelX < 0)
            {
                newPixelX = 0;
            }
            else if (newPixelX > maxXDrag)
            {
                newPixelX = maxXDrag;
            }

            // Første event kald hvor der markeres.
            if (startPixelX is null)
            {
                rangeLine1.Visible = true;
                rangeLine2.Visible = true;

                startPixelX = newPixelX;
            }

            double rangeStartX = ax.PixelPositionToValue(Math.Min(startPixelX.Value, newPixelX));
            double rangeEndX = ax.PixelPositionToValue(Math.Max(startPixelX.Value, newPixelX));
            SelectionStart = rangeStartX;
            SelectionLength = rangeEndX - rangeStartX;
            OnUpdatedSelection?.Invoke();

            rangeLine1.AnchorX = (int)((float)startPixelX.Value / chart.Width * 100);
            rangeLine2.AnchorX = (int)((float)newPixelX / chart.Width * 100);

            chart.UpdateAnnotations();
        }
    }
}
