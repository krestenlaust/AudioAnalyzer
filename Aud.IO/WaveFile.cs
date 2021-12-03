using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

#nullable enable
namespace Aud.IO
{
    /// <summary>
    /// En struktur til at gemme data med samme layout som i en WaveFile.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public readonly struct WaveStructure
    {
        /// <summary>
        /// Magic byte/int, til at identificere filtypen.
        /// Indeholder altid bogstaverne "RIFF".
        /// Hvis filen er skrevet med big-endian, bruger man her "RIFX" i stedet for.
        /// Big-endian ASCII streng.
        /// </summary>
        [FieldOffset(0)]
        public readonly uint ChunkID;
        /// <summary>
        /// Den totale størrelse af al data med forskydning større end 8 bytes.
        /// </summary>
        [FieldOffset(4)]
        public readonly uint ChunkSize;
        /// <summary>
        /// Magic byte/int, til at identificere denne fils under-type.
        /// Indeholder altid ordet "WAVE".
        /// Big-endian ASCII streng.
        /// </summary>
        [FieldOffset(8)]
        public readonly uint Format;

        // Format sub-chunk
        /// <summary>
        /// Indeholder altid teksten "fmt ".
        /// Big-endian ASCII streng.
        /// </summary>
        [FieldOffset(12)]
        public readonly uint Subchunk1ID;
        /// <summary>
        /// Ikke helt sikker.
        /// </summary>
        [FieldOffset(16)]
        public readonly uint Subchunk1Size;
        /// <summary>
        /// Er altid 1.
        /// </summary>
        [FieldOffset(20)]
        public readonly ushort AudioFormat;
        /// <summary>
        /// Mono = 1, stereo = 2.
        /// </summary>
        [FieldOffset(22)]
        public readonly ushort NumChannels;
        /// <summary>
        /// Samplerate.
        /// </summary>
        [FieldOffset(24)]
        public readonly uint SampleRate;
        /// <summary>
        /// <c>SampleRate</c> * <c>NumChannels</c> * (<c>BitsPerSample</c> / 8)
        /// </summary>
        [FieldOffset(28)]
        public readonly uint ByteRate;
        /// <summary>
        /// <c>NumChannels</c> * (<c>BitsPerSample</c> / 8)
        /// </summary>
        [FieldOffset(32)]
        public readonly ushort BlockAlign;
        /// <summary>
        /// Størrelsen på ét punkt i opsamlingen.
        /// </summary>
        [FieldOffset(34)]
        public readonly ushort BitsPerSample;

        // Data sub-chunk
        // - Størrelsen på lyden og lyden selv.
        /// <summary>
        /// Indeholder teksten "data".
        /// Big-endian ASCII streng.
        /// </summary>
        [FieldOffset(36)]
        public readonly uint Subchunk2ID;
        /// <summary>
        /// <c>NumSamples</c> * <c>NumChannels</c> * (<c>BitsPerSample</c> / 8)
        /// </summary>
        [FieldOffset(40)]
        public readonly uint Subchunk2Size;
        /// <summary>
        /// Selve lyden.
        /// </summary>
        [FieldOffset(44)]
        public readonly byte[] Data;

        /// <summary>
        /// Opret ny wavefil struktur kun ved hjælp af den data, som der er direkte brug for.
        /// </summary>
        /// <param name="numChannels">The number of channels.</param>
        /// <param name="sampleRate"></param>
        /// <param name="bitsPerSample"></param>
        /// <param name="data"></param>
        public WaveStructure(ushort numChannels, uint sampleRate, ushort bitsPerSample, byte[] data)
        {
            ChunkID = BitConverter.ToUInt32(Encoding.ASCII.GetBytes("RIFF"), 0);
            Format = BitConverter.ToUInt32(Encoding.ASCII.GetBytes("WAVE"), 0);
            Subchunk1ID = BitConverter.ToUInt32(Encoding.ASCII.GetBytes("fmt "), 0);
            AudioFormat = 1;
            NumChannels = numChannels;
            SampleRate = sampleRate;
            ByteRate = (uint)(sampleRate * numChannels * (bitsPerSample / 8));
            BlockAlign = (ushort)(numChannels * (bitsPerSample / 8));
            BitsPerSample = bitsPerSample;
            Subchunk2ID = BitConverter.ToUInt32(Encoding.ASCII.GetBytes("data"), 0);
            Subchunk2Size = (uint)data.Length;

            Subchunk1Size = sizeof(ushort) * 4 + sizeof(uint) * 2;
            ChunkSize = 4 + 8 + Subchunk1Size + 8 + Subchunk2Size;
            Data = data;
        }
    }

    public class UnknownFileFormatDescriptorException : Exception
    {
        public UnknownFileFormatDescriptorException(string message) : base(message) { }
    }

    public class UnknownFileFormatException : Exception
    {
        public UnknownFileFormatException(string message) : base(message) { }
    }

    public class MissingSubchunkException : Exception
    {
        public MissingSubchunkException(string message) : base(message) { }
    }

    public class WaveFile : AudioFormat
    {
        private WaveStructure waveData;

        /// <summary>
        /// Læser og behandler lydfilen.
        /// </summary>
        /// <param name="filePath"></param>
        public WaveFile(string filePath)
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

            // Sub-chunk reading
            while (true)
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
                        break;
                    case "data":
                        break;
                    default:
                        // ukendt subchunk, ignorer den.
                        stream.Seek(subchunkSize, SeekOrigin.Current);
                        break;
                }
            }
        }
    }
}
