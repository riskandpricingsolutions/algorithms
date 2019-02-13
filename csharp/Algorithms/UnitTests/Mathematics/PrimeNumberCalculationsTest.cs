using System.Linq;
using NUnit.Framework;
using RiskAndPricingSolutions.Algorithms.Mathematics.PrimeNumbers;

namespace RiskAndPricingSolutions.Algorithms.UnitTests.Mathematics
{
    /// <summary>
    /// For reference a list of the  prime numbers less than 100
    ///     2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71,
    ///     73, 79, 83, 89 and 97
    /// </summary>
    [TestFixture]
    public class PrimeNumberCalculationsCalculatorTest
    {
        [TestCase(1,false)]
        [TestCase(2,true)]
        [TestCase(3,true)]
        [TestCase(4,false)]
        [TestCase(5,true)]
        [TestCase(6,false)]
        public void TestIsPrime(int n, bool e)
        {
            Assert.AreEqual(e, _primeCalc.IsPrime(n));
        }

        [TestCase(10,4)]
        [TestCase(100, 25)]
        [TestCase(1000, 168)]
        [TestCase(10000, 1229)]
        [TestCase(100000, 9592)]
        [TestCase(1000000, 78498)]
        //[TestCase(10000000, 664579)]
        public void TestPrimesLessThanOrEqualToX(int x, int n)
        {
            Assert.AreEqual(n, _primeCalc.PrimesLessThanX(x));
        }


   
        [TestCase(0,1,0)]
        [TestCase(0,2,1)]
        [TestCase(0,3,2)]
        [TestCase(2,3,2)]
        [TestCase(2,4,2)]
        [TestCase(3,4,1)]
        [TestCase(5,17,5)]
        [TestCase(4,18,5)]
        public void TestPrimesBetween(int l, int u, int n)
        {
            Assert.AreEqual(n, _primeCalc.PrimesBetween(l, u));
        }

        [TestCase(1, new int[] {2})]
        [TestCase(2, new int[] {2,3})]
        [TestCase(3, new int[] {2,3,5})]
        [TestCase(4, new int[] {2,3,5,7})]
        public void TestFirstNPrimes(int n, int[] e)
        {
            Assert.IsTrue(_primeCalc.FirstNPrimes(n).SequenceEqual(e));
        }

        private readonly IPrimeNumberCalculations _primeCalc = new PrimeNumberCalculationsImpl();
    }
}
