using System;
using System.Numerics;
using Aud.IO.Algorithms;

namespace AudioAnalyzer.FFTs
{
    public class HomemadeFFT : IAlgorithmFFT
    {
        /// <exception cref="ArgumentNullException"></exception>
        public Complex[] FFT(double[] amplitudes)
        {
            if (amplitudes is null)
            {
                throw new ArgumentNullException(nameof(amplitudes));
            }

            // Den ændrer ikke på input array, så den kan bare returnere direkte.
            return CooleyTukey.Forward(amplitudes);
        }

        /// <exception cref="ArgumentNullException"></exception>
        public double[] IFFT(Complex[] frequencyBins)
        {
            if (frequencyBins is null)
            {
                throw new ArgumentNullException(nameof(frequencyBins));
            }

            return CooleyTukey.Backward(frequencyBins);
        }
    }
}
