using NUnit.Framework;
using RiskAndPricingSolutions.Algorithms.Mathematics.Fibonacci;

namespace RiskAndPricingSolutions.Algorithms.UnitTests.Mathematics
{
    [TestFixture]
    internal class FibonacciTest
    {
        private readonly IFibonacciCalculator _fibonacciCalculator = new FibonacciCalculator();

        [TestCase(0,0)]
        [TestCase(1,1)]
        [TestCase(2,1)]
        [TestCase(3,2)]
        [TestCase(4,3)]
        [TestCase(5,5)]
        [TestCase(6,8)]
        public void TestFibonacciRecursive(int n, int fibn)
        {
            Assert.AreEqual(fibn,_fibonacciCalculator.FibonacciRecursive(n));
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(4, 3)]
        [TestCase(5, 5)]
        [TestCase(6, 8)]
        public void TestFibonacciIterative(int n, int fibn)
        {
            Assert.AreEqual(fibn, _fibonacciCalculator.FibonacciIterative(n));
        }
    }
}