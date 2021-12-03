using System;
using System.Text;
using Aud.IO;

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

            WaveFile audioFile = new WaveFile(args[0]);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Chunk ID: {audioFile.WaveData.ChunkID}");
            sb.AppendLine($"Chunk størrelse: {audioFile.WaveData.ChunkSize}");
            sb.AppendLine($"Format: {audioFile.WaveData.Format}");
            sb.AppendLine("===");
            sb.AppendLine($"Subchunk ID: {audioFile.WaveData.Subchunk1.SubchunkID}");
            sb.AppendLine($"Størrelse: {audioFile.WaveData.Subchunk1.SubchunkSize}");
            sb.AppendLine($"Lyd format: {audioFile.WaveData.Subchunk1.AudioFormat}");
            sb.AppendLine($"Antal lydkanaler (mono/stereo): {audioFile.WaveData.Subchunk1.NumChannels}");
            sb.AppendLine();
            sb.AppendLine($"Indsamlingsfrekvens: {audioFile.WaveData.Subchunk1.SampleRate} Hz");
            sb.AppendLine($"Data punkt størrelse: {audioFile.WaveData.Subchunk1.BitsPerSample}");
            sb.AppendLine($"Blockalign, data punkt størrelse: {audioFile.WaveData.Subchunk1.BlockAlign}");
            sb.AppendLine($"Bytes i sekundet(?): {audioFile.WaveData.Subchunk1.ByteRate}");
            sb.AppendLine("---");
            sb.AppendLine($"Subchunk ID: {audioFile.WaveData.Subchunk2.SubchunkID}");
            sb.AppendLine($"Størrelse: {audioFile.WaveData.Subchunk2.SubchunkSize}");

            Console.WriteLine(sb.ToString());
        }
    }
}
