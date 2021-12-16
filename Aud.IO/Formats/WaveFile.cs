using System;
using System.IO;
using System.Text;
using Aud.IO.Exceptions;

namespace Aud.IO.Formats
{
    public class WaveFile : AudioFile
    {
        /// <inheritdoc/>
        public override uint SampleRate => waveData.Subchunk1.SampleRate;
        /// <inheritdoc/>
        public override uint BitsPerSample => waveData.Subchunk1.BitsPerSample;
        /// <inheritdoc/>
        public override int Samples => waveData.Subchunk2.Data.Length;
        /// <inheritdoc/>
        public override double AudioDuration => (Samples / waveData.Subchunk1.NumChannels) / SampleRate;

        private WaveStructure waveData;

        /// <summary>
        /// Læser og behandler lydfilen.
        /// </summary>
        /// <param name="filePath"></param>
        /// <exception cref="ArgumentNullException">filePath er null.</exception>
        /// <exception cref="FileNotFoundException">Filen blev ikke fundet.</exception>
        /// <exception cref="UnknownFileFormatDescriptorException">Filens chunk ID var ikke 'RIFF'.</exception>
        /// <exception cref="UnknownFileFormatException">Filens format ID var ikke 'WAVE'.</exception>
        /// <exception cref="MissingSubchunkException">Filen indeholder ikke alle de nødvendige subchunks.</exception>
        public WaveFile(string filePath) : base(filePath)
        {
            if (filePath is null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            // Kast exception hvis filen ikke eksisterer.
            FileStream stream = File.OpenRead(filePath);

            // Primary chunk
            byte[] chunkIDBytes = new byte[sizeof(int)];
            stream.Read(chunkIDBytes, 0, chunkIDBytes.Length);
            string chunkID = Encoding.ASCII.GetString(chunkIDBytes);

            if (chunkID != "RIFF")
            {
                throw new UnknownFileFormatDescriptorException($"Was '{chunkID}', expected 'RIFF'");
            }

            byte[] chunkSizeBytes = new byte[sizeof(int)];
            byte[] formatBytes = new byte[sizeof(int)];
            stream.Read(chunkSizeBytes, 0, chunkSizeBytes.Length);
            stream.Read(formatBytes, 0, formatBytes.Length);
            string format = Encoding.ASCII.GetString(formatBytes);

            if (format != "WAVE")
            {
                throw new UnknownFileFormatException($"Was '{format}', expected 'WAVE'");
            }

            FormatSubchunk? formatSubchunk = null;
            DataSubchunk? dataSubchunk = null;

            // Læs subchunks indtil filen er færdig-læst.
            while (stream.Length != stream.Position)
            {
                // Aflæs subchunk ID
                byte[] subchunkIDBytes = new byte[sizeof(int)];
                byte[] subchunkSizeBytes = new byte[sizeof(int)];
                stream.Read(subchunkIDBytes, 0, subchunkIDBytes.Length);
                stream.Read(subchunkSizeBytes, 0, subchunkSizeBytes.Length);

                string subchunkID = Encoding.ASCII.GetString(subchunkIDBytes);
                uint subchunkSize = BitConverter.ToUInt32(subchunkSizeBytes, 0);

                // Behandl subchunk baseret på dens ID.
                switch (subchunkID)
                {
                    case "fmt ":
                        byte[] formatSubchunkBytes = new byte[sizeof(ushort) * 4 + sizeof(uint) * 2];
                        stream.Read(formatSubchunkBytes, 0, formatSubchunkBytes.Length);

                        formatSubchunk = new FormatSubchunk(
                            BitConverter.ToUInt16(formatSubchunkBytes, 0),
                            BitConverter.ToUInt16(formatSubchunkBytes, 2),
                            BitConverter.ToUInt32(formatSubchunkBytes, 4),
                            BitConverter.ToUInt32(formatSubchunkBytes, 8),
                            BitConverter.ToUInt16(formatSubchunkBytes, 12),
                            BitConverter.ToUInt16(formatSubchunkBytes, 14));

                        // Hvis der er ukendte ekstra parametre (ifl. standarden er det muligt)
                        if (formatSubchunkBytes.Length < subchunkSize)
                        {
                            // Spring over dem.
                            stream.Seek(subchunkSize - formatSubchunkBytes.Length, SeekOrigin.Current);
                        }
                        break;
                    case "data":
                        byte[] dataSubchunkBytes = new byte[subchunkSize];
                        stream.Read(dataSubchunkBytes, 0, dataSubchunkBytes.Length);

                        short[] dataSubchunkShort = new short[subchunkSize / 2];
                        Buffer.BlockCopy(dataSubchunkBytes, 0, dataSubchunkShort, 0, dataSubchunkBytes.Length);

                        dataSubchunk = new DataSubchunk(dataSubchunkShort);
                        break;
                    default:
                        // ukendt subchunk, ignorer den.
                        stream.Seek(subchunkSize, SeekOrigin.Current);
                        break;
                }
            }

            if (formatSubchunk is null)
            {
                throw new MissingSubchunkException("fmt ");
            }

            if (dataSubchunk is null)
            {
                throw new MissingSubchunkException("data");
            }

            waveData = new WaveStructure(formatSubchunk.Value, dataSubchunk.Value);
        }

        public WaveStructure GetWaveData() => waveData;

        /// <inheritdoc/>
        public override double[] GetDemodulatedAudio()
        {
            double[] demodulatedAudio = new double[waveData.Subchunk2.Data.Length];

            for (int i = 0; i < waveData.Subchunk2.Data.Length; i++)
            {
                demodulatedAudio[i] = waveData.Subchunk2.Data[i] / (double)short.MaxValue;
            }

            return demodulatedAudio;
        }

        /// <inheritdoc/>
        public override void SetDemodulatedAudio(double[] audio)
        {
            if (audio is null)
            {
                throw new ArgumentNullException(nameof(audio));
            }

            short[] modulatedAudio = new short[audio.Length];

            for (int i = 0; i < audio.Length; i++)
            {
                modulatedAudio[i] = (short)Math.Round(audio[i] * short.MaxValue);
            }

            waveData = new WaveStructure(waveData.Subchunk1.NumChannels, waveData.Subchunk1.SampleRate, waveData.Subchunk1.BitsPerSample, modulatedAudio);
        }

        public override void WriteAudioFile(string filePath)
        {
            if (filePath is null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            using (FileStream fileStream = File.Create(filePath))
            {
                fileStream.Write(BitConverter.GetBytes(waveData.ChunkID), 0, sizeof(uint));
                fileStream.Write(BitConverter.GetBytes(waveData.ChunkSize), 0, sizeof(uint));
                fileStream.Write(BitConverter.GetBytes(waveData.Format), 0, sizeof(uint));

                fileStream.Write(BitConverter.GetBytes(waveData.Subchunk1.ID), 0, sizeof(uint));
                fileStream.Write(BitConverter.GetBytes(waveData.Subchunk1.Size), 0, sizeof(uint));
                fileStream.Write(BitConverter.GetBytes(waveData.Subchunk1.AudioFormat), 0, sizeof(ushort));
                fileStream.Write(BitConverter.GetBytes(waveData.Subchunk1.NumChannels), 0, sizeof(ushort));
                fileStream.Write(BitConverter.GetBytes(waveData.Subchunk1.SampleRate), 0, sizeof(uint));
                fileStream.Write(BitConverter.GetBytes(waveData.Subchunk1.ByteRate), 0, sizeof(uint));
                fileStream.Write(BitConverter.GetBytes(waveData.Subchunk1.BlockAlign), 0, sizeof(ushort));
                fileStream.Write(BitConverter.GetBytes(waveData.Subchunk1.BitsPerSample), 0, sizeof(ushort));

                fileStream.Write(BitConverter.GetBytes(waveData.Subchunk2.ID), 0, sizeof(uint));
                fileStream.Write(BitConverter.GetBytes(waveData.Subchunk2.Size), 0, sizeof(uint));

                byte[] sdata = new byte[waveData.Subchunk2.Size];
                Buffer.BlockCopy(waveData.Subchunk2.Data, 0, sdata, 0, waveData.Subchunk2.Data.Length);
                fileStream.Write(sdata, 0, sdata.Length);

                fileStream.Flush();
            }
        }
    }
}
