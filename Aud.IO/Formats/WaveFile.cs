using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Aud.IO.Exceptions;

namespace Aud.IO.Formats
{
    public class WaveFile : AudioFormat
    {
        public readonly WaveStructure WaveData;

        /// <summary>
        /// Læser og behandler lydfilen.
        /// </summary>
        /// <param name="filePath"></param>
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

            WaveData = new WaveStructure(formatSubchunk.Value, dataSubchunk.Value);
        }

        /// <inheritdoc/>
        public override double[] GetDemodulatedAudio()
        {
            double[] demodulatedAudio = new double[WaveData.Subchunk2.Data.Length];

            int sampleIndex = 0;
            for (int i = 0; i < WaveData.Subchunk2.Data.Length; i++)
            {
                demodulatedAudio[i] = WaveData.Subchunk2.Data[sampleIndex++] / (double)short.MaxValue;
            }

            return demodulatedAudio;
        }
    }
}
