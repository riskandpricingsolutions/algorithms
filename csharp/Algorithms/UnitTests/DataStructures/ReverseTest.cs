using System.Linq;
using NUnit.Framework;
using RiskAndPricingSolutions.Algorithms.DataStructures.Reverse;

namespace RiskAndPricingSolutions.Algorithms.UnitTests.DataStructures
{
    [TestFixture]
    internal class ReverseTest
    {
        private readonly IReverser _reverse = new SimpleReverser();

        [TestCase(new[] {1, 2, 3}, new[] {3, 2, 1})]
        public void TestReverse(int[] ia, int[] oa)
        {
            Assert.IsTrue(_reverse.Reverse(ia).SequenceEqual(oa));
        }

        [TestCase(new[] { 1, 2, 3 }, new[] { 3, 2, 1 })]
        public void TestReverseInPlace(int[] ia, int[] oa)
        {
            _reverse.ReverseInPlace(ia);
            Assert.IsTrue(ia.SequenceEqual(oa));
        }
    }
}