using AlgorithmsAndDataStructures.Trees.BST;
using System.Collections.Generic;

namespace LeetCodeMedium.Trees.BinaryTree
{
    public class CommonSolution
    {
        /// <summary>
        /// Compare two roots and sub-trees "left right" and "right left"
        /// https://leetcode.com/problems/symmetric-tree/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsSymetricTree(Node<int> root)
        {
            if (root == null)
            {
                return false;
            }

            return IsMirror(root.LeftChild, root.RightChild);
        }

        private bool IsMirror(Node<int> rootL, Node<int> rootR)
        {
            if (rootL == null && rootR == null)
            {
                return true;
            }

            bool isRootEqual = rootL?.Value == rootR?.Value;
            if (!isRootEqual)
            {
                return false;
            }
            else
            {
                return IsMirror(rootL.LeftChild, rootR.RightChild) && IsMirror(rootL.RightChild, rootR.LeftChild);
            }
        }

        /// <summary>
        /// Iterative version using queue
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsSymetricTreeQueue(Node<int> root)
        {
            if (root == null)
            {
                return false;
            }

            var queue = new Queue<Node<int>>();

            queue.Enqueue(root.LeftChild);
            queue.Enqueue(root.RightChild);


            while (queue.Count != 0)
            {
                var rootL = queue.Dequeue();
                var rootR = queue.Dequeue();

                if (rootL == null && rootR == null)
                {
                    continue;
                }

                var isRootEquals = rootL?.Value == rootR?.Value;
                if (!isRootEquals)
                {
                    return false;
                }
                else
                {
                    queue.Enqueue(rootL.LeftChild);
                    queue.Enqueue(rootR.RightChild);

                    queue.Enqueue(rootL.RightChild);
                    queue.Enqueue(rootR.LeftChild);
                }
            }

            return true;
        }


        /// <summary>
        /// Iterative using stack
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsSymetricTreeStack(Node<int> root)
        {
            if (root == null)
            {
                return false;
            }

            var stack = new Stack<Node<int>>();


            stack.Push(root.RightChild);
            stack.Push(root.LeftChild);

            while (stack.Count != 0)
            {
                var rootL = stack.Pop();
                var rootR = stack.Pop();

                if (rootL == null && rootR == null)
                {
                    continue;
                }

                bool isRootEqual = rootL?.Value == rootR?.Value;
                if (!isRootEqual)
                {
                    return false;
                }
                else
                {
                    stack.Push(rootR.LeftChild);
                    stack.Push(rootL.RightChild);

                    stack.Push(rootR.RightChild);
                    stack.Push(rootL.LeftChild);
                }
            }

            return true;
        }


        public List<int> LeftView(Node<int> root)
        {
            var list = new List<int>();
            if (root == null)
            {
                return list;
            }

            var queue = new Queue<Node<int>>();

            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                var queueCurrentCount = queue.Count;
                for (int i = 0; i < queueCurrentCount; i++)
                {
                    var current = queue.Dequeue();
                    if (i == 0)
                    {
                        list.Add(current.Value);
                    }

                    if (current.LeftChild != null)
                    {
                        queue.Enqueue(current.LeftChild);
                    }

                    if (current.RightChild != null)
                    {
                        queue.Enqueue(current.RightChild);
                    }
                }
            }
            return list;
        }

        private int maxLevel = 0;
        private List<int> _list = new List<int>();
        public List<int> LeftViewRecursion(Node<int> root)
        {
            LeftViewRecursionInternal(root, 1);
            return _list;
        }

        public void LeftViewRecursionInternal(Node<int> root, int level)
        {
            if (root == null)
            {
                return;
            }

            if (level > maxLevel)
            {
                _list.Add(root.Value);
                maxLevel = level;
            }
            
            LeftViewRecursionInternal(root.LeftChild, level + 1);
            LeftViewRecursionInternal(root.RightChild, level + 1);            
        }

        private List<Node<int>> _nodes = new();

        /// <summary>
        /// Flatten Binary Tree to list with only right values using pre-order ordering
        /// </summary>
        /// <param name="root"></param>
        public void FlattenBinaryTree(Node<int> root)
        {
            if (root == null)
            {
                return;
            }
            PopulateLeftNodesPreOrder(root.LeftChild);
            PopulateLeftNodesPreOrder(root.RightChild);


            var current = root;
            for (int i = 0; i < _nodes.Count; i++)
            {
                current.LeftChild = null;
                current.RightChild = _nodes[i];
                current = current.RightChild;
            }
        }

        private void PopulateLeftNodesPreOrder(Node<int>  root)
        {
            if (root == null)
            {
                return;
            }

            _nodes.Add(root);
            PopulateLeftNodesPreOrder(root.LeftChild);
            PopulateLeftNodesPreOrder(root.RightChild);

        }

        
        public Node<int> TreeToDoublyList(Node<int> root)
        {
            if (root == null)
            {
                return null;
            }

            if (root.LeftChild == null && root.RightChild == null)
            {
                root.RightChild = root;
                root.LeftChild = root;
                return root;
            }

            Node<int> prev = null;
            var current = root;
                       

            while (current != null)
            {
                if (current.LeftChild == null)
                {
                    current.LeftChild = prev;
                    prev = current;
                    current = current.RightChild;
                }
                else
                {

                    var pred = current.LeftChild;
                    while (pred.RightChild != null && pred.RightChild != current)
                    {
                        pred = pred.RightChild;
                    }
                    if (pred.RightChild == null)
                    {
                        // link predcessor on top of list
                        pred.RightChild = current;
                        current = current.LeftChild;
                    }
                    else
                    {
                        //current.left = null;
                        current.LeftChild = prev;
                        prev = current;
                        current = current.RightChild;
                    }
                }
            }

            current = prev;
            while (current.LeftChild != null)
            {
                current = current.LeftChild;
            }

            root = current;

            prev.RightChild = root;
            root.LeftChild = prev;

            return root;

        }


        private Node<int> _prev = new(-1);
        private Node<int> _head = new(-1);

        public Node<int> TreeToDoublyListRecursion(Node<int> root)
        {
            if (root == null)
            {
                return null;
            }

            _prev = _head;

            TreeToDoublyListInternal(root);
            _prev.RightChild = _head.RightChild;
            _head.RightChild.LeftChild = _prev;

            return _head.RightChild;
        }

        private void TreeToDoublyListInternal(Node<int> root)
        {
            if (root == null)
            {
                return;
            }

            TreeToDoublyListInternal(root.LeftChild);

            _prev.RightChild = root;
            root.LeftChild = _prev;

            _prev = root;

            TreeToDoublyListInternal(root.RightChild);
        }
    }
}
