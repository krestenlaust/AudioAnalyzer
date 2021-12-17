using MathNet.Numerics;
using System;
using System.Numerics;
using MathNet.Numerics.IntegralTransforms;

namespace AudioAnalyzer.FFTs
{
    public class RobustFFT : IAlgorithmFFT
    {
        public int AdjustWindowSize(int suggestedSize)
        {
            return suggestedSize;
        }

        /// <exception cref="ArgumentNullException"></exception>
        public Complex[] FFT(double[] amplitudes)
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

            // Omdan til Complex array i stedet for Complex32
            Complex[] frequencies = new Complex[fftInput.Length];
            for (int i = 0; i < fftInput.Length; i++)
            {
                frequencies[i] = new Complex(fftInput[i].Real, fftInput[i].Imaginary);
            }

            return frequencies;
        }

        /// <exception cref="ArgumentNullException"></exception>
        public double[] IFFT(Complex[] frequencyBins)
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
            double[] outputAmplitude = new double[inputFrequency.Length];
            for (int i = 0; i < inputFrequency.Length; i++)
            {
                outputAmplitude[i] = inputFrequency[i].Real;
            }

            return outputAmplitude;
        }
    }
}
