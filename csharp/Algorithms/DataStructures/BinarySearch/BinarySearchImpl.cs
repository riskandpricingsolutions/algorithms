using System;
using System.Collections.Generic;

namespace RiskAndPricingSolutions.Algorithms.DataStructures.BinarySearch
{
    public class BinarySearchImpl : IBinarySearch
    {
        public int BinarySearch<T>(IList<T> arr, T val) where T : IComparable<T>
        {
            if (arr == null)
                throw new ArgumentNullException();

            int loIdx = 0;
            int hiIdx = arr.Count - 1;
            while (loIdx <= hiIdx)
            {
                int miIdx = loIdx + (hiIdx - loIdx) / 2;
                int comp = val.CompareTo(arr[miIdx]);

                if (comp == 0)
                    return miIdx;

                if (comp > 0)
                    loIdx = miIdx + 1;
                else
                    hiIdx = miIdx - 1;
            }

            return ~loIdx;
        }

        public int BinarySearchRecursive<T>(T[] arr, T val)
        {
            throw new NotImplementedException();
        }
    }
}
