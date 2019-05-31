using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using RiskAndPricingSolutions.Algorithms.Mathematics.Factorial;

namespace RiskAndPricingSolutions.Algorithms.Mathematics.Combinatorics
{
    public class CombinatoricCalculator : ICombinatoricCalculator
    {
        public long PermutationsCount(long n, long r, bool allowRepetitions = false)
        {
            if (allowRepetitions)
                return (long)Math.Pow(n, r);

            return n.Factorial() / (n - r).Factorial();
        }

        public long CombinationsCount(long n, long r)
        {
            throw new System.NotImplementedException();
        }

        public IList<TElementType[]> GeneratePermutations<TElementType>(TElementType[] nObjects, int r, bool allowRepetitions)
        {
            IList<TElementType[]> permutations = new List<TElementType[]>();
            GeneratePermutationsRecursive(new TElementType[r],nObjects,0,r,permutations,allowRepetitions );
            return permutations;
        }

        private void GeneratePermutationsRecursive<TElementType>(TElementType[] current, IList<TElementType> nObjects, int idx,
            int r, IList<TElementType[]> permutations, bool allowRepetitions)
        {
            foreach (var n in nObjects)
            {
                var copy = new TElementType[r];
                Array.Copy(current, copy, r);
                copy[idx] = n;

                IList<TElementType> adjustedNObjs =
                    allowRepetitions ? nObjects : nObjects.Where(x => !x.Equals(n)).ToList();

                if (idx == r - 1)
                    permutations.Add(copy);
                else
                    GeneratePermutationsRecursive(copy, adjustedNObjs, idx + 1, r, permutations,allowRepetitions);
            }
        }

        private readonly IFactorialCalculator _factorialCalculator = new FactorialCalculator();
    }
}