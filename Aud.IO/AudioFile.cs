namespace Aud.IO
{
    /// <summary>
    /// An abstract class for implementing audio formats.
    /// </summary>
    public abstract class AudioFile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AudioFile"/> class.
        /// Constructor parameters to enforce design pattern.
        /// </summary>
        /// <param name="filePath">File to load.</param>
        public AudioFile(string filePath) { }

        /// <summary>
        /// Gets audio duration in seconds.
        /// </summary>
        public abstract double AudioDuration { get; }

        /// <summary>
        /// Gets the rate at which the audio is sampled.
        /// </summary>
        public abstract uint SampleRate { get; }

        /// <summary>
        /// Gets the amount of samples, (including all channels).
        /// </summary>
        public abstract int Samples { get; }

        /// <summary>
        /// Gets the amount of bits that store a single sample.
        /// </summary>
        public abstract uint BitsPerSample { get; }

        /// <summary>
        /// Gets the amount of channels, 1 for mono, 2 for stereo.
        /// </summary>
        public abstract ushort ChannelCount { get; }

        public abstract uint ByteRate { get; }

        /// <summary>
        /// Writes the audio file to the specified file path (doesn't add extension).
        /// </summary>
        /// <param name="filePath">The file to load.</param>
        public abstract void WriteAudioFile(string filePath);

        /// <summary>
        /// Returns the audio data in analog (demodulated from LPCM).
        /// </summary>
        /// <returns>LPCM demodulated audio.</returns>
        public abstract float[] GetDemodulatedAudio();

        public abstract byte[] GetModulatedAudio();

        /// <summary>
        /// Sets audio by audio data not modulated using LPCM.
        /// </summary>
        /// <param name="audio">LPCM modulated audio.</param>
        public abstract void SetDemodulatedAudio(float[] audio);
    }
}
