using AlgorithmsAndDataStructures.Trees.BST;

namespace AlgorithmsAndDataStructures.Trees.AVL
{
    public class AVLNode 
    {
        public int Value { get; set; }
        public AVLNode LeftChild { get; set; }
        public AVLNode RightChild { get; set; }

        public AVLNode(int value)
        {
            Value = value;
            LeftChild = null;
            RightChild = null;
        }
    }
}
