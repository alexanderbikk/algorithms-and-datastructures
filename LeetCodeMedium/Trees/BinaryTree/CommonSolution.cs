using AlgorithmsAndDataStructures.Trees.BST;

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
    }
}
