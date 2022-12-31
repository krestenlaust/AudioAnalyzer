using System;
using System.Drawing;
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
        private const MouseButtons SelectionButton = MouseButtons.Right;

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

        private int minXDrag => (int)chart.ChartAreas[0].AxisX.ValueToPixelPosition(chart.ChartAreas[0].AxisX.Minimum);
        private int maxXDrag => (int)chart.ChartAreas[0].AxisX.ValueToPixelPosition(chart.ChartAreas[0].AxisX.Maximum); //chart.Width - 1;

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
            if (e.Button != SelectionButton)
            {
                return;
            }

            Deselect();
        }

        private void ChartMouseUp(MouseEventArgs e)
        {
            if (chart.Series[0].Points.Count == 0)
            {
                return;
            }

            // Ingenting er markeret, fjern markeringsstreger.
            if (SelectionLength == 0)
            {
                Deselect();
                return;
            }

            // Mindre end mindste markering, er markeret, fjern markeringsstreger.
            if (startPixelX is null || Math.Abs(startPixelX.Value - e.Location.X) <= DeselectionThreshhold)
            {
                Deselect();
                return;
            }

            // Håndter kun venstre klik
            if (e.Button != SelectionButton)
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

            if (e.Button != SelectionButton)
            {
                return;
            }

            Axis ax = chart.ChartAreas[0].AxisX;

            int newPixelX = e.Location.X;

            // Trækker udenfor grafen, ignorer indtil de er indenfor.
            if (newPixelX < minXDrag)
            {
                newPixelX = minXDrag;
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

            double rangeStartX = Math.Max(0, ax.PixelPositionToValue(Math.Min(startPixelX.Value, newPixelX)));
            double rangeEndX = Math.Max(0, ax.PixelPositionToValue(Math.Max(startPixelX.Value, newPixelX)));
            SelectionStart = rangeStartX;
            SelectionLength = rangeEndX - rangeStartX;
            OnUpdatedSelection?.Invoke();

            rangeLine1.AnchorX = (int)((float)startPixelX.Value / chart.Width * 100);
            rangeLine2.AnchorX = (int)((float)newPixelX / chart.Width * 100);

            chart.UpdateAnnotations();
        }
    }
}
