using AlgorithmsAndDataStructures.Trees.BST;
using System;
using System.Collections.Generic;

namespace LeetCodeMedium.Trees.BST
{
    public class Solution
    {
        /// <summary>
        /// https://leetcode.com/problems/kth-smallest-element-in-a-bst/solution/
        /// Right -> Root -> Left traversal with countiong and comparision for k
        /// Stop and return when kth element found
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindMaxKthRecursive(Node<int> root, int k)
        {
            if (root == null)
            {
                // we rich the right depest node start decrease the count;
                return -1;
            }
            var count = 0;           

            return FindMaxKthRecursive(root, k, ref count);
        }

        public int FindMaxKthRecursive(Node<int> root, int k, ref int count)
        {
            if (root == null)
            {
                return -1;
            }
            var result = FindMaxKthRecursive(root.RightChild, k, ref count);

            // if we find kth element in right substree we just return it up to the stack calls to prevent traversal
            if (result != -1)
            {
                return result;
            }

            // if we not found the value in right subtree increase the count
            count++;
            Console.WriteLine(root.Value + " " + count);

            // chek if the root(current) value it target kth and return up to the stack call
            // right->root->left
            if (k == count)
            {
                return root.Value;
            }

            // if we still not found the value -> continue search in left subtree
            // we always return either -1 if not found or the target value wich was found
            return FindMaxKthRecursive(root.LeftChild, k, ref count);
        }

        public void RightRootLeft(Node<int> root, int k, ref int count, ref int target)
        {
            if (root == null || count >= k)
            {
                return;
            }

            RightRootLeft(root.RightChild, k, ref count, ref target);

            Console.WriteLine(root.Value + " " + ++count);

            if (k == count)
            {
                Console.WriteLine("Target: " + root.Value);
                target = root.Value;
            }
            RightRootLeft(root.LeftChild, k, ref count, ref target);
        }


        /// <summary>
        /// https://leetcode.com/problems/balance-a-binary-search-tree/
        /// Build sorted array from BST -> inorder traversal
        /// Build BST form result array -> find mid(root) devide array in two sub array and repeat
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node<int> BalanceBST(Node<int> root)
        {
            if (root == null)
            {
                return root;
            }

            var nodes = new List<Node<int>>();

            BSTToArray(root, nodes);

            if (nodes.Count == 1)
            {
                return nodes[0];
            }

            return BSTFromArray(nodes, 0, nodes.Count);
        }

        private void BSTToArray(Node<int> root, List<Node<int>> nodes)
        {
            if (root == null)
            {
                return;
            }

            BSTToArray(root.LeftChild, nodes);
            nodes.Add(root);
            BSTToArray(root.RightChild, nodes);
        }

        private Node<int> BSTFromArray(List<Node<int>> arrayOfNodes, int startPos, int lastPos)
        {
            // untill left or right side of the array will be processed
            // or startPos >= Count
            if (startPos > lastPos || startPos >= arrayOfNodes.Count)
            {
                return null;
            }
            var middlePos = (startPos + lastPos) / 2;
           
            var root = arrayOfNodes[middlePos];

            root.LeftChild = BSTFromArray(arrayOfNodes, startPos, middlePos - 1);
            root.RightChild = BSTFromArray(arrayOfNodes, middlePos + 1, lastPos);

            return root;
        }

    }
}
