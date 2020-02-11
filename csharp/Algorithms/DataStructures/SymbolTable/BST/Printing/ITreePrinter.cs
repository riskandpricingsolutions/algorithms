using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskAndPricingSolutions.Algorithms.DataStructures.SymbolTable.BST.Printing
{
    public interface ITreePrinter
    {
        void PrintTree<TK, TV>(IBinarySearchTree<TK, TV> bst) where TK : IComparable<TK>;
    }
}
