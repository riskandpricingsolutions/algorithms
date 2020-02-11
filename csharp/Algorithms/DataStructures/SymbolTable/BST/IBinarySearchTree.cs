using System;

namespace RiskAndPricingSolutions.Algorithms.DataStructures.SymbolTable.BST
{
    public interface IBinarySearchTree<TK,TV> : IOrderedSymbolTable<TK,TV> where TK : IComparable<TK>
    {
        /// <summary>
        /// Obtain a reference to the Root Node
        /// </summary>
        TreeNode<TK, TV> Root { get; }
    }
}
