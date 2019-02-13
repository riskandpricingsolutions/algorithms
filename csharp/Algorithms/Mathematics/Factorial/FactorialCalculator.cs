using System;

namespace RiskAndPricingSolutions.Algorithms.Mathematics.Factorial
{
    public class FactorialCalculator : IFactorialCalculator
    {
        public int FactorialRecursive(int n)
        {
            if ( n < 0)
                throw new ArgumentOutOfRangeException();

            if (n == 0 || n == 1)
                return 1;

            return n * FactorialRecursive(n - 1);
        }

        public int FactorialIterative(int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException();

            if (n == 0)
                return 1;

            int result = n;
            while (n > 1)
            {
                result = result * (n-- - 1);
            }

            return result;
        }
    }
}