using System;
using System.Collections.Generic;

namespace RiskAndPricingSolutions.Algorithms.DataStructures
{
    public interface IBinarySearch
    {
        int BinarySearch<T>(IList<T> lst, T val) where T : IComparable<T>;
        int BinarySearchRecursive<T>(T[] arr, T val);
    }
}
