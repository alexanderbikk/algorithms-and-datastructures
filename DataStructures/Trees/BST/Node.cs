using System;

namespace AlgorithmsAndDataStructures.Trees.BST
{
    public class Node<T>
        where T : IComparable
    {
        public T Value { get; set; }
        public Node<T> LeftChild { get; set; }
        public Node<T> RightChild { get; set; }

        public Node(T value)
        {
            Value = value;
            LeftChild = null;
            RightChild = null;
        }
    }
}
