using System;using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RiskAndPricingSolutions.Algorithms.DataStructures.PriorityQueues;

namespace RiskAndPricingSolutions.Algorithms.UnitTests.DataStructures
{
    [TestFixture]
    public class PriorityHeapTest
    {
        [Test]
        public void TestMaxConfig()
        {
            IPriorityQueue<int> pq = new PriorityHeap<int>(50,QueueMode.Max, (i, i1) => i.CompareTo(i1), -1);

            pq.Insert(50);
            pq.Insert(100);
            pq.Insert(25);

            Queue<int> results = new Queue<int>();
            results.Enqueue(pq.Delete());
            results.Enqueue(pq.Delete());
            results.Enqueue(pq.Delete());

            Assert.IsTrue(results.ToArray().SequenceEqual(new int[] {100,50,25}));
        }

        [Test]
        public void TestMinConfig()
        {
            IPriorityQueue<int> pq = new PriorityHeap<int>(50, QueueMode.Min, (i, i1) => i.CompareTo(i1), -1);

            pq.Insert(50);
            pq.Insert(100);
            pq.Insert(25);

            Queue<int> results = new Queue<int>();
            results.Enqueue(pq.Delete());
            results.Enqueue(pq.Delete());
            results.Enqueue(pq.Delete());

            Assert.IsTrue(results.ToArray().SequenceEqual(new int[] { 25, 50, 100 }));
        }
    }
}