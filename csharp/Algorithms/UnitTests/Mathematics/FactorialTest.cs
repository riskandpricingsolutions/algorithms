using NUnit.Framework;
using RiskAndPricingSolutions.Algorithms.Mathematics.Factorial;

namespace RiskAndPricingSolutions.Algorithms.UnitTests.Mathematics
{
    [TestFixture]
    public class FactorialTest
    {
        private IFactorialCalculator factorialCalculator = new FactorialCalculator();

        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 6)]
        [TestCase(4, 24)]
        public void TestFactorialRecursive(int n, int factn)
        {
            Assert.AreEqual(factn, factorialCalculator.FactorialRecursive(n));
        }

        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 6)]
        [TestCase(4, 24)]
        public void TestFactorialIterative(int n, int factn)
        {
            Assert.AreEqual(factn, factorialCalculator.FactorialIterative(n));
        }
    }
}