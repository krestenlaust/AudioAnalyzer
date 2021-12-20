using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Aud.IO.Formats
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

        /// <summary>
        /// Format sub-chunk.
        /// </summary>
        public readonly FormatSubchunk Subchunk1;

        /// <summary>
        /// Data sub-chunk.
        /// </summary>
        public readonly DataSubchunk Subchunk2;

        /// <summary>
        /// Initializes a new instance of the <see cref="WaveStructure"/> struct.
        /// Opret ny wavefil struktur kun ved hjælp af den data, som der er direkte brug for.
        /// </summary>
        /// <param name="numChannels">Antallet af kanaler, 1 er mono, 2 er stereo.</param>
        /// <param name="sampleRate">Antallet af datapunkter gemt i sekundet.</param>
        /// <param name="bitsPerSample">Antallet af bits gemt per datapunkt.</param>
        /// <param name="data">Moduleret data.</param>
        public WaveStructure(ushort numChannels, uint sampleRate, ushort bitsPerSample, byte[] data)
        {
            ChunkID = BitConverter.ToUInt32(Encoding.ASCII.GetBytes("RIFF"), 0);
            Format = BitConverter.ToUInt32(Encoding.ASCII.GetBytes("WAVE"), 0);

            Subchunk1 = new FormatSubchunk(numChannels, sampleRate, bitsPerSample);
            Subchunk2 = new DataSubchunk(data);

            ChunkSize = sizeof(uint) + (8 + Subchunk1.Size) + (8 + Subchunk2.Size);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WaveStructure"/> struct.
        /// Opret ny wavefil struktur ud fra underblokke.
        /// </summary>
        /// <param name="formatSubchunk">Første underblok.</param>
        /// <param name="dataSubchunk">Anden underblok.</param>
        public WaveStructure(FormatSubchunk formatSubchunk, DataSubchunk dataSubchunk)
        {
            ChunkID = BitConverter.ToUInt32(Encoding.ASCII.GetBytes("RIFF"), 0);
            Format = BitConverter.ToUInt32(Encoding.ASCII.GetBytes("WAVE"), 0);

            Subchunk1 = formatSubchunk;
            Subchunk2 = dataSubchunk;

            ChunkSize = sizeof(uint) + (8 + Subchunk1.Size) + (8 + Subchunk2.Size);
        }

        /// <summary>
        /// Returnerer den samlede størrelse af WaveStruktur.
        /// </summary>
        public uint TotalSize => sizeof(uint) + (8 + Subchunk1.Size) + (8 + Subchunk2.Size);
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
        public readonly uint ID;

        /// <summary>
        /// Størrelse på Format subchunk.
        /// </summary>
        [FieldOffset(4)]
        public readonly uint Size;

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
        /// Initializes a new instance of the <see cref="FormatSubchunk"/> struct.
        /// Udfyld værdier baseret på nødvendig data, udregn resten selv.
        /// </summary>
        /// <param name="numChannels">Antallet af kanaler, 1 er mono, 2 er steoro.</param>
        /// <param name="sampleRate">Antallet af datapunkter gemt i sekundet.</param>
        /// <param name="bitsPerSample">Størrelsen af et datapunkt.</param>
        public FormatSubchunk(ushort numChannels, uint sampleRate, ushort bitsPerSample)
        {
            ID = BitConverter.ToUInt32(Encoding.ASCII.GetBytes("fmt "), 0);
            Size = (sizeof(ushort) * 4) + (sizeof(uint) * 2);
            AudioFormat = 1;
            NumChannels = numChannels;
            SampleRate = sampleRate;
            ByteRate = (uint)(sampleRate * numChannels * (bitsPerSample / 8));
            BlockAlign = (ushort)(numChannels * (bitsPerSample / 8));
            BitsPerSample = bitsPerSample;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormatSubchunk"/> struct.
        /// 
        /// </summary>
        /// <param name="audioFormat">Bør være 1.</param>
        /// <param name="numChannels">Antallet af kanaler, 1 er mono, 2 er steoro.</param>
        /// <param name="sampleRate">Antallet af datapunkter gemt i sekundet.</param>
        /// <param name="byteRate">Antallet af bytes i sekundet.</param>
        /// <param name="blockAlign"></param>
        /// <param name="bitsPerSample">Størrelsen af et datapunkt.</param>
        public FormatSubchunk(ushort audioFormat, ushort numChannels, uint sampleRate, uint byteRate, ushort blockAlign, ushort bitsPerSample)
        {
            ID = BitConverter.ToUInt32(Encoding.ASCII.GetBytes("fmt "), 0);
            Size = (sizeof(ushort) * 4) + (sizeof(uint) * 2);

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
        public readonly uint ID;

        /// <summary>
        /// <c>NumSamples</c> * <c>NumChannels</c> * (<c>BitsPerSample</c> / 8)
        /// </summary>
        [FieldOffset(4)]
        public readonly uint Size;

        /// <summary>
        /// Selve lyden.
        /// </summary>
        [FieldOffset(8)]
        public readonly byte[] Data;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataSubchunk"/> struct.
        /// </summary>
        /// <param name="data">Moduleret lyddata.</param>
        public DataSubchunk(byte[] data)
        {
            ID = BitConverter.ToUInt32(Encoding.ASCII.GetBytes("data"), 0);
            Size = (uint)data.Length;
            Data = data;
        }
    }
}
