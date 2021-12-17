using System.Numerics;

namespace AudioAnalyzer
{
    public interface IAlgorithmFFT
    {
        Complex[] FFT(double[] amplitudes);
        double[] IFFT(Complex[] frequencyBins);
        int AdjustWindowSize(int suggestedSize);
    }
}
