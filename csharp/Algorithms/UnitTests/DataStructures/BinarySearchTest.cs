using System;
using NUnit.Framework;
using RiskAndPricingSolutions.Algorithms.DataStructures;

namespace RiskAndPricingSolutions.Algorithms.UnitTests.DataStructures
{
    [TestFixture]
    public class BinarySearchTest
    {
        private readonly IBinarySearch _searcherA = new BinarySearchImpl();

        [Test]
        public void Test()
        {
            var lst = new[] { 2, 4, 6 };
            Assert.Throws<ArgumentNullException>(() => _searcherA.BinarySearch(null, 1));

            Assert.AreEqual(-1, _searcherA.BinarySearch(new int[0], -1));
            Assert.AreEqual(-1, _searcherA.BinarySearch(lst, 1));
            Assert.AreEqual(0, _searcherA.BinarySearch(lst, 2));
            Assert.AreEqual(-2, _searcherA.BinarySearch(lst, 3));
            Assert.AreEqual(1, _searcherA.BinarySearch(lst, 4));
            Assert.AreEqual(-3, _searcherA.BinarySearch(lst, 5));
            Assert.AreEqual(2, _searcherA.BinarySearch(lst, 6));
            Assert.AreEqual(-4, _searcherA.BinarySearch(lst, 7));
        }
    }
}