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
            Root = InsertValueInternal(Root, value);
        }

        private AVLNode InsertValueInternal(AVLNode root, int value)
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

            root.Height = CalculateHeight(root.LeftChild, root.RightChild);

            var balanceFactor = GetBalanceFactor(root);

            if (balanceFactor > 1)
            {
                //left heavy
                if (value > root.LeftChild.Value)
                {
                    Console.WriteLine("Left heavy. Left Right case");
                    return RotateLeftRight(root);
                }
                else
                {
                    Console.WriteLine("Left heavy. Left Left case");
                    return RotateRight(root);
                }
            }
            else if (balanceFactor < -1)
            {
                //right heavy                
                if (value > root.RightChild.Value)
                {
                    Console.WriteLine("Right heavy. Right  Right case");
                    return RotateLeft(root);
                }
                else
                {
                    Console.WriteLine("Right heavy. Rgiht Left case");
                    return RotateRightLeft(root);
                }
            }

            return root;
        }

        public void DeleteValue(int value)
        {
            Root = DeleteValueInternal(Root, value);
        }

        private AVLNode DeleteValueInternal(AVLNode root, int value)
        {
            if (root == null)
            {
                return root;
            }

            if (value > root.Value)
            {
                root.RightChild = DeleteValueInternal(root.RightChild, value);
            }
            else if (value < root.Value)
            {
                root.LeftChild = DeleteValueInternal(root.LeftChild, value);
            }
            else
            {
                //we found the value for deletion
                if (root.LeftChild == null && root.RightChild == null)
                {
                    //leaf node just delete it
                    return null;
                }
                else if (root.LeftChild == null)
                {
                    // ahs only right child
                    root = root.RightChild;
                }
                else if (root.RightChild == null)
                {
                    //has only right child
                    root = root.LeftChild;
                }
                else
                {
                    //has both children                    
                    var leastRightNode = root.RightChild;

                    // find lease left node in right sub-tree
                    while (leastRightNode.LeftChild != null)
                    {                        
                        leastRightNode = leastRightNode.LeftChild;
                    }

                    // replace with least value in right-subtree 
                    root.Value = leastRightNode.Value;
                    // call to delete least child in right-subtree and recalculate hights for all ancestors
                    root.RightChild = DeleteValueInternal(root.RightChild, leastRightNode.Value);                    
                }
            }

            // calculate height and balance factor
            root.Height = CalculateHeight(root.LeftChild, root.RightChild);

            var balanceFactor = GetBalanceFactor(root);

            // left heavy -> right rotations
            if (balanceFactor > 1 && GetBalanceFactor(root.LeftChild) >= 0)
            {
                //R0 & R1 rotations
                return RotateRight(root);
            }

            if (balanceFactor > 1 && GetBalanceFactor(root.LeftChild) < 0)
            {
                //R-1 rotation
                return RotateLeftRight(root);
            }

            // right heavy -> left rotations
            if (balanceFactor < -1 && GetBalanceFactor(root.RightChild) <= 0)
            {
                //L0 & L-1 rotations
                return RotateLeft(root);
            }
            if (balanceFactor < -1 && GetBalanceFactor(root.RightChild) > 0)
            {
                //L1 rotations
                return RotateRightLeft(root);                
            }

            return root; 
        }

        private int GetHeight(AVLNode node)
        {
            if (node == null)
            {
                return -1;
            }
            return node.Height;
        }

        private int CalculateHeight(AVLNode left, AVLNode right)
        {
            return Math.Max(GetHeight(left), GetHeight(right)) + 1;
        }

        private int GetBalanceFactor(AVLNode node)
        {
            if (node == null)
            {
                return 0;
            }
            return GetHeight(node.LeftChild) - GetHeight(node.RightChild);
        }

        /// <summary>
        /// When left heavy
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private AVLNode RotateRight(AVLNode node)
        {
            var nodeToRotate = node.LeftChild;
            node.LeftChild = nodeToRotate.RightChild;
            nodeToRotate.RightChild = node;

            // calculate height after rotation
            node.Height = CalculateHeight(node.LeftChild, node.RightChild);
            nodeToRotate.Height = CalculateHeight(nodeToRotate.LeftChild, nodeToRotate.RightChild);
            return nodeToRotate;
        }

        /// <summary>
        /// When right heavy
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private AVLNode RotateLeft(AVLNode node)
        {
            var nodeToRotate = node.RightChild;
            node.RightChild = nodeToRotate.LeftChild;
            nodeToRotate.LeftChild = node;

            // calculate height after rotation
            node.Height = CalculateHeight(node.LeftChild, node.RightChild);
            nodeToRotate.Height = CalculateHeight(nodeToRotate.LeftChild, nodeToRotate.RightChild);
            return nodeToRotate;
        }

        /// <summary>
        /// Simple Left + Right rotation
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private AVLNode RotateLeftRight(AVLNode node)
        {
            // do simple left rotation for C and G
            node.LeftChild = RotateLeft(node.LeftChild);

            // do simple right rotation for U and G
            return RotateRight(node);
        }

        /// <summary>
        /// Simple Right + Left rotation
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private AVLNode RotateRightLeft(AVLNode node)
        {
            // do simple left rotation for C and G
            node.RightChild = RotateRight(node.RightChild);

            // do simple right rotation for U and G
            return RotateLeft(node);
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
