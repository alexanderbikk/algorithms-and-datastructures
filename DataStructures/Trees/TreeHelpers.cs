using AlgorithmsAndDataStructures.Trees.AVL;
using AlgorithmsAndDataStructures.Trees.BST;
using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Trees
{
    public static class TreeHelpers
    {
        public static Node<int> CreateTreeFromLevelOrderArrayDFS(int?[] values, int parentIndex)
        {
            // no more nodes to add or current node is null
            if (parentIndex >= values.Length || values[parentIndex] == null)
            {
                return null;
            }

            var root = new Node<int>(values[parentIndex].Value);

            var leftIndex = 2 * parentIndex + 1;
            root.LeftChild = CreateTreeFromLevelOrderArrayDFS(values, leftIndex);

            var rightIndex = 2 * parentIndex + 2;
            root.RightChild = CreateTreeFromLevelOrderArrayDFS(values, rightIndex);

            return root;
        }

        public static Node<int> BstFromPreorder(int?[] values)
        {
            if (values == null || values.Length == 0)
            {
                return null;
            }

            var queue = new Queue<Node<int>>();
            var root = new Node<int>(values[0].Value);
            queue.Enqueue(root);

            var i = 1;
            while (queue.Count != 0 || i < values.Length)
            {
                var node = queue.Dequeue();
                if (values[i].HasValue)
                {
                    node.LeftChild = new Node<int>(values[i].Value);
                    queue.Enqueue(node.LeftChild);
                }
                i++;

                if (i >= values.Length)
                {
                    break;
                }

                if (values[i] != null)
                {
                    node.RightChild = new Node<int>(values[i].Value);
                    queue.Enqueue(node.RightChild);
                }
                i++;
            }

            return root;
        }

        public static void  LevelOrder(Node<int> root)
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

        public static void LevelOrder(AVLNode root)
        {
            var queue = new Queue<AVLNode>();
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
