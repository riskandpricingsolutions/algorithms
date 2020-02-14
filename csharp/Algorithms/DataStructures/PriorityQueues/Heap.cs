using System;
using System.Collections.Generic;

namespace RiskAndPricingSolutions.Algorithms.DataStructures.PriorityQueues
{
    public class PriorityHeap<TK> : IPriorityQueue<TK>
    {
        private readonly TK[] _storage;
        private int _n;
        private readonly QueueMode _mode;
        private readonly Comparison<TK> _comparer;
        private readonly TK _defaultValue;

        public PriorityHeap(int maxSize, QueueMode mode, Comparison<TK> comparer, TK defaultValue = default(TK))
        {
            _mode = mode;
            _comparer = comparer;
            _defaultValue = defaultValue;
            _storage = new TK[maxSize + 1];
            for (int i = 0; i < _storage.Length; i++) _storage[i] = defaultValue;
        }

        public int Count => _n;


        public TK Delete()
        {
            TK max = _storage[1];
            Swap(1, _n--);
            _storage[_n + 1] = _defaultValue;
            Sink(1);
            return max;
        }

        public void Insert(TK v)
        {
            _storage[++_n] = v;
            Swim(_n);
        }

        public TK Get => _storage[_n];

        private void Swim(int k)
        {
            // Restore order to the heap by moving 
            // the key up the heap until it is 
            // larger/smaller than its parent depending
            // on whether in min or max configuration
            while (k > 1 && Before(k / 2, k))
            {
                Swap(k / 2, k);
                k = k / 2;
            }
        }

        private void Sink(int k)
        {
            // Restore order to the heap by moving 
            // the key down the heap until it is 
            // larger/smaller than its parent depending
            // on whether in min or max configuration
            while (2 * k <= _n)
            {
                // The children of k are in positions 2k and 2k+1
                int j = 2 * k;

                // Set j to be the index of the lower or the two children
                if (j < _n && Before(j, j + 1)) j++;

                // If the element at k is not less than the element at j
                // break out
                if (!Before(k, j)) break;

                // Swap the element k and j
                Swap(k, j);
                k = j;
            }
        }

        private void Swap(int i, int j)
        {
            TK temp = _storage[i];
            _storage[i] = _storage[j];
            _storage[j] = temp;
        }


        private bool Before(int x, int y)
        {
            if (_mode == QueueMode.Max)
                return _comparer(_storage[x], _storage[y]) < 0;
            else
                return _comparer(_storage[x], _storage[y]) > 0;
        }
    }
}
