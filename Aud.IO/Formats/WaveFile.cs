using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Aud.IO.Exceptions;

namespace Aud.IO.Formats
{
    /// <summary>
    /// Wave fil formatet lavet til at følge standarden.
    /// </summary>
    public class WaveFile : AudioFile
    {
        private WaveStructure waveData;

        /// <summary>
        /// Initializes a new instance of the <see cref="WaveFile"/> class.
        /// Læser og behandler lydfilen synkront.
        /// </summary>
        /// <param name="filePath">Non-null string containing path to wavefile.</param>
        /// <exception cref="ArgumentNullException">filePath er null.</exception>
        /// <exception cref="FileNotFoundException">Filen blev ikke fundet.</exception>
        /// <exception cref="UnknownFileFormatDescriptorException">Filens chunk ID var ikke 'RIFF'.</exception>
        /// <exception cref="UnknownFileFormatException">Filens format ID var ikke 'WAVE'.</exception>
        /// <exception cref="MissingSubchunkException">Filen indeholder ikke alle de nødvendige subchunks.</exception>
        public WaveFile(string filePath)
            : base(filePath)
        {
            if (filePath is null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            // Kast exception hvis filen ikke eksisterer.
            using (FileStream stream = File.OpenRead(filePath))
            {
                // Primary chunk
                byte[] chunkIDBytes = new byte[sizeof(int)];
                stream.Read(chunkIDBytes, 0, chunkIDBytes.Length);
                string chunkID = Encoding.ASCII.GetString(chunkIDBytes);

                if (chunkID != "RIFF")
                {
                    throw new UnknownFileFormatDescriptorException($"Was '{chunkID}', expected 'RIFF'");
                }

                byte[] chunkSizeBytes = new byte[sizeof(uint)];
                stream.Read(chunkSizeBytes, 0, chunkSizeBytes.Length);
                byte[] formatBytes = new byte[sizeof(int)];
                stream.Read(formatBytes, 0, formatBytes.Length);
                string format = Encoding.ASCII.GetString(formatBytes);

                if (format != "WAVE")
                {
                    throw new UnknownFileFormatException($"Was '{format}', expected 'WAVE'");
                }

                FormatSubchunk? formatSubchunk = null;
                DataSubchunk? dataSubchunk = null;

                // Læs subchunks indtil filen er færdig-læst.
                while (stream.Length > stream.Position)
                {
                    // Aflæs subchunk ID
                    byte[] subchunkIDBytes = new byte[sizeof(int)];
                    stream.Read(subchunkIDBytes, 0, subchunkIDBytes.Length);
                    byte[] subchunkSizeBytes = new byte[sizeof(uint)];
                    stream.Read(subchunkSizeBytes, 0, subchunkSizeBytes.Length);

                    string subchunkID = Encoding.ASCII.GetString(subchunkIDBytes);
                    uint subchunkSize = BitConverter.ToUInt32(subchunkSizeBytes, 0);

                    // Behandl subchunk baseret på dens ID.
                    switch (subchunkID)
                    {
                        case "fmt ":
                            // Der kan ifl. standarden være vilkårlige ekstra parametre til sidst, de læses også bare
                            // kun de første 16 bytes bliver brugt alligevel
                            byte[] formatSubchunkBytes = new byte[subchunkSize];
                            stream.Read(formatSubchunkBytes, 0, formatSubchunkBytes.Length);

                            formatSubchunk = new FormatSubchunk(
                                BitConverter.ToUInt16(formatSubchunkBytes, 0),
                                BitConverter.ToUInt16(formatSubchunkBytes, 2),
                                BitConverter.ToUInt32(formatSubchunkBytes, 4),
                                BitConverter.ToUInt32(formatSubchunkBytes, 8),
                                BitConverter.ToUInt16(formatSubchunkBytes, 12),
                                BitConverter.ToUInt16(formatSubchunkBytes, 14));

                            break;
                        case "data":
                            byte[] dataSubchunkBytes = new byte[subchunkSize];
                            stream.Read(dataSubchunkBytes, 0, dataSubchunkBytes.Length);

                            dataSubchunk = new DataSubchunk(dataSubchunkBytes);
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
        }

        public WaveFile(WaveStructure waveData)
            : base(null)
        {
            this.waveData = waveData;
        }

        /// <inheritdoc/>
        public override uint SampleRate => waveData.Subchunk1.SampleRate;

        /// <inheritdoc/>
        public override uint BitsPerSample => waveData.Subchunk1.BitsPerSample;

        /// <inheritdoc/>
        public override int Samples => waveData.Subchunk2.Data.Length / (int)(BitsPerSample / 8);

        /// <inheritdoc/>
        public override double AudioDuration => (Samples / waveData.Subchunk1.NumChannels) / (double)SampleRate;

        /// <inheritdoc/>
        public override ushort ChannelCount => waveData.Subchunk1.NumChannels;

        /// <inheritdoc/>
        public override uint ByteRate => waveData.Subchunk1.ByteRate;

        /// <summary>
        /// Initializes a new instance of the <see cref="WaveFile"/> class.
        /// Læser og behandler lydfilen asynkront.
        /// </summary>
        /// <param name="filePath">Non-null string containing path to wavefile.</param>
        /// <returns>Lydfilen.</returns>
        /// <exception cref="ArgumentNullException">filePath er null.</exception>
        /// <exception cref="FileNotFoundException">Filen blev ikke fundet.</exception>
        /// <exception cref="UnknownFileFormatDescriptorException">Filens chunk ID var ikke 'RIFF'.</exception>
        /// <exception cref="UnknownFileFormatException">Filens format ID var ikke 'WAVE'.</exception>
        /// <exception cref="MissingSubchunkException">Filen indeholder ikke alle de nødvendige subchunks.</exception>
        public static async Task<WaveFile> LoadFileAsync(string filePath)
        {
            if (filePath is null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            // Kast exception hvis filen ikke eksisterer.
            using (FileStream stream = File.OpenRead(filePath))
            {
                // Primary chunk
                byte[] chunkIDBytes = new byte[sizeof(int)];
                await stream.ReadAsync(chunkIDBytes, 0, chunkIDBytes.Length);
                string chunkID = Encoding.ASCII.GetString(chunkIDBytes);

                if (chunkID != "RIFF")
                {
                    throw new UnknownFileFormatDescriptorException($"Was '{chunkID}', expected 'RIFF'");
                }

                byte[] chunkSizeBytes = new byte[sizeof(uint)];
                await stream.ReadAsync(chunkSizeBytes, 0, chunkSizeBytes.Length);
                byte[] formatBytes = new byte[sizeof(int)];
                await stream.ReadAsync(formatBytes, 0, formatBytes.Length);
                string format = Encoding.ASCII.GetString(formatBytes);

                if (format != "WAVE")
                {
                    throw new UnknownFileFormatException($"Was '{format}', expected 'WAVE'");
                }

                FormatSubchunk? formatSubchunk = null;
                DataSubchunk? dataSubchunk = null;

                // Læs subchunks indtil filen er færdig-læst.
                while (stream.Length > stream.Position)
                {
                    // Aflæs subchunk ID
                    byte[] subchunkIDBytes = new byte[sizeof(int)];
                    await stream.ReadAsync(subchunkIDBytes, 0, subchunkIDBytes.Length);
                    byte[] subchunkSizeBytes = new byte[sizeof(uint)];
                    await stream.ReadAsync(subchunkSizeBytes, 0, subchunkSizeBytes.Length);

                    string subchunkID = Encoding.ASCII.GetString(subchunkIDBytes);
                    uint subchunkSize = BitConverter.ToUInt32(subchunkSizeBytes, 0);

                    // Behandl subchunk baseret på dens ID.
                    switch (subchunkID)
                    {
                        case "fmt ":
                            byte[] formatSubchunkBytes = new byte[(sizeof(ushort) * 4) + (sizeof(uint) * 2)];
                            await stream.ReadAsync(formatSubchunkBytes, 0, formatSubchunkBytes.Length);

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
                            await stream.ReadAsync(dataSubchunkBytes, 0, dataSubchunkBytes.Length);

                            dataSubchunk = new DataSubchunk(dataSubchunkBytes);
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

                return new WaveFile(new WaveStructure(formatSubchunk.Value, dataSubchunk.Value));
            }
        }

        /// <summary>
        /// Returnerer den struktur wave-filen er gemt i.
        /// </summary>
        /// <returns>Returnerer værdi-type.</returns>
        public WaveStructure GetWaveData() => waveData;

        /// <inheritdoc/>
        public override float[] GetDemodulatedAudio()
        {
            short[] modulatedAudio = new short[waveData.Subchunk2.Data.Length / (BitsPerSample / 8)];
            Buffer.BlockCopy(waveData.Subchunk2.Data, 0, modulatedAudio, 0, waveData.Subchunk2.Data.Length);

            float[] demodulatedAudio = new float[modulatedAudio.Length];

            // At minus eksponenten med 1 svarer til at dividere med 2.
            float linearScalingFactor = (float)(Math.Pow(2, BitsPerSample - 1) - 1);
            for (int i = 0; i < modulatedAudio.Length; i++)
            {
                demodulatedAudio[i] = modulatedAudio[i] / linearScalingFactor;
            }

            return demodulatedAudio;
        }

        /// <inheritdoc/>
        public override void SetDemodulatedAudio(float[] audio)
        {
            if (audio is null)
            {
                throw new ArgumentNullException(nameof(audio));
            }

            short[] modulatedAudio = new short[audio.Length];

            // At minus eksponenten med 1 svarer til at dividere med 2.
            float linearScalingFactor = (float)(Math.Pow(2, BitsPerSample - 1) - 1);
            for (int i = 0; i < audio.Length; i++)
            {
                modulatedAudio[i] = (short)Math.Round(audio[i] * linearScalingFactor);
            }

            byte[] audioBytes = new byte[modulatedAudio.Length * (BitsPerSample / 8)];
            Buffer.BlockCopy(modulatedAudio, 0, audioBytes, 0, audioBytes.Length);

            waveData = new WaveStructure(waveData.Subchunk1.NumChannels, waveData.Subchunk1.SampleRate, waveData.Subchunk1.BitsPerSample, audioBytes);
        }

        public async Task WriteAudioFileAsync(string filePath)
        {
            if (filePath is null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            using (FileStream fileStream = File.Create(filePath))
            {
                await fileStream.WriteAsync(BitConverter.GetBytes(waveData.ChunkID), 0, sizeof(uint));
                await fileStream.WriteAsync(BitConverter.GetBytes(waveData.ChunkSize), 0, sizeof(uint));
                await fileStream.WriteAsync(BitConverter.GetBytes(waveData.Format), 0, sizeof(uint));

                await fileStream.WriteAsync(BitConverter.GetBytes(waveData.Subchunk1.ID), 0, sizeof(uint));
                await fileStream.WriteAsync(BitConverter.GetBytes(waveData.Subchunk1.Size), 0, sizeof(uint));
                await fileStream.WriteAsync(BitConverter.GetBytes(waveData.Subchunk1.AudioFormat), 0, sizeof(ushort));
                await fileStream.WriteAsync(BitConverter.GetBytes(waveData.Subchunk1.NumChannels), 0, sizeof(ushort));
                await fileStream.WriteAsync(BitConverter.GetBytes(waveData.Subchunk1.SampleRate), 0, sizeof(uint));
                await fileStream.WriteAsync(BitConverter.GetBytes(waveData.Subchunk1.ByteRate), 0, sizeof(uint));
                await fileStream.WriteAsync(BitConverter.GetBytes(waveData.Subchunk1.BlockAlign), 0, sizeof(ushort));
                await fileStream.WriteAsync(BitConverter.GetBytes(waveData.Subchunk1.BitsPerSample), 0, sizeof(ushort));

                await fileStream.WriteAsync(BitConverter.GetBytes(waveData.Subchunk2.ID), 0, sizeof(uint));
                await fileStream.WriteAsync(BitConverter.GetBytes(waveData.Subchunk2.Size), 0, sizeof(uint));

                await fileStream.WriteAsync(waveData.Subchunk2.Data, 0, waveData.Subchunk2.Data.Length);

                await fileStream.FlushAsync();
            }
        }

        /// <inheritdoc/>
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

                fileStream.Write(waveData.Subchunk2.Data, 0, waveData.Subchunk2.Data.Length);

                fileStream.Flush();
            }
        }
    }
}
