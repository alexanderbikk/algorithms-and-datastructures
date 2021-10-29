using AlgorithmsAndDataStructures.Trees.BST;
using System.Collections.Generic;

namespace LeetCodeMedium.Trees.BinaryTree
{
    public class CBTInserter
    {
        private Node<int> _root;
        private Queue<Node<int>> _treeQueue = new();

        public CBTInserter(Node<int> root)
        {
            _root = root;
            BuildQueueFromLevelOrder();
        }

        public int Insert(int val)
        {            
            var parent = _treeQueue.Peek();
            var newNode = new Node<int>(val);

            if (parent.LeftChild == null)
            {
                // insert to left sub-tree and kep parent in queue
                // since next avaliable place is parent's right sub-tree
                parent.LeftChild = newNode;
            }
            else
            {
                // insert to rigth sub-tree and remove parent since it's gully completed
                parent.RightChild = newNode;
                _treeQueue.Dequeue();
            }

            // put new node in queue since it will be the next parent when the curent leaf level will be fully completed
            _treeQueue.Enqueue(newNode);

            return parent.Value;
        }

        public Node<int> Get_root()
        {
            return _root;
        }


        private void BuildQueueFromLevelOrder()
        {
            if (_root == null)
            {
                return;
            }

            _treeQueue.Enqueue(_root);
            Node<int> current = null;

            while (_treeQueue.Count != 0)
            {
                // peek to chek is it last level where not all children completed
                current = _treeQueue.Peek();                

                // put in queue nodes untile leaf level is reached e.g. left or right child is null
                // if left child is empty stop - parent level olready in queue

                if (current.LeftChild == null)
                {
                    break;
                }
                _treeQueue.Enqueue(current.LeftChild);

                // if right child is empty stop - parent level olready in queue
                if (current.RightChild == null)
                {
                    break;
                }
                _treeQueue.Enqueue(current.RightChild);

                // full node we can continue traversing            
                _treeQueue.Dequeue();          
            }
        }
    }
}
