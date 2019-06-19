

using System;
using System.Collections.Generic;
using System.Text;

namespace RiskAndPricingSolutions.Algorithms.DataStructures.Lists.ArrayList
{
    public class ArrayList<T> : IArrayList<T>
    {
        public ArrayList(long initialSize)
        {
            _storage = new T[initialSize];
        }

        /// <summary>
        /// Adding an element to the end of the list is amortized constant
        /// time meaning on the whole it is constant time, with the odd
        /// operation taking longer
        /// </summary>
        /// <param name="element"></param>
        public void Add(T element)
        {
            if (_storage.Length == _size)
                Resize(_size*2);

            _storage[_size++] = element;
        }

        /// <summary>
        /// Remove at the given index
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index > _size - 1)
                throw new ArgumentOutOfRangeException();

            Array.Copy(_storage,index+1,_storage,index,_size-(index+1));
            _size--;
        }

        /// <summary>
        /// O(M) where M is the number of elements being added
        /// </summary>
        /// <param name="elements">The elements to be added</param>
        public void AddRange(IEnumerable<T> elements)
        {
            if (elements == null) return;
            foreach (var element in elements) Add(element);
        }

        /// <summary>
        /// Insert an element somewhere in the middle of the array.
        /// O(N). As we need to do an array copy. Is this really O(N)?
        /// How is the array copy implemented.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="element"></param>
        public void Insert(int index, T element)
        {
            if (_storage.Length == _size)
                Resize(_size * 2);
            
            Array.Copy(_storage,index,_storage,index+1,_size-index);
            _size++;
        }

        /// <summary>
        /// Setting/Getting by index is an O(1) operation
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index > _size - 1)
                    throw new ArgumentOutOfRangeException();
                return _storage[index];
            }
            set
            {
                if (index < 0 || index > _size - 1)
                    throw new ArgumentOutOfRangeException();
                _storage[index] = value;
            }
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder("[");
            for (int i = 0; i < _size; i++)
            {
                if (i == _size - 1)
                    b.Append(_storage[i]);
                else
                    b.Append($"{_storage[i].ToString()},");
            }

            b.Append("]");

            return b.ToString();
        }

        private void Resize(long newSize)
        {
            T[] newStorage = new T[newSize];
            Array.Copy(_storage, newStorage, _size);
            _storage = newStorage;
        }

        private T[] _storage;
        private int _size = 0;

    }
}
