using NUnit.Framework;
using RiskAndPricingSolutions.Algorithms.DataStructures.Lists;
using RiskAndPricingSolutions.Algorithms.DataStructures.Lists.ArrayList;


namespace RiskAndPricingSolutions.Algorithms.UnitTests.SinglyLinkedList
{
    [TestFixture]
    public class ArrayListTest
    {
        private readonly IArrayList<int> _list = new ArrayList<int>(2);

        [Test]
        public void Test()
        {
            _list.Add(4);
            _list.Add(5);
            _list.Add(6);
        }
    }
}