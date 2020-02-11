using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace RiskAndPricingSolutions.Algorithms.DataStructures.SymbolTable.BST
{
    public class BinarySearchSearchTreeRecursive<TK, TV> : IBinarySearchTree<TK, TV> where TK : IComparable<TK>
    {
        /// <summary>
        /// Gets or sets the value associated with the given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>The value associated with the key</returns>
        public TV this[TK key]
        {
            set => Root = PutRecursive(Root, key, value);
            get => GetRecursive(Root, key);
        }

        public bool TryGetValue(TK key, out TV value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TK> Keys => GetKeyValuePairsInOrder().Select(x => x.Key);
        public IEnumerable<TV> Values => GetKeyValuePairsInOrder().Select(x => x.Value);

        /// <summary>
        /// The number of nodes in the searchTree
        /// </summary>
        public long Count => Root?.Size ?? 0;

        /// <summary>
        /// Obtain a reference to the root node.
        /// </summary>
        public TreeNode<TK, TV> Root { get; set; }

        /// <summary>
        /// Find the lowest searchKey in the searchTree whose value is >= searchKey
        /// </summary>
        /// <param name="searchKey"></param>
        /// <returns>The key that forms the ceiling of searchKey</returns>
        public TK Ceiling(TK searchKey)
        {
            TreeNode<TK, TV> CeilingRecursive(TreeNode<TK, TV> node)
            {
                // We have got to a leaf and not found a value that is 
                // less than or equal to the searchKey. We need to return null.
                if (node == null) return null;

                var compareTo = searchKey.CompareTo(node.Key);

                // If the searchKey matches the current node's searchKey then the current
                // node searchKey is by definition the largest value greater than or equal to
                // searchKey. We have found the ceiling.
                if (compareTo == 0)
                    return node;

                // If the searchKey is greater than the searchKey in this node then this node
                // cannot be its ceiling. We need to look for a larger node. Larger 
                // nodes reside in the right sub-searchTree so we look right
                if (compareTo > 0)
                    return CeilingRecursive(node.Right);

                // Now we need to be a bit careful. The searchKey is less than the searchKey on the
                // current node. If there is a node to the left of the current node whose value
                // greater than or equal to the searchKey that will be the floor. If no value in the left 
                // subtree is greater than or equal to the searchKey then the current node is the floor
                var tmp = CeilingRecursive(node.Left);
                return tmp ?? node;
            }

            var recurse = CeilingRecursive(Root);
            if (recurse == null) throw new KeyNotFoundException();
            return recurse.Key;
        }

        /// <summary>
        /// Find the highest searchKey in the searchTree whose value is <= searchKey
        /// </summary>
        /// <param name="searchKey"></param>
        /// <returns>The highest search key less than or equal to searchKey</returns>
        public TK Floor(TK searchKey)
        {
            TreeNode<TK, TV> FloorRecursive(TreeNode<TK, TV> node)
            {
                // We have got to a leaf and not found a value that is 
                // less than or equal to the searchKey. We need to return null.
                if (node == null) return null;

                var compareTo = searchKey.CompareTo(node.Key);

                // If the searchKey matches the current node's searchKey then the current
                // node searchKey is by definition the largest value less than or equal to
                // searchKey. We have found the floor.
                if (compareTo == 0)
                    return node;

                // If the searchKey is smaller than the searchKey in this node then this node
                // cannot be its floor. We need to look for a smaller node. Smaller 
                // nodes reside in the left sub-searchTree so we look left
                if (compareTo < 0)
                    return FloorRecursive(node.Left);

                // Now we need to be a bit careful. The searchKey is greater than the searchKey on the
                // current node. If there is a node to the right of the current node whose value
                // less than or equal to the searchKey that will be the floor. If no value in the right 
                // subtree is less than or equal to the searchKey then the current node is the floor
                var tmp = FloorRecursive(node.Right);
                return tmp ?? node;
            }

            var floorRecursive = FloorRecursive(Root);
            if (floorRecursive == null) throw new KeyNotFoundException();
            return floorRecursive.Key;
        }

        /// <summary>
        /// Return the number of keys less than key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Rank(TK key)
        {
            if (Root == null) return 0;

            int RankRecursive(TreeNode<TK, TV> node)
            {
                // There are no keys less than key in a null node.
                if (node == null) return 0;

                var cmp = key.CompareTo(node.Key);

                // If the key matches the key on this node the number of keys less than key
                // is the size of this nodes left subtree.
                if (cmp == 0) return node.Left?.Size ?? 0;

                // If the key is less than the current nodes key we need to recurse left
                if (cmp < 0)
                    return RankRecursive(node.Left);

                return (node.Left?.Size ?? 0) + 1 + RankRecursive(node.Right);
            }

            return RankRecursive(Root);
        }

        /// <summary>
        /// Select the key of rank k
        /// This is the key such that exactly k other keys in the searchTree are 
        /// less than it. 
        /// </summary>
        /// <param name="k"></param>
        /// <returns>The key such that k other keys are less than it</returns>
        public TK Select(int k)
        {
            if (Root == null)
                throw new InvalidOperationException($"Tree is empty so no element with rank {k}");

            if (Root.Size <= k)
                throw new InvalidOperationException(
                    $"Tree has only {Root.Size} entries so element has {k} keys smaller");

            TreeNode<TK, TV> RecursiveSelect(TreeNode<TK, TV> currentNode, int k1)
            {
                // Take the size of the left currentNode. This is by definition the number of keys less than or
                // equal to the current currentNode. 
                var leftCount = currentNode?.Left?.Size ?? 0;

                // If leftCount is equal to k1 then there are exactly k1 nodes less than currentNode and currentNode
                // is the one we are looking for
                if (leftCount == k1)
                    return currentNode;

                // If there are more nodes less than k1 in the left node we need to recursively go left
                if (leftCount > k1)
                    return RecursiveSelect(currentNode.Left, k1);

                // Otherwise we move right. Any node to the right by definition already is greater than than all the
                // keys in the current node. So we are looking for the right node that has (k1-(leftCount+1)) keys less than it
                return RecursiveSelect(currentNode.Right, k1 - (leftCount + 1));
            }

            return RecursiveSelect(Root, k).Key;
        }

        /// <summary>
        /// Delete the minimum key in the BinarySearchTree
        /// </summary>
        public void DeleteMin()
        {
            if (Root != null)
                DeleteMinRecursive(Root);
        }

        private TreeNode<TK, TV> DeleteMinRecursive(TreeNode<TK, TV> currentNode)
        {
            if (currentNode.Left == null) return currentNode.Right;
            currentNode.Left = DeleteMinRecursive(currentNode.Left);
            currentNode.Size = (currentNode.Left?.Size ?? 0) + (currentNode.Right?.Size ?? 0) + 1;
            return currentNode;
        }

        public TK MaxKey
        {
            get
            {
                TK GetMaxKey(TreeNode<TK, TV> node)
                {
                    if (node == null) throw new InvalidEnumArgumentException();

                    if (node.Right == null) return node.Key;

                    return GetMaxKey(node.Right);
                }

                return GetMaxKey(Root);
            }
        }

        public TK MinKey
        {
            get
            {
                if (Root == null) throw new InvalidEnumArgumentException();
                return GetMin(Root).Key;
            }
        }

        private TreeNode<TK, TV> GetMin(TreeNode<TK, TV> node)
        {
            if (node.Left == null) return node;
            return GetMin(node.Left);
        }

        private Queue<KeyValuePair<TK, TV>> GetKeyValuePairsInOrder()
        {
            void InOrderRecursive(TreeNode<TK, TV> node, Queue<KeyValuePair<TK, TV>> queue)
            {
                if (node.Left != null) InOrderRecursive(node.Left, queue);
                queue.Enqueue(new KeyValuePair<TK, TV>(node.Key, node.Value));
                if (node.Right != null) InOrderRecursive(node.Right, queue);
            }

            Queue<KeyValuePair<TK, TV>> q = new Queue<KeyValuePair<TK, TV>>();
            InOrderRecursive(Root, q);
            return q;
        }

        public IEnumerator<KeyValuePair<TK, TV>> GetEnumerator() 
            => GetKeyValuePairsInOrder().GetEnumerator();


        public override string ToString() => $"Count={Count}";
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private static TV GetRecursive(TreeNode<TK, TV> node, TK key)
        {
            if (node == null)
                throw new KeyNotFoundException($"{key} not found");

            var compareTo = key.CompareTo(node.Key);

            // We have a hit. Return this nodes value
            if (compareTo == 0) return node.Value;

            // We move left or right depending on whether the searchKey is greater than or
            // equal to the searchKey at this node.l
            return (compareTo > 0) ? GetRecursive(node.Right, key) : GetRecursive(node.Left, key);
        }

        public void Delete(TK key)
        {
            TreeNode<TK, TV> DeleteRecursive(TreeNode<TK, TV> x)
            {
                if (x == null) return null;
                var cmp = key.CompareTo(x.Key);
                if (cmp < 0) x.Left = DeleteRecursive(x.Left);
                else if (cmp > 0) x.Right = DeleteRecursive(x.Right);
                else
                {
                    if (x.Right == null) return x.Left;
                    if (x.Left == null) return x.Right;
                    TreeNode<TK, TV> t = x;
                    x = GetMin(t.Right);
                    x.Right = DeleteMinRecursive(t.Right);
                    x.Left = t.Left;
                }

                x.Size = 1;
                if (x.Left != null) x.Size += x.Left.Size;
                if (x.Right != null) x.Size += x.Right.Size;

                return x;
            }

            Root = DeleteRecursive(Root);
        }

        private static TreeNode<TK, TV> PutRecursive(TreeNode<TK, TV> node, TK key, TV value)
        {
            // We have moved left or right down the searchTree and reached a 
            // null/leaf node. The searchKey is therefor not in the table. We
            // create a new node for the searchKey/value and return it.
            if (node == null) return new TreeNode<TK, TV>(key, value);

            // Compare the new searchKey to the searchKey in the current node
            int cmp = key.CompareTo(node.Key);

            if (cmp == 0)
            {
                // We have a match. Replace the value in this node with the 
                //new value and return it
                node.Value = value;
                return node;
            }

            // The searchKey to be inserted does not match the current node and the current 
            // node is not a null/leaf so we need to recurse. If the searchKey to be inserted
            // is greater than the current searchKey we set the right node of this node to be the
            // result of recursively calling this function on this nodes right link.
            //
            // Note: We always replace the left or right node. As with this implementation we 
            // always only creates new nodes at leaves we could test and only do this when the 
            // left/right pointers are null. But this code is as efficient and takes less code. The
            // logic to set the left/right is simpler than the logic to test and set.
            if (cmp < 0) node.Left = PutRecursive(node.Left, key, value);
            if (cmp > 0) node.Right = PutRecursive(node.Right, key, value);
            node.Size = (node.Left?.Size ?? 0) + (node.Right?.Size ?? 0) + 1;

            return node;
        }
    }
}
