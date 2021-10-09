using AlgorithmsAndDataStructures.Trees.BST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMedium.Trees
{
    public class Solution
    {
        /// <summary>
        /// Function to construct binary tree from parent array.
        /// O(2n) + O(n + k) extra memory where k is max nodes per level
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public Node<int> CreateTreeFromParentArray(int[] parent, int N)
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


        public void LevelOrder(Node<int> root)
        {
            var queue = new Queue<Node<int>>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();
                Console.Write(currentNode.Value + " ");

                if (currentNode.LeftChild != null)
                {
                    queue.Enqueue(currentNode.LeftChild);
                }

                if (currentNode.RightChild != null)
                {
                    queue.Enqueue(currentNode.RightChild);
                }
            }
            Console.WriteLine();
        }
    }
}
