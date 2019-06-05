using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace RiskAndPricingSolutions.Algorithms.Mathematics.Combinatorics
{
    public class NTupleGenerator
    {
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
                while (j < temp.Length && temp[j] == @base-1)
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

        public static IEnumerable<T[]> CalculateNTuples<T>(T[] sequence, T[][] events)
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
    }
}
