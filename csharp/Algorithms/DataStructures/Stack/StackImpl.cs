using System;

namespace RiskAndPricingSolutions.Algorithms.DataStructures.Stack
{
    public class StackImpl<T> : IStack<T>
    {
        public StackImpl(long initialSize)
        {
            _storage = new T[initialSize];
        }

        public void Push(T item)
        {
            if (_stackSize == _storage.Length)
                Resize(_storage.Length * 2);

            _storage[_stackSize++] = item;
        }

        public T Pop()
        {
            if (_stackSize == 0)
                throw new InvalidOperationException("Stack is empty");

            if (_stackSize <= _storage.Length / 4)
                Resize(_storage.Length / 2);

            return _storage[--_stackSize];
        }

        public long Count => _stackSize;

        private void Resize(long newSize)
        {
            T[] newStorage = new T[newSize];
            Array.Copy(_storage, newStorage, _stackSize);
            _storage = newStorage;
        }

        private int _stackSize = 0;
        private T[] _storage;
    }
}
