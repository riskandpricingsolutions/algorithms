using System;
using System.Linq;
using NUnit.Framework;
using RiskAndPricingSolutions.Algorithms.DataStructures.LinkedList;
using RiskAndPricingSolutions.Algorithms.DataStructures.Lists.SinglyLinkedList;

namespace RiskAndPricingSolutions.Algorithms.UnitTests.SinglyLinkedList
{
    [TestFixture]
    public class SinglyLinkedListTest
    {
        private readonly ILinkedList<int> _list = new LinkedListImpl<int>();

        [Test]
        public void Test()
        {
            Assert.AreEqual(0, _list.Count);
            _list.AddFirst(3);
            Assert.AreEqual(1, _list.Count);
            _list.AddFirst(5);
            Assert.AreEqual(2, _list.Count);
            Assert.IsTrue(new[] { 5, 3 }.SequenceEqual(_list));
            _list.AddLast(7);
            Assert.AreEqual(3, _list.Count);
            Assert.IsTrue(new[] { 5, 3, 7 }.SequenceEqual(_list));
            _list.ToList().ForEach(Console.WriteLine);

            _list.RemoveFirst();
            Assert.IsTrue(new[] { 3, 7 }.SequenceEqual(_list));
            Assert.AreEqual(2, _list.Count);

            _list.AddLast(12);
            _list.AddLast(14);
            Assert.IsTrue(new[] { 3, 7, 12, 14 }.SequenceEqual(_list));
            _list.RemoveLast();
            Assert.IsTrue(new[] { 3, 7, 12 }.SequenceEqual(_list));

            _list.Remove(7);
            var array = _list.ToArray();
        }
    }
}