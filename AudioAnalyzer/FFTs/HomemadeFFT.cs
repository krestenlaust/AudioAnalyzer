using System;
using MathNet.Numerics;
using AudioAnalyzer.Algorithms;

namespace AudioAnalyzer.FFTs
{
    public class HomemadeFFT : IAlgorithmFFT
    {
        /// <summary>
        /// Runder et heltal ned til nærmeste tal som går op i 2^n.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static int CeilPower2(int x)
        {
            if (x < 1)
            {
                return 1;
            }

            double result = Math.Pow(2, Math.Ceiling(Math.Log(x, 2)));

            return (int)Math.Round(result);
        }

        /// <summary>
        /// Forstør vinduesstørrelsen så den opfølger de krav Cooley-Tukey har.
        /// </summary>
        /// <param name="currentSize"></param>
        /// <returns></returns>
        public int AdjustWindowSize(int currentSize)
        {
            return CeilPower2(currentSize);
        }

        /// <exception cref="ArgumentNullException"></exception>
        public Complex32[] FFT(float[] amplitudes)
        {
            if (amplitudes is null)
            {
                throw new ArgumentNullException(nameof(amplitudes));
            }

            // Den ændrer ikke på input array, så den kan bare returnere direkte.
            return CooleyTukey.Forward(amplitudes);
        }

        /// <exception cref="ArgumentNullException"></exception>
        public float[] IFFT(Complex32[] frequencyBins)
        {
            if (frequencyBins is null)
            {
                throw new ArgumentNullException(nameof(frequencyBins));
            }

            return CooleyTukey.Backward(frequencyBins);
        }
    }
}
