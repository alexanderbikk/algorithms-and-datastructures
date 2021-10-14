using AlgorithmsAndDataStructures.Trees.BST;
using System;
using System.Collections.Generic;

namespace LeetCodeMedium.Trees.BinaryTree
{
    public class TreeFromParentArraySolution
    {
        /// <summary>
        ///  /// <summary>
        /// Function to construct binary tree from parent array. With simple cycle to set nodes relationship
        /// O(2n) + O(n) extra memory
        /// See related geek for geeks problem
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public Node<int> CreateTreeFromParentArraySimpleLoop(int[] parent)
        {
            var nodes = new Node<int>[parent.Length];

            // creata array of Nodes for parent array
            // where index is the value of Node and parent[indes] is the parent for this node
            for (int i = 0; i < parent.Length; i++)
            {
                // here we also could create array with epty nodes
                nodes[i] = new Node<int>(i);
            }

            Node<int> root = null;
            for (int i = 0; i < parent.Length; i++)
            {
                // root is always -1 since has no parent
                if (parent[i] == -1)
                {
                    // set root Node
                    root = nodes[i];
                    continue;
                }

                if (nodes[parent[i]].LeftChild == null)
                {
                    //set left child for parent node {index}
                    // where index is the value of Node so nodes[i] either left or right child for nodes[parent[i]]
                    // left child always preasented firs in array and it can't be null
                    nodes[parent[i]].LeftChild = nodes[i];
                }
                else if (nodes[parent[i]].RightChild == null)
                {
                    nodes[parent[i]].RightChild = nodes[i];
                }
            }

            return root;
        }

        /// <summary>
        /// Function to construct binary tree from parent array.
        /// O(2n) + O(n + k) extra memory where k is max nodes per level
        /// See related geek for geeks problem
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public Node<int> CreateTreeFromParentArrayBFS(int[] parent, int N)
        {
            var rootValue = -1;

            // constract dictioanry with parent[i] -> {leftValue, rightValue}
            // leftValue and rightValue are indeces of the given array
            var hashTable = new Dictionary<int, int[]>();
            for (var i = 0; i < N; i++)
            {
                //find root value
                if (parent[i] == -1)
                {
                    rootValue = i;
                }

                // leftValue = i; rightValue  = -1(not exists)
                var relatedIndexes = new int[2] { i, -1 };
                // try add value
                if (!hashTable.TryAdd(parent[i], relatedIndexes))
                {
                    // we already have value for left
                    // add value for right 
                    // leftValue = parent[0]; rightValue  = parent[1] -> i
                    relatedIndexes = hashTable[parent[i]];
                    relatedIndexes[1] = i;
                }
            }
            // no paretn value found;
            if (rootValue == -1)
            {
                return null;
            }

            return CreateLevelOrderTree(hashTable, rootValue);
        }

        private Node<int> CreateLevelOrderTree(Dictionary<int, int[]> hashTable, int rootValue)
        {
            var queue = new Queue<Node<int>>();
            var root = new Node<int>(rootValue);
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();

                var isCurrentLevelValuesExists = hashTable.TryGetValue(currentNode.Value, out int[] currentLevelValues);
                // no nodes for the curent level found
                if (!isCurrentLevelValuesExists)
                {
                    continue;
                }

                var leftValue = currentLevelValues[0];
                if (leftValue != -1)
                {
                    //we have left
                    currentNode.LeftChild = new Node<int>(leftValue);
                    queue.Enqueue(currentNode.LeftChild);
                }

                var rightValue = currentLevelValues[1];
                if (rightValue != -1)
                {
                    //we have right
                    currentNode.RightChild = new Node<int>(rightValue);
                    queue.Enqueue(currentNode.RightChild);
                }
            }

            return root;
        }

        public Node<int> CreateTreeFromParentArrayDFS(int[] parent, int N)
        {
            var rootValue = -1;

            // constract dictioanry with parent[i] -> {leftValue, rightValue}
            // leftValue and rightValue are indeces of the given array
            var hashTable = new Dictionary<int, int[]>();
            for (var i = 0; i < N; i++)
            {
                //find root value
                if (parent[i] == -1)
                {
                    rootValue = i;
                    continue;
                }

                // leftValue = i; rightValue  = -1(not exists)
                var relatedIndexes = new int[2] { i, -1 };
                // try add value
                if (!hashTable.TryAdd(parent[i], relatedIndexes))
                {
                    // we already have value for left
                    // add value for right 
                    // leftValue = parent[0]; rightValue  = parent[1] -> i
                    relatedIndexes = hashTable[parent[i]];
                    relatedIndexes[1] = i;
                }
            }
            // no paretn value found;
            if (rootValue == -1)
            {
                return null;
            }

            return CreatePreOrderTreeHashTable(hashTable, rootValue);
        }

        private Node<int> CreatePreOrderTreeHashTable(Dictionary<int, int[]> hashTable, int rootValue)
        {
            var root = new Node<int>(rootValue);

            var isCurrentLevelValuesExists = hashTable.TryGetValue(rootValue, out int[] currentLevelValues);

            // no nodes for the curent level found
            if (!isCurrentLevelValuesExists)
            {
                return root;
            }

            // we always have left child in children list is not empty
            root.LeftChild = CreatePreOrderTreeHashTable(hashTable, currentLevelValues[0]);

            if (currentLevelValues[1] != -1)
            {
                root.RightChild = CreatePreOrderTreeHashTable(hashTable, currentLevelValues[1]);
            }
            return root;
        }        

        /// <summary>
        /// The idea just store all parent -> children in hash table and then canculate the height ofthe tree suing DFS
        /// See related geek for geeks problem
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public int CalculateTreeHeightFromParentArray(int[] parent)
        {
            var rootValue = -1;
            var hashTable = new Dictionary<int, int[]>();
            for (var i = 0; i < parent.Length; i++)
            {
                //find root value
                if (parent[i] == -1)
                {
                    rootValue = i;
                    continue;
                }

                // leftValue = i; rightValue  = -1(not exists)
                var relatedIndexes = new int[2] { i, -1 };
                // try add value
                if (!hashTable.TryAdd(parent[i], relatedIndexes))
                {
                    // we already have value for left
                    // add value for right 
                    // leftValue = parent[0]; rightValue  = parent[1] -> i
                    relatedIndexes = hashTable[parent[i]];
                    relatedIndexes[1] = i;
                }
            }
            if (rootValue == -1)
            {
                return -1;
            }

            return CalculateMaxDepth(hashTable, rootValue);
        }

        private int CalculateMaxDepth(Dictionary<int, int[]> parent, int rootValue)
        {            
            if (!parent.ContainsKey(rootValue))
            {
                // no children count current level
                return 1;
            }

            var children = parent[rootValue];

            var leftValue = children[0];
            var leftHeight = CalculateMaxDepth(parent, leftValue);

            var rightValue = children[1];
            var rightHeight = 0;
            if (rightValue != -1)
            {
                rightHeight = CalculateMaxDepth(parent, rightValue);
            }

            return Math.Max(leftHeight, rightHeight) + 1;
        }       
    }
}
