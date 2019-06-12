using System;
using System.Collections.Generic;
using RiskAndPricingSolutions.Algorithms.Mathematics.Factorial;

namespace RiskAndPricingSolutions.Algorithms.Mathematics.Combinatorics
{
    public class PossibilityGenerator : IPossibilityGenerator
    {
        public IEnumerable<T[]> GeneratePermutations<T>(T[] initialPermutation) where T : IComparable<T>
        {
            // To be clear on our terminology. We assume the given initialPermutation 
            // is the permutation with lowest lexicographical value. As such we expect
            // a[0] <= a[1] <= ... <= a[n-1] Put another way we expect the values in the
            // permutation to be in weakly increasing (non-decreasing) order from index 0 
            // through to index n-1. For the purposes of this method we will refer to the element
            // with the highest value of j as the rightmost element and the value with the lowest value
            // of j as the left most element
            //
            //     Left/MSB  {1,2,3,4} Right/LSB
            //     Index     {0,1,2,3} 
            //  
            // For example initialPermutation might hold {1,2,3,4} and we assume index 0 
            // hold the 'most significant digit' and index 3 holds the 'least significant digit'
            T[] a = initialPermutation;
            int n = initialPermutation.Length;

            while (true)
            {
                // Take a shallow copy of the current permutation and yield return
                // it before we make any modifications
                a = (T[])a.Clone();
                yield return a;

                // Find the value of index j such that we have visited all permutations of
                // a[0],a[1],...a[j] We obtain this by finding the highest index j such that
                // a[j] < a[j+1]
                //
                // Example: If we say that a={1,2,3} then we are finding the highest value of j
                // such that the value at position j is greater than the element at position j+1 In 
                // our case that occurs at j=1
                //
                // {1,2,3} 
                //    |
                //    j
                var j = n - 2;
                while (j >= 0 && a[j].CompareTo(a[j + 1]) >= 0) j--;

                // If there is no such j then we are already on the lexicographically highest and 
                // therefore the last permutation. In this case we break out of the while loop
                // thereby terminating the method
                if (j == -1)
                    break;

                // If we have visited all permutations {a[0],...[aj]} then the way to move to the next
                // permutation lexicographically is to swap a[j] with the smallest element greater than
                // a[j] whose index is greater than j. As the elements to the right of a[j] are sorted in 
                // decreasing order from left to right, the first element greater than a[j] when walking from right
                // to left is the smallest value greater than a[j]
                var l = n - 1;
                while (a[j].CompareTo(a[l]) >= 0) l -= 1;

                // swap
                Swap(a, j, l);


                // At the moment, everything to the right of a[j] is sorted in decreasing order 
                // As we have just increased a[j] we need to reverse a[j+1]..a[n] so we have the next
                // lexicographical element
                for (int lo = j + 1, hi = n - 1; lo < hi; lo++, hi--)
                    Swap(a, lo, hi);
            }
        }

        public long NTupleCount(long n, long r) => (long)Math.Pow(n, r);

        public long PermutationCount(long n, long r) => n.Factorial() / (n - r).Factorial();

        public long CombinationsCount(long n, long r) => n.Factorial() / ((n - r).Factorial() * r.Factorial());

        public IEnumerable<TElementType[]> GenerateNTuples<TElementType>(TElementType[] nObjects)
        {
            TElementType[][] events = new TElementType[nObjects.Length][];
            for (int i = 0; i < nObjects.Length; i++)
                events[i] = nObjects;

            return GenerateNTuples(new TElementType[nObjects.Length], events);
        }



        private static IEnumerable<T[]> GenerateNTuples<T>(T[] sequence, T[][] events)
        {
            int[] seqIndices = new int[sequence.Length];

            while (true)
            {
                // Process the current value. Convert indices to elements
                T[] ntuple = new T[sequence.Length];
                for (int i = 0; i < sequence.Length; i++)
                    ntuple[i] = events[i][seqIndices[i]];

                // Return the n-tuple
                yield return ntuple;

                // In this algorithm we treat  the indices array as a
                // n digit number where the base of each digit is determined by the
                // number of elements in that digits corresponding event array from events. 
                // Moving to the next n-tuple is then a  case of incrementing the 
                // n-digit number held in seqIndices. To this we need to take care of 
                // overflow which is what the following loop condition does.		
                int j = 0;
                while (j < sequence.Length && seqIndices[j] == events[j].Length - 1)
                {
                    seqIndices[j] = 0;
                    j++;
                }

                // If j is greater than the last element in seqIndices we have overflowed
                // off the end of seqIndices. In this case the work of this algorithm is done
                // and we have visited all n-permutations
                if (j == sequence.Length)
                    break;

                seqIndices[j]++;
            }
        }

        private void Swap<T>(T[] arr, int idx1, int idx2)
        {
            T temp = arr[idx1];
            arr[idx1] = arr[idx2];
            arr[idx2] = temp;
        }

        //public IList<TElementType[]> GeneratePermutations<TElementType>(TElementType[] nObjects, int r, bool allowRepetitions)
        //{
        //    IList<TElementType[]> permutations = new List<TElementType[]>();
        //    GeneratePermutationsRecursive(new TElementType[r],nObjects,0,r,permutations,allowRepetitions );
        //    return permutations;
        //}

        //private void GeneratePermutationsRecursive<TElementType>(TElementType[] current, IList<TElementType> nObjects, int idx,
        //    int r, IList<TElementType[]> permutations, bool allowRepetitions)
        //{
        //    foreach (var n in nObjects)
        //    {
        //        var copy = new TElementType[r];
        //        Array.Copy(current, copy, r);
        //        copy[idx] = n;

        //        IList<TElementType> adjustedNObj =
        //            allowRepetitions ? nObjects : nObjects.Where(x => !x.Equals(n)).ToList();

        //        if (idx == r - 1)
        //            permutations.Add(copy);
        //        else
        //            GeneratePermutationsRecursive(copy, adjustedNObj, idx + 1, r, permutations,allowRepetitions);
        //    }
        //}

        private readonly IFactorialCalculator _factorialCalculator = new FactorialCalculator();
    }
}