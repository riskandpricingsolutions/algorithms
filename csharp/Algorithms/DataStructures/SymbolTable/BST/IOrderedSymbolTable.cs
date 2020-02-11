namespace RiskAndPricingSolutions.Algorithms.DataStructures.SymbolTable.BST
{
    public interface IOrderedSymbolTable<TK,TV> : ISymbolTable<TK,TV>
    {
        /// <summary>
        /// Find the lowest searchKey in the searchTree whose value is >= searchKey
        /// </summary>
        /// <param name="searchKey"></param>
        /// <returns>The key that forms the ceiling of searchKey</returns>
        TK Ceiling(TK searchKey);

        /// <summary>
        /// Find the highest searchKey in the searchTree whose value is <= searchKey
        /// </summary>
        /// <param name="searchKey"></param>
        TK Floor(TK searchKey);

        /// <summary>
        /// Return the number of keys less than key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>The number of keys less than key</returns>
        int Rank(TK key);

        /// <summary>
        /// Select the searchKey of rank k. That is the
        /// searchKey such that exactly k other keys in the BST
        /// are smaller. Note: There are no duplicates in a BST
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        TK Select(int k);

        /// <summary>
        /// Delete the minimum key in the BinarySearchTree
        /// </summary>
        void DeleteMin();

        TK MinKey { get; }

        TK MaxKey { get; }
    }
}
