using System.Collections.Generic;

namespace RiskAndPricingSolutions.Algorithms.DataStructures.SymbolTable
{
    public interface ISymbolTable<TKey,TVal>
    {
        void Put(TKey key, TVal value);

        TVal Get(TKey key);

        bool TryGetValue(TKey key, out TVal value);

        IEnumerable<TKey> Keys();

        IEnumerable<KeyValuePair<TKey, TVal>> KeyValues();

        long Count { get; }
        

    }

    
}