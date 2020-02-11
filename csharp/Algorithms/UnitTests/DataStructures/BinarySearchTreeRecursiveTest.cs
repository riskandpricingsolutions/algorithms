using System;
using System.Linq;
using NUnit.Framework;
using RiskAndPricingSolutions.Algorithms.DataStructures.SymbolTable.BST;
using RiskAndPricingSolutions.Algorithms.DataStructures.SymbolTable.BST.Printing;

namespace RiskAndPricingSolutions.Algorithms.UnitTests.DataStructures
{
    [TestFixture]
    public class BinarySearchTreeTest
    {
        [SetUp]
        public void SetUp()
        {
            _bst = new BinarySearchSearchTreeRecursive<string, int>
            {
                ["D"] = 4,
                ["B"] = 2,
                ["E"] = 5,
                ["A"] = 1,
                ["C"] = 3
            };
        }

        [TestCase(50, 50)]
        [TestCase(100, 60)]
        [TestCase(150, 140)]
        public void TestCeiling(int expectedCeiling, int key)
        {
            var bst = new BinarySearchSearchTreeRecursive<int, int>();
            var inputs = new[] { 100, 50, 150 };
            foreach (var input in inputs) bst[input] = input;
            Assert.AreEqual(expectedCeiling, bst.Ceiling(key));
        }

        [Test]
        public void TestDelete()
        {
            var bst = new BinarySearchSearchTreeRecursive<int, int>();
            var inputs = new[] { 100, 50, 150 };
            foreach (var input in inputs) bst[input] = input;
            _treePrinter.PrintTree(bst);
           bst.Delete(100);
           _treePrinter.PrintTree(bst);
        }

        [TestCase(100, 100)]
        [TestCase(50, 50)]
        [TestCase(150, 150)]
        [TestCase(160, 150)]
        [TestCase(110, 100)]
        [TestCase(60, 50)]
        public void FloorTest(int key, int expected)
        {
            var bst = new BinarySearchSearchTreeRecursive<int, int>();
            var inputs = new[] { 100, 50, 150 };
            foreach (var input in inputs) bst[input] = input;
            Assert.AreEqual(expected, bst.Floor(key));
        }

        [Test]
        public void MinTest()
        {
            var bst = new BinarySearchSearchTreeRecursive<int, int>();
            var inputs = new[] { 100, 50, 150 };
            foreach (var input in inputs) bst[input] = input;
            Assert.AreEqual(50, bst.MinKey);
        }

        [Test]
        public void MaxTest()
        {
            var bst = new BinarySearchSearchTreeRecursive<int, int>();
            var inputs = new[] { 100, 50, 150 };
            foreach (var input in inputs) bst[input] = input;
            Assert.AreEqual(150, bst.MaxKey);
        }

        [TestCase(40, 0)]
        [TestCase(50, 0)]
        [TestCase(90, 1)]
        [TestCase(100, 1)]
        [TestCase(150, 2)]
        [TestCase(140, 2)]
        public void RankTest(int key, int expected)
        {
            var bst = new BinarySearchSearchTreeRecursive<int, int>();
            var inputs = new[] { 100, 50, 150 };
            foreach (var input in inputs) bst[input] = input;
            Assert.AreEqual(expected, bst.Rank(key));
        }

        [TestCase(0, 50)]
        [TestCase(1, 100)]
        [TestCase(2, 150)]
        public void SelectTest(int k, int expected)
        {
            var bst = new BinarySearchSearchTreeRecursive<int, int>();
            var inputs = new[] {100, 50, 150};
            foreach (var input in inputs) bst[input] = input;
            Assert.AreEqual(expected, bst.Select(k));
        }

        [Test]
        public void DeleteMinTest()
        {
            var bst = new BinarySearchSearchTreeRecursive<int, int>();
            var inputs = new[] {100, 50, 150};
            foreach (var input in inputs) bst[input] = input;
            bst.DeleteMin();
            Assert.IsTrue(new[] {100, 150}.SequenceEqual(bst.InOrderTraversal().Select(pair => pair.Key)));
        }

        [TestCase(100, 100)]
        [TestCase(50, 50)]
        [TestCase(150, 150)]
        [TestCase(140, 150)]
        [TestCase(90, 100)]
        [TestCase(40, 50)]
        public void CeilingTest(int key, int expected)
        {
            var bst = new BinarySearchSearchTreeRecursive<int, int>();
            var inputs = new[] {100, 50, 150};
            foreach (var input in inputs) bst[input] = input;
            Assert.AreEqual(expected, bst.Ceiling(key));
        }

        [Test]
        public void PostOrderTraversalTest()
        {
            var seq = _bst.PostOrderTraversal().Select(node => node.Key).ToArray();
            Assert.IsTrue(new string[] {"A", "C", "B", "E", "D"}.SequenceEqual(seq));
        }

        [Test]
        public void PreOrderTraversalTest()
        {
            var seq = _bst.PreOrderTraversal().Select(node => node.Key).ToArray();
            Assert.IsTrue(new string[] {"D", "B", "A", "C", "E"}.SequenceEqual(seq));
        }

        [Test]
        public void InOrderTraversalTest()
        {
            var seq = _bst.InOrderTraversal().Select(node => node.Key).ToArray();
            Assert.IsTrue(new string[] {"A", "B", "C", "D", "E"}.SequenceEqual(seq));
        }

        [TestCase("E", 5)]
        public void GetTest(String key, int expected)
        {
            Assert.AreEqual(expected, _bst[key]);
        }

        //[TestCase(new string[0], 0)]
        //[TestCase(new string[] { "D" }, 1)]
        //[TestCase(new string[] { "D", "B" }, 2)]
        [TestCase(new string[] {"D", "B", "E"}, 3)]
        public void SizeTest(string[] keys, int expectedCount)
        {
            var bst = new BinarySearchSearchTreeRecursive<String, int>();
            int i = 1;
            foreach (var key in keys) bst[key] = i++;
            Assert.AreEqual(expectedCount, bst.Count);

            //BinaryTreeNicePrint.nicePrint(bst.Root);
        }

        [Test]
        public void SimpleTrace()
        {
            var bst = new BinarySearchSearchTreeRecursive<string, int>();
            var enumerable = "S E A R C H E X A M P L E".Split();
            for (var i = 0; i < enumerable.Length; i++)
                bst[enumerable[i]] = i;
        }

        private IBinarySearchTree<String, int> _bst;
        private readonly ITreePrinter _treePrinter = new BinarySearchTreePrinter();
    }
}