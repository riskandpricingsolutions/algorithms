using System;
using System.Collections.Generic;


namespace RiskAndPricingSolutions.Algorithms.DataStructures.SymbolTable.BST
{
    public static class RecursiveTreeTraversals
    {
        public static IEnumerable<KeyValuePair<TK, TV>> InOrderTraversal<TK, TV>(this IBinarySearchTree<TK, TV> bst)
            where TK : IComparable<TK>
        {
            void InOrderRecursive(TreeNode<TK, TV> node, Queue<KeyValuePair<TK, TV>> queue)
            {
                if (node.Left != null) InOrderRecursive(node.Left, queue);
                queue.Enqueue(new KeyValuePair<TK, TV>(node.Key, node.Value));
                if (node.Right != null) InOrderRecursive(node.Right, queue);
            }

            Queue<KeyValuePair<TK, TV>> q = new Queue<KeyValuePair<TK, TV>>();
            InOrderRecursive(bst.Root, q);
            return q;
        }

        public static IEnumerable<KeyValuePair<TK, TV>> PreOrderTraversal<TK, TV>(this IBinarySearchTree<TK, TV> bst)
            where TK : IComparable<TK>
        {
            void PreOrderRecursive(TreeNode<TK, TV> node, Queue<KeyValuePair<TK, TV>> queue)
            {
                queue.Enqueue(new KeyValuePair<TK, TV>(node.Key, node.Value));
                if (node.Left != null) PreOrderRecursive(node.Left, queue);
                if (node.Right != null) PreOrderRecursive(node.Right, queue);
            }

            Queue<KeyValuePair<TK, TV>> q = new Queue<KeyValuePair<TK, TV>>();
            PreOrderRecursive(bst.Root, q);
            return q;
        }

        public static IEnumerable<KeyValuePair<TK, TV>> PostOrderTraversal<TK, TV>(this IBinarySearchTree<TK, TV> bst)
            where TK : IComparable<TK>
        {
            void PostOrderRecursive(TreeNode<TK, TV> node, Queue<KeyValuePair<TK, TV>> queue)
            {
                if (node.Left != null) PostOrderRecursive(node.Left, queue);
                if (node.Right != null) PostOrderRecursive(node.Right, queue);
                queue.Enqueue(new KeyValuePair<TK, TV>(node.Key, node.Value));
            }

            Queue<KeyValuePair<TK, TV>> q = new Queue<KeyValuePair<TK, TV>>();
            PostOrderRecursive(bst.Root, q);
            return q;
        }
    }
}
