using MathNet.Numerics;

namespace AudioAnalyzer
{
    public interface IAlgorithmFFT
    {
        Complex32[] FFT(float[] amplitudes);
        float[] IFFT(Complex32[] frequencyBins);
        int AdjustWindowSize(int suggestedSize);
    }
}
