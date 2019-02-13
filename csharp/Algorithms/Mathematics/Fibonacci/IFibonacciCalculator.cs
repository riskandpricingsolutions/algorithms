using System.Collections.Generic;

namespace RiskAndPricingSolutions.Algorithms.Mathematics.Fibonacci
{
    public interface IFibonacciCalculator
    {
        int FibonacciRecursive(int n);
        int FibonacciIterative(int n);
        IEnumerable<int> FibonacciSequenceIterator();
    }
}