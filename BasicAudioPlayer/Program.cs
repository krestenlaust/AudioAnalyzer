using System;
using System.Collections.Generic;
using System.Threading;

namespace BasicAudioPlayer
{
    class Program
    {
        private readonly struct Tone
        {
            public readonly int Frequency;
            public readonly int Duration;
            public readonly int TimeOffset;

            public Tone(int frequency, int duration, int timeOffset)
            {
                Frequency = frequency;
                Duration = duration;
                TimeOffset = timeOffset;
            }
        }

        static void Main(string[] args)
        {
            List<Tone> tones = new List<Tone>();
            //tones.Add(new Tone(440, 500, 0));
            //tones.Add(new Tone(250, 500, 0));
            int offset1 = 0, frequency1 = 440, duration1 = 500;
            int offset2 = 250, frequency2 = 250, duration2 = 500;

            int duration = 1000;
            int sampleRate = 100;
            for (int i = 0; i < duration / sampleRate; i++)
            {
                if (i * sampleRate >= offset1 && i * sampleRate < offset1 + duration1)
                {
                    tones.Add(new Tone(frequency1, sampleRate, i * sampleRate));
                }
                if (i * sampleRate >= offset2 && i * sampleRate < offset2 + duration2)
                {
                    tones.Add(new Tone(frequency2, sampleRate, i * sampleRate));
                }
            }

            var manuelResetEventSlim = new ManualResetEventSlim();

            foreach (var tone in tones)
            {
                var thread = new Thread((tone) => {
                    manuelResetEventSlim.Wait();
                    ToneBeep((Tone)tone);
                    Console.WriteLine($"Playing tone: {((Tone)tone).Frequency} Hz {((Tone)tone).TimeOffset}");
                });

                thread.Start(tone);
            }

            Console.WriteLine("Tryk på en knap for at afspille lyd");
            Console.ReadKey();

            manuelResetEventSlim.Set();
            Thread.Sleep(1000);
        }

        static void ToneBeep(Tone tone)
        {
            Thread.Sleep(tone.TimeOffset);
            Console.Beep(tone.Frequency, tone.Duration);
        }
    }
}
