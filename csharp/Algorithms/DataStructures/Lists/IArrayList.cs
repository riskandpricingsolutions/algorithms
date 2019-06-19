
using System.Collections.Generic;

namespace RiskAndPricingSolutions.Algorithms.DataStructures.Lists
{
    public interface IArrayList<T>
    {
        // Add an element to the end of the list
        void Add(T element);

        // Remove the element at the given index.
        void RemoveAt(int index);

        /// <summary>
        /// Add a range of elements to the end of the list
        /// </summary>
        /// <param name="elements"></param>
        void AddRange(IEnumerable<T> elements);

        void Insert(int index, T element);

        // Index based access
        T this[int index] { get; set; }
    }
}
