using System;
using System.Diagnostics;

namespace RiskAndPricingSolutions.Algorithms.DataStructures.SymbolTable.BST
{
    [DebuggerDisplay("Key={Key},Value={Value},Size={Size}")]
    public class TreeNode<TK, TV> where TK : IComparable<TK>
    {
        public int Size { get; set; }
        public TK Key { get; set; }
        public TV Value { get; set; }
        public TreeNode<TK, TV> Left { get; set; }
        public TreeNode<TK, TV> Right { get; set; }

        public TreeNode(TK key, TV value)
        {
            Key = key;
            Value = value;
            Size = 1;
        }

        public override string ToString() => $"{Key}:{Value}, Size={Size}";
    }
}
