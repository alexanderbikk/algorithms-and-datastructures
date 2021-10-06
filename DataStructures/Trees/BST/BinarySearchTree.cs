using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Trees.BST
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

        public int Height(Node<T> node)
        {
            if (node == null)
            {
                return -1;
            }

            var leftHeight = Height(node.LeftChild);
            var rightHeight = Height(node.RightChild);

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        /// <summary>
        /// In-order 
        /// </summary>
        /// <param name="root"></param>
        public void PrintDpethTreeRecursive(Node<T> root)
        {
            if (root == null)
            {
                return;
            }

            PrintDpethTreeRecursive(root.LeftChild);
            Console.WriteLine($"{root.Value} ");
            PrintDpethTreeRecursive(root.RightChild);
        }

        /// <summary>
        /// Iterative
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<T> PrintDepthTree(Node<T> root)
        {
            var results = new List<T>();
            var nodes = new Stack<Node<T>>();
            var currentNode = root;

            while (nodes.Count != 0 || currentNode != null)
            {
                if (currentNode != null)
                {
                    nodes.Push(currentNode);
                    currentNode = currentNode.LeftChild;
                }
                else
                {
                    currentNode = nodes.Pop();
                    results.Add(currentNode.Value);
                    currentNode = currentNode.RightChild;
                }
            }
            return results;
        }

        /// <summary>
        /// Using Queueu
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<T> PrintBreadthTree(Node<T> root)
        {
            var results = new List<T>();
            var nodes = new Queue<Node<T>>();

            nodes.Enqueue(root);

            while (nodes.Count != 0)
            {
                var currentNode = nodes.Dequeue();
                results.Add(currentNode.Value);

                if (currentNode.LeftChild != null)
                {
                    nodes.Enqueue(currentNode.LeftChild);
                }
                if (currentNode.RightChild != null)
                {
                    nodes.Enqueue(currentNode.RightChild);
                }
            }
            return results;
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

        public bool DeleteValueRecursive(T value)
        {
            return DeleteValueRecursiveInternal(Root, null, value);
        }

        private bool DeleteValueRecursiveInternal(Node<T> node, Node<T> parentNode, T value)
        {
            if (node == null)
            {
                return false;
            }

            if (value?.CompareTo(node.Value) == 0)
            {
                // Leaf node or Node with one child
                if (node.LeftChild == null || node.RightChild == null)
                {
                    // Node with left child
                    if (node.LeftChild != null)
                    {
                        // Depends on node's value put it either to left or right substree
                        if (node.LeftChild.Value?.CompareTo(parentNode.Value) > 0)
                        {
                            parentNode.RightChild = node.LeftChild;
                        }
                        else
                        {
                            parentNode.LeftChild = node.LeftChild;
                        }
                        return true;
                    }

                    // Node with righ child
                    if (node.RightChild != null)
                    {
                        // Depends on node's value put it either to left or right substree
                        if (node.RightChild.Value?.CompareTo(parentNode.Value) > 0)
                        {
                            parentNode.RightChild = node.RightChild;
                        }
                        else
                        {
                            parentNode.LeftChild = node.RightChild;
                        }
                        return true;
                    }

                    // Leaf node
                    if (node.Value?.CompareTo(parentNode.Value) > 0)
                    {
                        parentNode.RightChild = null;
                    }
                    else
                    {
                        parentNode.LeftChild = null;
                    }
                    return true;
                }
                //Node with two children
                else
                {
                    //Find least value in the right sub-tree
                    var leastParentNode = node;
                    var leastNode = node.RightChild;                    

                    while (leastNode.LeftChild != null)
                    {
                        leastParentNode = leastNode;
                        leastNode = leastNode.LeftChild;
                    }

                    if (leastParentNode != node)
                    {
                        // we fond the least left value in the right sub-tree 
                        // and assigne it's rights value as a new left child for parent
                        // the least value itself will be swaped with value for delete and removed
                        leastParentNode.LeftChild = leastNode.RightChild;                        
                    }
                    else
                    {
                        //we don't have the left nodes in the right sub-tree, 
                        // so the least value is the right sub-tree root
                        leastParentNode.RightChild = leastNode.RightChild;
                    }                 

                    //Swap value
                    node.Value = leastNode.Value;
                    return true;
                }
            }

            return DeleteValueRecursiveInternal(node.LeftChild, node, value)
                || DeleteValueRecursiveInternal(node.RightChild, node, value);
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
