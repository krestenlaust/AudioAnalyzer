using AudioAnalyzer.FFTs;

namespace AudioAnalyzer
{
    public static class FFTAlgorithms
    {
        public readonly static IAlgorithmFFT RobustFFT;
        public readonly static IAlgorithmFFT HomemadeFFT;

        static FFTAlgorithms()
        {
            RobustFFT = new RobustFFT();
            HomemadeFFT = new HomemadeFFT();
        }
    }
}
