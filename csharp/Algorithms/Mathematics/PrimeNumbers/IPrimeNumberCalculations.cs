using System.Collections.Generic;

namespace RiskAndPricingSolutions.Algorithms.Mathematics.PrimeNumbers
{
    public interface IPrimeNumberCalculations
    {
        /// <summary>
        /// Return true if n is prime and false otherwise
        /// </summary>
        bool IsPrime(int n);

        /// <summary>
        /// Calculate the primes between lower and upper
        /// bounds inclusive
        /// </summary>
        int PrimesBetween(int lowerBound, int upperBound);

        /// <summary>
        /// Calculate the number of primes less than X
        /// </summary>
        int PrimesLessThanX(int x);

        /// <summary>
        /// Return the first n primes
        /// </summary>
        IEnumerable<int> FirstNPrimes(int n);
    }
}
