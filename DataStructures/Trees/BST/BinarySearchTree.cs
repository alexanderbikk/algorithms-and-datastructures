using System;

namespace DataStructures.Trees.BST
{
    public class BinarySearchTree<T>
        where T : IComparable
    {
        public Node<T> Root { get; private set; }

        public BinarySearchTree(T rootValue)
        {
            Root = new Node<T>(rootValue);
        }

        public BinarySearchTree(Node<T> root)
        {
            Root = root;
        }

        public void PrintTree(Node<T> root)
        {
            if (root == null)
            {
                return;
            }
            PrintTree(root.LeftChild);
            Console.WriteLine($"{root.Value} ");
            PrintTree(root.RightChild);
        }

        /// <summary>
        /// Iterative
        /// </summary>
        /// <param name="value"></param>
        public void InsertValue(T value)
        {
            var currentNode = Root;
            var parentNode = Root;

            while (currentNode != null)
            {
                parentNode = currentNode;
                if (value?.CompareTo(currentNode.Value) > 0)
                {
                    currentNode = parentNode.RightChild;
                }
                else
                {
                    currentNode = parentNode.LeftChild;
                }
            }
            if (value?.CompareTo(parentNode.Value) > 0)
            {
                parentNode.RightChild = new Node<T>(value);
            }
            else
            {
                parentNode.LeftChild = new Node<T>(value);
            }
        }

        /// <summary>
        /// Recursive
        /// </summary>
        /// <param name="value"></param>
        public void InsertValueRecursive(T value)
        {
            if (Root == null)
            {
                Root = new Node<T>(value);
                return;
            }

            InsertValueRecursiveInternal(Root, value);
        }

        private void InsertValueRecursiveInternal(Node<T> currentNode, T value)
        {
            if (value?.CompareTo(currentNode.Value) > 0)
            {
                if (currentNode.RightChild != null)
                {
                    InsertValueRecursiveInternal(currentNode.RightChild, value);
                }
                else
                {
                    currentNode.RightChild = new Node<T>(value);
                    return;
                }
            }
            else
            {
                if (currentNode.LeftChild != null)
                {
                    InsertValueRecursiveInternal(currentNode.LeftChild, value);
                }
                else
                {
                    currentNode.LeftChild = new Node<T>(value);
                    return;
                }
            }
        }


        /// <summary>
        /// Iterative
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Node<T> Search(T value)
        {
            var currentNode = Root;

            while (currentNode != null && value?.CompareTo(currentNode.Value) != 0)
            {
                if (value?.CompareTo(currentNode.Value) < 0)
                {
                    currentNode = currentNode.LeftChild;
                }
                else
                {
                    currentNode = currentNode.RightChild;
                }
            }
            return currentNode;
        }

        public Node<T> SearchRecursive(Node<T> currentNode, T value)
        {            
            if (currentNode == null || value?.CompareTo(currentNode.Value) == 0)
            {
                return currentNode;
            }

            if (value?.CompareTo(currentNode.Value) < 0)
            {
                return SearchRecursive(currentNode.LeftChild, value);
            }
            else
            {
                return SearchRecursive(currentNode.RightChild, value);
            }
        }
    }
}
