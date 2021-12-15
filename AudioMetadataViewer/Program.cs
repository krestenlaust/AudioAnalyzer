using System;
using System.Collections.Generic;
using System.Text;
using Aud.IO;
using Aud.IO.Formats;

namespace AudioMetadataViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                return;
            }

            //WaveFile audioFile = new WaveFile(args[0]);
            WaveFile audioFile = new WaveFile(@"C:\Users\kress\AppData\Local\Temp\tmpE4AC - Kopi.wav");

            WaveStructure data = audioFile.GetWaveData();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Chunk ID: {Encoding.ASCII.GetString(BitConverter.GetBytes(data.ChunkID))}");
            sb.AppendLine($"Chunk størrelse: {data.ChunkSize}");
            sb.AppendLine($"Format: {data.Format}");
            sb.AppendLine("===");
            sb.AppendLine($"Subchunk ID: {Encoding.ASCII.GetString(BitConverter.GetBytes(data.Subchunk1.ID))}");
            sb.AppendLine($"Størrelse: {data.Subchunk1.Size} bytes");
            sb.AppendLine($"Lyd format: {data.Subchunk1.AudioFormat}");
            sb.AppendLine($"Antal lydkanaler (mono/stereo): {data.Subchunk1.NumChannels}");
            sb.AppendLine();
            sb.AppendLine($"Indsamlingsfrekvens: {data.Subchunk1.SampleRate} Hz");
            sb.AppendLine($"Data punkt størrelse: {data.Subchunk1.BitsPerSample} bits");
            sb.AppendLine($"Blockalign, data punkt størrelse: {data.Subchunk1.BlockAlign}");
            sb.AppendLine($"Bytes i sekundet(?): {data.Subchunk1.ByteRate}");
            sb.AppendLine("---");
            sb.AppendLine($"Subchunk ID: {Encoding.ASCII.GetString(BitConverter.GetBytes(data.Subchunk2.ID))}");
            sb.AppendLine($"Størrelse: {data.Subchunk2.Size} bytes");

            Console.WriteLine(sb.ToString());
        }
    }
}
