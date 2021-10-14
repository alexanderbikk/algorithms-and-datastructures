using AlgorithmsAndDataStructures.Trees.BST;
using System;

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
    }
}
