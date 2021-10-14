using AlgorithmsAndDataStructures.Trees.BST;
using System.Collections;
using System.Collections.Generic;

namespace LeetCodeMedium.Trees.BinaryTree
{
    public class CommonSolution
    {
        /// <summary>
        /// Compare two roots and sub-trees "left right" and "right left"
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
    }
}
