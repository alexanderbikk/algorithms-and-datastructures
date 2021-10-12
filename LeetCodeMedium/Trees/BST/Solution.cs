using AlgorithmsAndDataStructures.Trees.BST;
using System;

namespace LeetCodeMedium.Trees.BST
{
    public class Solution
    {
        public int FindMaxKthRecursive(Node<int> root, int k)
        {
            if (root == null)
            {
                // we rich the right depest node start decrease the count;
                return -1;
            }
            var count = 0;
            var target = -1;            

            return FindMaxKthRecursive(root, k, ref count, ref target);
        }

        public int FindMaxKthRecursive(Node<int> root, int k, ref int count, ref int target)
        {            
            if (root == null)
            {                
                return - 1;
            }
            var result = FindMaxKthRecursive(root.RightChild, k, ref count, ref target);
            
            // start count from the first latest right node and untill we found the kth element
            // right -> root -> left
            if (k != count)
            {
                count++;
                Console.WriteLine(root.Value + " " + count);
                result = root.Value;
            }

            // we count right subtree - check if we reach the kth element 
            // if so return the element or continue search in left subtree
            // right->root->left
            if (k == count)
            {               
                target = result;
                return result;
            }
            else
            {               
                return FindMaxKthRecursive(root.LeftChild, k, ref count, ref target);
            }

        }

        public void RightRootLeft(Node<int> root, int k, ref int count, ref int target)
        {
            if (root == null)
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

        public Node<int> CreateTreeFromLevelOrderArray(int?[] values, int parentIndex)
        {
            // no more nodes to add or current node is null
            if (parentIndex >= values.Length || values[parentIndex] == null)
            {
                return null;
            }

            var root = new Node<int>(values[parentIndex].Value);

            var leftIndex = 2 * parentIndex + 1;
            root.LeftChild = CreateTreeFromLevelOrderArray(values, leftIndex);

            var rightIndex = 2 * parentIndex + 2;
            root.RightChild = CreateTreeFromLevelOrderArray(values, rightIndex);

            return root;
        }
    }
}
