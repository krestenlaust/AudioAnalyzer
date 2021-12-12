using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Numerics;

namespace Aud.IO.Algorithms.Tests
{
    [TestClass]
    public class FFTTests
    {
        [TestMethod]
        public void TestCooleyTukey()
        {
            double[] amplitudes = new double[] { 0, 1, 2, 3 };
            Complex[] output = CooleyTukey.Forward(amplitudes);
        }
    }
}
