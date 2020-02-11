using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RiskAndPricingSolutions.Algorithms.DataStructures.SymbolTable
{
    public class LinkedListSymbolTable<TKey, TVal> : ISymbolTable<TKey, TVal>
    {
        public TVal this[TKey key]
        {
            get => Get(key);
            set => Put(key, value);
        }

        private void Put(TKey key, TVal value)
        {
            Node n = Nodes().FirstOrDefault(node => node.Key.Equals(key));

            if (n != null)
            {
                n.Value = value;
                return;
            }

            n = new Node(key, value) {Next = _first};
            _first = n;
            _count++;
        }

        public bool TryGetValue(TKey key, out TVal value)
        {
            Node n = Nodes().FirstOrDefault(node => node.Key.Equals(key));

            if (n != null)
            {
                value = n.Value;
                return true;
            }

            value = default(TVal);
            return false;
        }

        public IEnumerable<TVal> Values => Nodes().Select(node => node.Value);

        public IEnumerable<TKey> Keys => Nodes().Select(node => node.Key);

        public IEnumerable<KeyValuePair<TKey, TVal>> KeyValues() =>
            Nodes().Select(n => new KeyValuePair<TKey, TVal>(n.Key, n.Value));

        public long Count => _count;
        public void Delete(TKey key)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TVal>> GetEnumerator() =>
            Nodes().Select(node => new KeyValuePair<TKey, TVal>(node.Key, node.Value)).GetEnumerator();

        public override string ToString() => $"Count={Count}";
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private TVal Get(TKey key)
        {
            var n = Nodes().FirstOrDefault(node => node.Key.Equals(key));
            if (n != null) return n.Value;

            throw new KeyNotFoundException($"{key} not in SymbolTable");
        }

        private IEnumerable<Node> Nodes()
        {
            for (Node n = _first; n != null; n = n.Next)
                yield return n;
        }

        private int _count;
        private Node _first;
        private IEnumerable<TKey> _keys;

        [DebuggerDisplay("Key={Key}, Value={Value}")]
        private class Node
        {
            public Node(TKey key, TVal value)
            {
                Key = key;
                Value = value;
            }

            public TKey Key { get; set; }
            public TVal Value { get; set; }
            public Node Next { get; set; }

            public override string ToString() => $"{Key}:{Value} -> {Next}";
        }
    }
}

