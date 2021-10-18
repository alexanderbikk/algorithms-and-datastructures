using System;

namespace AlgorithmsAndDataStructures.Trees.AVL
{
    public class AVLTree
    {
        public AVLNode Root { get; private set; }

        public int MyProperty { get; set; }

        public AVLTree(int value)
        {
            Root = new AVLNode(value);
        }

        public AVLTree(AVLNode root)
        {
            Root = root;
        }

        public void InsertValue(int value)
        {
            InsertValueInternal(Root, value);
        }

        public AVLNode InsertValueInternal(AVLNode root, int value)
        {
            if (root == null)
            {
                return new AVLNode(value);
            }

            if (value > root.Value)
            {
                root.RightChild = InsertValueInternal(root.RightChild, value);
            }
            else
            {
                root.LeftChild = InsertValueInternal(root.LeftChild, value);
            }

            return root;
        }

        public void PrintInOrder(AVLNode root)
        {
            if (root == null)
            {
                return;
            }

            PrintInOrder(root.LeftChild);
            Console.Write(root.Value + " ");
            PrintInOrder(root.RightChild);
        }
    }
}
