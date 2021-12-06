using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Aud.IO.Exceptions;

namespace Aud.IO
{
    /// <summary>
    /// En struktur til at gemme data med samme layout som i en WaveFile.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct WaveStructure
    {
        /// <summary>
        /// Magic byte/int, til at identificere filtypen.
        /// Indeholder altid bogstaverne "RIFF".
        /// Hvis filen er skrevet med big-endian, bruger man her "RIFX" i stedet for.
        /// Big-endian ASCII streng.
        /// </summary>
        public readonly uint ChunkID;
        /// <summary>
        /// Den totale størrelse af al data efter dette felt.
        /// </summary>
        public readonly uint ChunkSize;
        /// <summary>
        /// Magic byte/int, til at identificere denne fils under-type.
        /// Indeholder altid ordet "WAVE".
        /// Big-endian ASCII streng.
        /// </summary>
        public readonly uint Format;

        // Format sub-chunk
        public readonly FormatSubchunk Subchunk1;

        // Data sub-chunk
        public readonly DataSubchunk Subchunk2;

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

            uint subchunk1Size = sizeof(ushort) * 4 + sizeof(uint) * 2;
            Subchunk1 = new FormatSubchunk(subchunk1Size, numChannels, sampleRate, bitsPerSample);

            uint subchunk2Size = (uint)data.Length;
            Subchunk2 = new DataSubchunk(subchunk2Size, data);

            ChunkSize = sizeof(uint) + (sizeof(uint) * 2 + subchunk1Size) + (sizeof(uint) * 2 + subchunk2Size);
        }

        public WaveStructure(FormatSubchunk formatSubchunk, DataSubchunk dataSubchunk)
        {
            ChunkID = BitConverter.ToUInt32(Encoding.ASCII.GetBytes("RIFF"), 0);
            Format = BitConverter.ToUInt32(Encoding.ASCII.GetBytes("WAVE"), 0);

            Subchunk1 = formatSubchunk;
            Subchunk2 = dataSubchunk;

            ChunkSize = 4 + 8 + (sizeof(ushort) * 4 + sizeof(uint) * 2) + 8 + (uint)Subchunk2.Data.Length;
        }
    }

    /// <summary>
    /// Beskriver det format lyden er gemt i.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 24)]
    public readonly struct FormatSubchunk
    {
        /// <summary>
        /// Indeholder altid teksten "fmt ".
        /// Big-endian ASCII streng.
        /// </summary>
        [FieldOffset(0)]
        public readonly uint SubchunkID;
        /// <summary>
        /// Ikke helt sikker.
        /// </summary>
        [FieldOffset(4)]
        public readonly uint SubchunkSize;
        /// <summary>
        /// Er altid 1.
        /// </summary>
        [FieldOffset(8)]
        public readonly ushort AudioFormat;
        /// <summary>
        /// Mono = 1, stereo = 2.
        /// </summary>
        [FieldOffset(10)]
        public readonly ushort NumChannels;
        /// <summary>
        /// Samplerate.
        /// </summary>
        [FieldOffset(12)]
        public readonly uint SampleRate;
        /// <summary>
        /// <c>SampleRate</c> * <c>NumChannels</c> * (<c>BitsPerSample</c> / 8)
        /// </summary>
        [FieldOffset(16)]
        public readonly uint ByteRate;
        /// <summary>
        /// <c>NumChannels</c> * (<c>BitsPerSample</c> / 8)
        /// </summary>
        [FieldOffset(20)]
        public readonly ushort BlockAlign;
        /// <summary>
        /// Størrelsen på ét punkt i opsamlingen.
        /// </summary>
        [FieldOffset(22)]
        public readonly ushort BitsPerSample;
        
        /// <summary>
        /// Udfyld værdier baseret på nødvendig data, udregn resten selv.
        /// </summary>
        /// <param name="subchunkSize"></param>
        /// <param name="numChannels"></param>
        /// <param name="sampleRate"></param>
        /// <param name="bitsPerSample"></param>
        public FormatSubchunk(uint subchunkSize, ushort numChannels, uint sampleRate, ushort bitsPerSample)
        {
            SubchunkID = BitConverter.ToUInt32(Encoding.ASCII.GetBytes("fmt "), 0);
            SubchunkSize = subchunkSize;
            AudioFormat = 1;
            NumChannels = numChannels;
            SampleRate = sampleRate;
            ByteRate = (uint)(sampleRate * numChannels * (bitsPerSample / 8));
            BlockAlign = (ushort)(numChannels * (bitsPerSample / 8));
            BitsPerSample = bitsPerSample;
        }

        public FormatSubchunk(ushort audioFormat, ushort numChannels, uint sampleRate, uint byteRate, ushort blockAlign, ushort bitsPerSample)
        {
            SubchunkID = BitConverter.ToUInt32(Encoding.ASCII.GetBytes("fmt "), 0);
            SubchunkSize = sizeof(ushort) * 4 + sizeof(uint) * 2;

            AudioFormat = audioFormat;
            NumChannels = numChannels;
            SampleRate = sampleRate;
            ByteRate = byteRate;
            BlockAlign = blockAlign;
            BitsPerSample = bitsPerSample;
        }
    }

    /// <summary>
    /// Størrelsen på lyddataen, og lyddataen selv.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public readonly struct DataSubchunk
    {
        /// <summary>
        /// Indeholder teksten "data".
        /// Big-endian ASCII streng.
        /// </summary>
        [FieldOffset(0)]
        public readonly uint SubchunkID;
        /// <summary>
        /// <c>NumSamples</c> * <c>NumChannels</c> * (<c>BitsPerSample</c> / 8)
        /// </summary>
        [FieldOffset(4)]
        public readonly uint SubchunkSize;
        /// <summary>
        /// Selve lyden.
        /// </summary>
        [FieldOffset(8)]
        public readonly byte[] Data;

        public DataSubchunk(uint subchunkSize, byte[] data)
        {
            SubchunkID = BitConverter.ToUInt32(Encoding.ASCII.GetBytes("data"), 0);
            SubchunkSize = subchunkSize;
            Data = data;
        }
    }

    public class WaveFile : AudioFormat
    {
        public WaveStructure WaveData;

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

                        dataSubchunk = new DataSubchunk((uint)dataSubchunkBytes.Length, dataSubchunkBytes);
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
    }
}
