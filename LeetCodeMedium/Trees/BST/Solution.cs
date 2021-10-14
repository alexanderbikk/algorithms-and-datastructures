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
                return -1;
            }
            var result = FindMaxKthRecursive(root.RightChild, k, ref count, ref target);

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
            return FindMaxKthRecursive(root.LeftChild, k, ref count, ref target);
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
       
    }
}
