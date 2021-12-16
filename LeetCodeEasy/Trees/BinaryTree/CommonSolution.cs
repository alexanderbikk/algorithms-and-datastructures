using AlgorithmsAndDataStructures.Trees.BST;
using System;
using System.Collections.Generic;

namespace LeetCodeEasy.Trees.BinaryTree
{
    public class CommonSolution
    {
        /// <summary>
        /// Simple not effective solution T(n) = T(n/2) + O(n) -> O(nlongn) Masters theorem
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsBalanced(Node<int> root)
        {
            if (root == null)
            {
                return true;
            }

            var leftHeight = Height(root.LeftChild);
            var rightHeight = Height(root.RightChild);
            return Math.Abs(leftHeight - rightHeight) <= 1 && IsBalanced(root.LeftChild) && IsBalanced(root.RightChild);
        }

        private int Height(Node<int> root)
        {
            if (root == null)
            {
                return 0;
            }

            return Math.Max(Height(root.LeftChild), Height(root.RightChild)) + 1;
        }


        private int _height;

        /// <summary>
        /// Simple O(n) -> check each sub-tree from bottom to top
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsBalancedOptimized(Node<int> root)
        {
            if (root == null)
            {
                _height = -1;
                return true;
            }

            // check if left balanced and get leftHeight
            bool isLeftBalanced = IsBalancedOptimized(root.LeftChild);
            // if left sub-tree not balanced we don't need to continue
            if (!isLeftBalanced)
            {
                return false;
            }
            // else get HLT
            var leftHeight = _height;

            // check if rigth balanced and get rightHeigt
            bool isRightBalanced = IsBalancedOptimized(root.RightChild);
            // if right sub-tree not balanced we don't need to continue
            if (!isRightBalanced)
            {
                return false;
            }
            // else get HRT
            var rightHeight = _height;

            //calculate balance on current level since we already have left and right heights for it
            bool isSubTreeBalanced = (Math.Abs(leftHeight - rightHeight) <= 1);
            if (!isSubTreeBalanced)
            {
                // ub-tree not balanced we don't need to continue and calculate height
                return false;
            }
            else
            {
                // calculate height for the current level 
                // as we normaly do when calulating only tree height
                _height = Math.Max(leftHeight, rightHeight) + 1;
                return true;
            }
        }


        /// <summary>
        /// Just simply invert each subtree from bottom to up. Finally all tree will be inverted
        /// Same algorithm as fro ISSymetryc tree could be used see LeetCode implementation. But ref required and code more complex
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node<int> InvertTree(Node<int> root)
        {
            if (root == null)
            {
                return null;
            }

            var right = InvertTree(root.RightChild);
            var left = InvertTree(root.LeftChild);

            root.LeftChild = right;
            root.RightChild = left;

            return root;
        }

        /// <summary>
        /// Just simply envert each sub-tree from top to bottom. Finally all tree will be reverted
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node<int> InvertTreeIterative(Node<int> root)
        {
            var queue = new Queue<Node<int>>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                // invert children for current level
                var temp = current.LeftChild;
                current.LeftChild = current.RightChild;
                current.RightChild = temp;

                // enqueue children to continu traversing
                if (current.LeftChild != null)
                {
                    queue.Enqueue(current.LeftChild);
                }

                if (current.RightChild != null)
                {
                    queue.Enqueue(current.RightChild);
                }
            }
            return root;
        }


        public IList<int> PreorderTraversalStack(Node<int> root)
        {
            var nodes = new List<int>();
            if (root == null)
            {
                return nodes;
            }

            var stack = new Stack<Node<int>>();

            stack.Push(root);

            var current = root;
            while (stack.Count != 0)
            {
                current = stack.Pop();
                nodes.Add(current.Value);

                if (current.RightChild != null)
                {
                    stack.Push(current.RightChild);
                }

                if (current.LeftChild != null)
                {
                    stack.Push(current.LeftChild);
                }
            }
            return nodes;
        }

        public IList<int> InOrderTraversalStack(Node<int> root)
        {
            var nodes = new List<int>();
            if (root == null)
            {
                return nodes;
            }

            var stack = new Stack<Node<int>>();

            while (stack.Count != 0 || root != null)
            {
                if (root != null)
                {
                    stack.Push(root);
                    root = root.LeftChild;
                }
                else
                {
                    root = stack.Pop();
                    nodes.Add(root.Value);
                    root = root.RightChild;
                }
            }
            return nodes;
        }

        private List<int> _ancestors = new();

        public List<int> FindAncestorsInBST(Node<int> root, int k)
        {
            FindAncestorsInBSTInternal(root, k);
            return _ancestors;
        }

        private Node<int> FindAncestorsInBSTInternal(Node<int> root, int k)
        {
            if (root == null || root.Value == k)
            {
                return root;
            }

            Node<int> child;
            if (k < root.Value)
            {
                child = FindAncestorsInBSTInternal(root.LeftChild, k);

            }
            else
            {
                child = FindAncestorsInBSTInternal(root.RightChild, k);
            }

            if (child == null)
            {
                return null;
            }

            _ancestors.Add(root.Value);
            return root;
        }


        public List<int> FindAncestorsInBT(Node<int> root, int k)
        {
            _ = FindAncestorsInBTInternal(root, k);
            return _ancestors;
        }

        private bool FindAncestorsInBTInternal(Node<int> root, int k)
        {
            if (root == null)
            {
                return false;
            }

            if (root.Value == k)
            {
                return true;
            }

            var nodeExists = FindAncestorsInBTInternal(root.LeftChild, k) || FindAncestorsInBTInternal(root.RightChild, k);
            if (nodeExists)
            {
                _ancestors.Add(root.Value);
            }

            return nodeExists;
        }

        private Node<int> FindAncestorsInBTInternalNonOptimal(Node<int> root, int k)
        {
            if (root == null || root.Value == k)
            {
                return root;
            }


            var child = FindAncestorsInBTInternalNonOptimal(root.LeftChild, k);
            
            bool nodeExists;
            if (child != null)
            {
                nodeExists = true;
            }
            else
            {
                child = FindAncestorsInBTInternalNonOptimal(root.RightChild, k);
                nodeExists = child != null;
            }

            if (nodeExists)
            {
                _ancestors.Add(root.Value);
            }
            return root;
        }
    }
}
