using System.Collections;
using System.Collections.Generic;
using RiskAndPricingSolutions.Algorithms.DataStructures.LinkedList;

namespace RiskAndPricingSolutions.Algorithms.DataStructures.Lists.SinglyLinkedList
{
    public class LinkedListImpl<T> : ILinkedList<T>
    {
        /// <summary>
        /// Add an element to the front of the list
        /// O(1) operation. The number of elements in the 
        /// list has no impact. The cost is
        ///   1) A single object instantiation
        ///   2) 4 field updates
        ///   3) A single equality comparison
        ///   4) A single integer increment
        /// </summary>
        /// <param name="data">The data element to prepend to the front</param>
        public void AddFirst(T data)
        {
            Node<T> newNode = new Node<T>
            {
                Data = data,
                Next = _first
            };

            if (_first == null)
                _last = newNode;

            _first = newNode;
            ++_size;
        }

        /// <summary>
        /// Add the data element to the back of the list.
        /// O(1) operation. The number of elements in 
        /// the list has no impact. The cost is
        ///     1) A single integer instantiation
        ///     2) 3 field updates
        ///     3) a single equality comparison
        ///     4) a single integer increment
        /// </summary>
        /// <param name="data">The item to add to the back</param>
        public void AddLast(T data)
        {
            Node<T> newNode = new Node<T>() { Data = data };
            if (_first == null)
                _first = _last = newNode;
            else
                _last.Next = newNode;
            _last = newNode;
            ++_size;
        }

        /// <summary>
        /// Remove the first element from the list
        /// O(1) operation. The number of elements in
        /// the list is irrelevant. The cost is
        ///    1) 2 equality comparisons
        ///    2) 2 field updates
        ///    3) A single integer decrement
        /// </summary>
        public void RemoveFirst()
        {
            if (_first != null)
            {
                if (_first.Next == null)
                    _first = _last = null;
                else
                    _first = _first.Next;
                --_size;
            }
        }

        /// <summary>
        /// Remove the last element. Since we have no back
        /// pointer, in all but the simplest cases we need
        /// to perform a traversal so the running time is 
        /// O(N)
        /// </summary>
        public void RemoveLast()
        {
            if (_last != null)
            {
                // Single element list is easy
                if (_first.Next == null)
                    _first = _last = null;
                else
                {
                    // This is tricky. We don't have a 
                    // back pointer so we need to traverse.
                    Node<T> current = _first;
                    Node<T> previous = _first;

                    while (current.Next != null)
                    {
                        previous = current;
                        current = current.Next;
                    }
                    _last = previous;
                    _last.Next = null;
                    --_size;
                }
            }
        }

        public int Count => _size;

        /// <summary>
        /// Implemented as a linear search so
        /// performance is O(N) in the worst case
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if the value is in the list</returns>
        public bool Contains(T value)
        {
            Node<T> current = _first;

            while (current != null)
            {
                if (current.Data.Equals(value))
                    return true;
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Removal is an O(N) operation on a linked list
        /// as it requires a traversal
        /// </summary>
        /// <param name="value">The element to be removed</param>
        /// <returns></returns>
        public bool Remove(T value)
        {
            Node<T> current = _first;
            Node<T> prev = null;

            while (current != null && !(current.Data.Equals(value)))
            {
                prev = current;
                current = current.Next;
            }

            // we got a match
            if (current != null)
            {
                // If the first element in the list is our match
                // we set the first to be the second element. If 
                // there is no second element current.Next will be
                // null so we don't have to do anything
                if (_first == current)
                    _first = current.Next;

                // If the last element in our list is the match we need
                // to use the prev pointer. In a single element list 
                // where we match we set the last to null so no
                // problem
                if (_last == current)
                    _last = prev;

                // The element we found was not the first element so we 
                // need to set the previous to skip the element removed
                if (prev != null)
                    prev.Next = current.Next;

                --_size;
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = _first;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// A node simply has a piece of data and a 
        /// reference to the next node
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        private class Node<T1>
        {
            public T1 Data;
            public Node<T1> Next;
        }

        /// <summary>
        /// A singly linked list is essentially a pointer
        /// to the first node
        /// </summary>
        private Node<T> _first;
        private Node<T> _last;
        private int _size;
    }
}