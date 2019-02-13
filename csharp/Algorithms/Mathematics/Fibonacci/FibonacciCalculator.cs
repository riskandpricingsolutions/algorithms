using System.Collections.Generic;

namespace RiskAndPricingSolutions.Algorithms.Mathematics.Fibonacci
{
    public class FibonacciCalculator : IFibonacciCalculator
    {
        public int FibonacciRecursive(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;

            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }

        public int FibonacciIterative(int n)
        {
            int current = 0, next = 1;

            for (int i = 0; i < n; i++)
            {
                int nextnext = current + next;
                current = next;
                next = nextnext;
            }
            return current;
        }

        public IEnumerable<int> FibonacciSequenceIterator()
        {
            throw new System.NotImplementedException();
        }
    }
}