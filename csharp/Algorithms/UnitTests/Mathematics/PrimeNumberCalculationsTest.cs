using System.Linq;
using NUnit.Framework;
using RiskAndPricingSolutions.Algorithms.Mathematics.PrimeNumbers;

namespace RiskAndPricingSolutions.Algorithms.UnitTests.Mathematics
{
    [TestFixture]
    public class PrimeNumberCalculationsCalculatorTest
    {
        [Test]
        public void TestIsPrime()
        {
            Assert.AreEqual(false, _primeCalc.IsPrime(1));
            Assert.AreEqual(true, _primeCalc.IsPrime(2));
            Assert.AreEqual(true, _primeCalc.IsPrime(3));
            Assert.AreEqual(false, _primeCalc.IsPrime(4));
            Assert.AreEqual(true, _primeCalc.IsPrime(5));
            Assert.AreEqual(false, _primeCalc.IsPrime(6));
            Assert.AreEqual(true, _primeCalc.IsPrime(7));
        }

        [Test]
        public void TestPrimesLessThanX()
        {
            Assert.AreEqual(2, _primeCalc.PrimesLessThanX(4));
            Assert.AreEqual(3, _primeCalc.PrimesLessThanX(6));
            Assert.AreEqual(5, _primeCalc.PrimesLessThanX(12));
        }

        [Test]
        public void TestPrimesBetween()
        {
            Assert.AreEqual(3, _primeCalc.PrimesBetween(0, 5));
            Assert.AreEqual(5, _primeCalc.PrimesBetween(0, 11));
            Assert.AreEqual(5, _primeCalc.PrimesBetween(10, 25));
        }

        [Test]
        public void TestFirstNPrimes()
        {
            Assert.IsTrue(_primeCalc.FirstNPrimes(1).SequenceEqual(new[] { 2 }));
            Assert.IsTrue(_primeCalc.FirstNPrimes(2).SequenceEqual(new[] { 2, 3 }));
            Assert.IsTrue(_primeCalc.FirstNPrimes(3).SequenceEqual(new[] { 2, 3, 5 }));
        }

        private readonly IPrimeNumberCalculations _primeCalc = new PrimeNumberCalculationsImpl();
    }
}
