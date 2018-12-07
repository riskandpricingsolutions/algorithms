using System.Collections.Generic;
using System.Linq;

namespace RiskAndPricingSolutions.Algorithms.Mathematics.PrimeNumbers
{
    public class PrimeNumberCalculationsImpl :IPrimeNumberCalculations
    {
        public bool IsPrime(int n)
        {
            if (n < 2)
                return false;

            if (n == 2)
                return true;

            // The definition of a prime is an integer
            // which is not exactly divisible by any 
            // number other than itself and one. We
            // hence test the n-2 integers from 
            // 2,..., n-1
            return Enumerable.Range(2, n - 2)
                .All(i => n % i > 0);
        }

        public int PrimesBetween(int lowerBound, int upperBound)
        {
            return Enumerable.Range(lowerBound, upperBound - lowerBound + 1)
                .Count(IsPrime);
        }

        public int PrimesLessThanX(int x)
        {
            return PrimesBetween(0, x - 1);
        }

        public IEnumerable<int> FirstNPrimes(int n)
        {
            if (n < 1)
                yield break;

            for (int numFound = 1, current = 2; numFound <= n;)
            {
                if (IsPrime(current))
                {
                    yield return current;
                    numFound++;
                }

                current++;
            }
        }
    }
}
