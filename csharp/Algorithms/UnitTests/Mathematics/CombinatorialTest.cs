using System;
using System.Collections.Generic;
using System.Linq;
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
            Assert.AreEqual(exp, _combinatoricCalculator.PermutationsCount(n, r, true));
        }

        [TestCase(3, 2, 6)]
        public void TestPermutationsWithoutRepeating(long n, long r, long exp)
        {
            var result = _combinatoricCalculator.GeneratePermutations(new Char[] {'a', 'b', 'c'}, 2, false);
            Assert.AreEqual(6, result.Count);
        }

        [Test]
        public void TestGetPermutationsWithRepeating()
        {
            var result = _combinatoricCalculator.GeneratePermutations(new Char[] {'a', 'b', 'c'}, 2, true);
            Assert.AreEqual(9, result.Count);
        }

        [Test]
        public void TestNTuples()
        {
            string[][] events =
            {
                new[] {"a", "b"},
                new[] {"i", "ii", "iii"},
                new[] {"1"},
            };

            var result = NTupleGenerator
                .CalculateNTuples(new string[3], events)
                .ToList();

            var expectedResult = new List<string[]>
            {
                new[] {"a", "i", "1"},
                new[] {"b", "i", "1"},
                new[] {"a", "ii", "1"},
                new[] {"b", "ii", "1"},
                new[] {"a", "iii", "1"},
                new[] {"b", "iii", "1"},
            };

            for (int i = 0; i < result.Count; i++)
                Assert.AreEqual(expectedResult[i], result[i]);
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