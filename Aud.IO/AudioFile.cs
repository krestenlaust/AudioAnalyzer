namespace Aud.IO
{
    public abstract class AudioFile
    {
        /// <summary>
        /// Audio duration in seconds.
        /// </summary>
        public abstract double AudioDuration { get; }
        /// <summary>
        /// The rate at which the audio is sampled.
        /// </summary>
        public abstract uint SampleRate { get; }
        /// <summary>
        /// The amount of bits that store a single sample.
        /// </summary>
        public abstract uint BitsPerSample { get; }

        public AudioFile(string filePath) { }

        public abstract void WriteAudioFile(string filePath);

        /// <summary>
        /// Returns the audio data in analog (demodulated from LPCM).
        /// </summary>
        /// <returns></returns>
        public abstract double[] GetDemodulatedAudio();

        /// <summary>
        /// Set audio by audio data not modulated using LPCM.
        /// </summary>
        /// <param name="audio"></param>
        public abstract void SetDemodulatedAudio(double[] audio);
    }
}
