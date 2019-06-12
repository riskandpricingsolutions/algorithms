using System;
using System.Collections.Generic;

namespace RiskAndPricingSolutions.Algorithms.Mathematics.Combinatorics
{
    public interface IPossibilityGenerator
    {
        /// <summary>
        /// Calculate the number of tuples of n things taken
        /// r at a time
        /// </summary>
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        long NTupleCount(long n, long r);

        /// <summary>
        /// Calculate the number of permutations of n things taken 
        /// r at a time
        /// </summary>
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        long PermutationCount(long n, long r);

        /// <summary>
        /// Calculate the number of combinations of n things taken 
        /// r at a time
        /// </summary>
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        long CombinationsCount(long n, long r);

        /// <summary>
        /// Generate all permutations of n objects
        /// </summary>
        /// <typeparam name="TElementType"></typeparam>
        /// <param name="nObjects">The n objects</param>
        /// <returns>The permutations</returns>
        IEnumerable<TElementType[]> GeneratePermutations<TElementType>(TElementType[] nObjects)
            where TElementType : IComparable<TElementType>;

        /// <summary>
        /// Generate all permutations of n objects
        /// </summary>
        /// <typeparam name="TElementType"></typeparam>
        /// <param name="nObjects">The n objects</param>
        /// <returns>The permutations</returns>
        IEnumerable<TElementType[]> GenerateNTuples<TElementType>(TElementType[] nObjects);
    }
}
