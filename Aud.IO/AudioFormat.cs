using System;

namespace Aud.IO
{
    public abstract class AudioFormat
    {
        public string Fileextension;

        public AudioFormat(string filePath) { }

        /// <summary>
        /// Returns the audio data in analog.
        /// </summary>
        /// <returns></returns>
        public abstract double[] GetDemodulatedAudio();
    }
}
