using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RiskAndPricingSolutions.Algorithms.Mathematics.Combinatorics;
using static System.Console;

namespace RiskAndPricingSolutions.Algorithms.UnitTests.Mathematics
{
    [TestFixture]
    public class CombinatoricsTest
    {
        private readonly IPossibilityGenerator _combinatoricCalculator = new PossibilityGenerator();

        [TestCase(3, 2, 9)]
        public void TestPermutationsWithRepeating(long n, long r, long exp)
        {
            Assert.AreEqual(exp, _combinatoricCalculator.NTupleCount(n, r));
        }

        [TestCase(3, 2, 6)]
        public void TestPermutationsWithoutRepeating(long n, long r, long exp)
        {
            var result = _combinatoricCalculator.GeneratePermutations(new Char[] {'1', '2', '3','4'});
            foreach (var c in result) WriteLine(c.Aggregate("",(c1, c2) => $"{c1} {c2}"));
        }

        [Test]
        public void TestGetPermutationsWithRepeating()
        {
            var result = _combinatoricCalculator.GenerateNTuples(new Char[] {'a', 'b', 'c'});
            Assert.AreEqual(27, result.Count());
        }

        [Test]
        public void TestNumberCombination()
        {
            var result = NTupleGenerator
                .CalculateNumberCombinations(3, 2)
                .ToList();

            Assert.AreEqual(8,result.Count);
        }
    }
}