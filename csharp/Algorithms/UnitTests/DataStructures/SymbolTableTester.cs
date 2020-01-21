using System;
using System.IO;
using System.Linq;
using System.Text;
using RiskAndPricingSolutions.Algorithms.DataStructures.SymbolTable;
using static System.Console;

namespace RiskAndPricingSolutions.Algorithms.UnitTests.DataStructures
{
    public class SymbolTableTester
    {
        public static void FrequencyTest(ISymbolTable<String, int> table, int minLength, string fileName)
        {
            string basedir = AppDomain.CurrentDomain.BaseDirectory;

            using (FileStream fs = File.OpenRead(basedir + @"\\DataStructures\\Data\\" + fileName))
            {
                using (StreamReader streamReader = new StreamReader(fs, Encoding.UTF8))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        var words = line.Split().Where(s => s.Length >= minLength);
                        foreach (var word in words)
                        {
                            table.TryGetValue(word, out var val);
                            table.Put(word, val + 1);
                        }
                    }
                }
            }
        }

        public static void IndexingClientTest(ISymbolTable<String, int> table)
        {
            string input = "S E A R C H E X A M P L E";
            string[] keys = input.Split();

            for (int i = 0; i < keys.Length; i++)
                table.Put(keys[i],i);

            foreach (var key in table.Keys())
                WriteLine($"{key} {table.Get(key)}");
        }
    }
}
