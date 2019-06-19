using System.Collections.Generic;

namespace RiskAndPricingSolutions.Algorithms.DataStructures.SinglyLinkedList
{
    public interface ISinglyLinkedList<T> : IEnumerable<T>
    {
        void AddFirst(T data);

        void AddLast(T data);

        void RemoveFirst();

        void RemoveLast();

        int Count { get; }

        bool Contains(T value);

        bool Remove(T value);
    }
}
