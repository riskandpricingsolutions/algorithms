using System.Collections.Generic;

namespace RiskAndPricingSolutions.Algorithms.Mathematics.Combinatorics
{
    public interface ICombinatoricCalculator
    {
        /// <summary>
        /// Calculate the number of permutations of n things taken 
        /// r at a time
        /// </summary>
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <param name="allowRepetitions">Can the same element of n appear in multiple positions</param>
        /// <returns></returns>
        long PermutationsCount(long n, long r, bool allowRepetitions=false);

        /// <summary>
        /// Calculate the number of combinations of n things taken 
        /// r at a time
        /// </summary>
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        long CombinationsCount(long n, long r);

        /// <summary>
        /// Generate all permutations of n objects taken r at a time
        /// </summary>
        /// <typeparam name="TElementType"></typeparam>
        /// <param name="nObjects">The n objects</param>
        /// <param name="r">Taken r at a time</param>
        /// <param name="allowRepetitions">Are repetitions allowed</param>
        /// <returns>The permutations</returns>
        IList<TElementType[]> GeneratePermutations<TElementType>(TElementType[] nObjects, int r,
            bool allowRepetitions);
    }
}
