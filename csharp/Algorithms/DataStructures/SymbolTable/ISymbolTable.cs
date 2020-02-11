using System.Collections.Generic;

namespace RiskAndPricingSolutions.Algorithms.DataStructures.SymbolTable
{
    public interface ISymbolTable<TKey,TVal> : IEnumerable<KeyValuePair<TKey, TVal>>
    {
        TVal this[TKey key] { get; set; }

        bool TryGetValue(TKey key, out TVal value);

        IEnumerable<TKey> Keys { get; }

        IEnumerable<TVal> Values { get; }

        long Count { get; }

        void Delete(TKey key);
    }
}