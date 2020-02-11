using System;

namespace RiskAndPricingSolutions.Algorithms.DataStructures.SymbolTable.BST.Printing
{
    public class BinarySearchTreePrinter : ITreePrinter
    {
        public void PrintTree<TK, TV>(IBinarySearchTree<TK, TV> bst) where TK : IComparable<TK>
        {
            var printer = new GenericTreePrinter<TreeNode<TK, TV>>(s => s.Value.ToString(),
                node => node.Left, node => node.Right);
            printer.printTree(bst.Root);
        }
    }
}