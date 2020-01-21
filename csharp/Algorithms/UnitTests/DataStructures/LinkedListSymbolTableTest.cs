using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using System.Text;
using RiskAndPricingSolutions.Algorithms.DataStructures.SymbolTable;
using static System.Console;

namespace RiskAndPricingSolutions.Algorithms.UnitTests.DataStructures
{
    [TestFixture]
    public class LinkedListSymbolTableTest
    {
        [Test]
        public void IndexingClientTest()
        {
            SymbolTableTester.IndexingClientTest(_symbolTable);
        }

        [TestCase(10,"tale.txt",2257,4579)]
        [TestCase(8,"tale.txt",5126,14346)]
        [TestCase(1,"tale.txt",10674,135643)]
        public void FrequencyTest(int minLen, String file,long distinct, long total)
        {
             var symbolTable = new LinkedListSymbolTable<string, int>();
             SymbolTableTester.FrequencyTest(symbolTable, minLen, file);

            // Get the total number of values
            var t = symbolTable.KeyValues().Aggregate(0, (i, pair) => i + pair.Value);
            Assert.AreEqual(total,t);
            Assert.AreEqual(distinct,symbolTable.Count);
        }


        private readonly ISymbolTable<String, int> _symbolTable =
            new LinkedListSymbolTable<string, int>();
    }
}