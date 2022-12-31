using System;
using MathNet.Numerics;
using MathNet.Numerics.IntegralTransforms;

namespace AudioAnalyzer.FFTs
{
    public class RobustFFT : IAlgorithmFFT
    {
        /// <summary>
        /// Denne algoritme har ingen krav til størrelsen af vinduet.
        /// </summary>
        /// <param name="suggestedSize"></param>
        /// <returns></returns>
        public int AdjustWindowSize(int suggestedSize)
        {
            return suggestedSize;
        }

        /// <exception cref="ArgumentNullException"></exception>
        public Complex32[] FFT(float[] amplitudes)
        {
            if (amplitudes is null)
            {
                throw new ArgumentNullException(nameof(amplitudes));
            }

            // double til Complex32 array
            Complex32[] fftInput = new Complex32[amplitudes.Length];
            for (int i = 0; i < fftInput.Length; i++)
            {
                fftInput[i] = new Complex32((float)amplitudes[i], 0);
            }

            Fourier.Forward(fftInput);

            return fftInput;
        }

        /// <exception cref="ArgumentNullException"></exception>
        public float[] IFFT(Complex32[] frequencyBins)
        {
            if (frequencyBins is null)
            {
                throw new ArgumentNullException(nameof(frequencyBins));
            }

            // Complex til Complex32 array
            Complex32[] inputFrequency = new Complex32[frequencyBins.Length];
            for (int i = 0; i < frequencyBins.Length; i++)
            {
                inputFrequency[i] = new Complex32((float)frequencyBins[i].Real, (float)frequencyBins[i].Imaginary);
            }

            // Omformning
            Fourier.Inverse(inputFrequency);

            // Complex32 til double array
            float[] outputAmplitudes = new float[inputFrequency.Length];
            for (int i = 0; i < inputFrequency.Length; i++)
            {
                outputAmplitudes[i] = inputFrequency[i].Real;
            }

            return outputAmplitudes;
        }
    }
}
