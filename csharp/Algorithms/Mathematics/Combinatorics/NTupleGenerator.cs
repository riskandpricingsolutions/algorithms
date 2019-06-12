using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;

namespace RiskAndPricingSolutions.Algorithms.Mathematics.Combinatorics
{
    public class NTupleGenerator
    {
        public static void Permutate()
        {
            // Consider the sequence (0,1,2,5,3,3,0)
            //
            // To find the next permutation we want to increase the sequence but 
            // increase it as little as possible. To do this we need to first 
            // identify the longest suffix that is non-increasing (from left to right)
            // This will have at least one element. In order case we have
            // Prefix:Suffix (0,1,2):(5,3,3,0)
            // The element immediately to the left of the suffix is called the pivot. In this
            // case the pivot is 2.
            //
            // We now swap the pivot with the smallest element in the suffix that is greater than the pivot
            // In our case the right most 3. We now get
            // Prefix:Suffix (0,1,3):(5,3,2,0)





        }


        public static IEnumerable<int[]> CalculateNumberCombinations(int numDigits, int @base)
        {
            var temp = new int[numDigits];

            while (true)
            {
                // Return the n-tuple
                var num = new int[numDigits];
                Array.Copy(temp, num, temp.Length);
                yield return num;


                int j = 0;
                while (j < temp.Length && temp[j] == @base - 1)
                {
                    temp[j] = 0;
                    j++;
                }

                // If j is greater than the last element in seqIndices we have overflowed
                // off the end of seqIndices. In this case the work of this algorithm is done
                // and we have visited all n-permutations
                if (j == temp.Length)
                    break;

                temp[j]++;
            }
        }



        public void Permutate(int[] elements)
        {
            //if (elements.Length <= 1)
            //    return Enumerable.Empty<int[]>();

            // L2: Find last j such that self[j] <= self[j+1]. Terminate if no such j
            // exists.
            var j = elements.Length - 2;
            while (j >= 0 && elements[j] > elements[j + 1])
            {
                j -= 1;
            }

            //// L3: Find last l such that self[j] <= self[l], then exchange elements j and l:
            var l = elements.Length - 1;
            while (elements[j] > elements[l])
            {
                l -= 1;
            }

            // swap
            int temp = elements[j];
            elements[j] = elements[l];
            elements[l] = temp;

            // L4: Reverse elements j+1 ... count-1:
            var lo = j + 1;
            var hi = elements.Length - 1;
            while (lo < hi)
            {
                temp = elements[lo];
                elements[lo] = elements[hi];
                elements[hi] = temp;
                lo += 1;
                hi -= 1;
            }
        }
    }
}