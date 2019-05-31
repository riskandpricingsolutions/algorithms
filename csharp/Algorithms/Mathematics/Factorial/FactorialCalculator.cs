using System;

namespace RiskAndPricingSolutions.Algorithms.Mathematics.Factorial
{
    public class FactorialCalculator : IFactorialCalculator
    {
        public long FactorialRecursive(long n)
        {
            if ( n < 0)
                throw new ArgumentOutOfRangeException();

            if (n == 0 || n == 1)
                return 1;

            return n * FactorialRecursive(n - 1);
        }

        public long FactorialIterative(long n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException();

            if (n == 0)
                return 1;

            long result = n;
            while (n > 1)
            {
                result = result * (n-- - 1);
            }

            return result;
        }
    }
}