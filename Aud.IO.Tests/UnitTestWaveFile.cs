using Aud.IO.Formats;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aud.IO.Tests
{
    [TestClass]
    public class UnitTestWaveFile
    {
        [TestMethod]
        [DeploymentItem(@"lydfil\440 frekvens 441 samplerate sinus ny.wav")]
        public void TestWaveFileHeader()
        {
            WaveFile audioFile = null;
            try
            {
                audioFile = new WaveFile(@"lydfil\440 frekvens 441 samplerate sinus ny.wav");
            }
            catch (System.Exception)
            {
                Assert.Fail();
            }

            WaveStructure data = audioFile.GetWaveData();

            // Har samplerate på 44100
            Assert.AreEqual<uint>(44100, audioFile.SampleRate);
            // Der er 88200 samples i filen.
            Assert.AreEqual<int>(88200, audioFile.Samples);
            // Mono
            Assert.AreEqual<ushort>(1, data.Subchunk1.NumChannels);
            // 16 bits per sample.
            Assert.AreEqual<ushort>(16, data.Subchunk1.BitsPerSample);
        }
    }
}
