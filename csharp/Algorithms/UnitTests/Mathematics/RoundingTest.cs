using System;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;
using RiskAndPricingSolutions.Algorithms.Mathematics.Rounding;

namespace RiskAndPricingSolutions.Algorithms.UnitTests.Mathematics
{
    [TestFixture]
    public class RoundingTest
    {
        [TestCase(12.0,13.0,4.0)]
        [TestCase(3.5, 3.4449, 0.25)]
        public void TestRoundingNearest(double expected, double x, double nearest)
        {
            IRounding rounding = new Rounding();
            Assert.AreEqual(expected,rounding.RoundNearest(x,nearest));
        }

        [TestCase(12.0, 13.0, 4.0)]
        [TestCase(3.25, 3.4449, 0.25)]
        public void TestRoundingDown(double expected, double x, double nearest)
        {
            IRounding rounding = new Rounding();
            Assert.AreEqual(expected, rounding.RoundDown(x, nearest));
        }

        [TestCase(16.0, 13.0, 4.0)]
        [TestCase(3.5, 3.4449, 0.25)]
        public void TestRoundingUp(double expected, double x, double nearest)
        {
            IRounding rounding = new Rounding();
            Assert.AreEqual(expected, rounding.RoundUp(x, nearest));
        }
    }
}