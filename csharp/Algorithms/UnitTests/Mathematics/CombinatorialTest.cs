using System;
using NUnit.Framework;
using RiskAndPricingSolutions.Algorithms.Mathematics.Combinatorics;

namespace RiskAndPricingSolutions.Algorithms.UnitTests.Mathematics
{
    [TestFixture]
    public class CombinatoricsTest
    {
        private readonly ICombinatoricCalculator _combinatoricCalculator = new CombinatoricCalculator();

        [TestCase(3, 2, 9)]
        public void TestPermutationsWithRepeating(long n, long r, long exp)
        {
            Assert.AreEqual(exp,_combinatoricCalculator.PermutationsCount(n,r,true));
        }

        [TestCase(3, 2, 6)]
        public void TestPermutationsWithoutRepeating(long n, long r, long exp)
        {
            var result = _combinatoricCalculator.GeneratePermutations(new Char[] { 'a', 'b', 'c' }, 2, false);
            Assert.AreEqual(6, result.Count);
        }

        [Test]
        public void TestGetPermutationsWithRepeating()
        {
           var result = _combinatoricCalculator.GeneratePermutations(new Char[] {'a', 'b', 'c'}, 2, true);
           Assert.AreEqual(9,result.Count);
        }
    }
}