using AlgorithmsAndDataStructures.Searches;
using AlgorithmsAndDataStructures.Trees;
using AlgorithmsAndDataStructures.Trees.AVL;
using AlgorithmsAndDataStructures.Trees.BST;
using System;
using System.Collections.Generic;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            //ShowBSTTree();
            //ShowSearches();

            //SumInTree();
            AVLTree();
        }

        public static void ShowBSTTree()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("-------BST Tree---------");
            Console.WriteLine("------------------------");
            Console.WriteLine();

            Console.WriteLine("-------Init and Insert---------");
            Console.WriteLine();

            var binarySearchTreee = new BinarySearchTree<int>(13);
            binarySearchTreee.InsertValueRecursive(4);
            binarySearchTreee.InsertValueRecursive(7);
            binarySearchTreee.InsertValueRecursive(16);
            binarySearchTreee.InsertValueRecursive(19);
            binarySearchTreee.InsertValueRecursive(15);
            binarySearchTreee.InsertValueRecursive(17);
            binarySearchTreee.InsertValueRecursive(18);
            binarySearchTreee.InsertValueRecursive(3);
            binarySearchTreee.InsertValueRecursive(1);
            binarySearchTreee.InsertValueRecursive(9);
            binarySearchTreee.InsertValueRecursive(2);

            Console.WriteLine("-------Print Depth First Recurive---------");
            Console.WriteLine();

            binarySearchTreee.PrintDpethTreeRecursive(binarySearchTreee.Root);

            Console.WriteLine("-------Print Depth First Iterative Stack---------");
            Console.WriteLine();

            var result = binarySearchTreee.PrintDepthTree(binarySearchTreee.Root);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------Print Breadth First Iterative Queueu---------");
            Console.WriteLine();
            result = binarySearchTreee.PrintBreadthTree(binarySearchTreee.Root);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------Search---------");
            Console.WriteLine();

            var value = 4;
            var resultNode = binarySearchTreee.SearchRecursive(binarySearchTreee.Root, value);
            if (resultNode != null)
            {
                Console.WriteLine($"Result node {resultNode.Value}");
            }
            else
            {
                Console.WriteLine($"Node with value {value} not found.");
            }


            Console.WriteLine("-------Height---------");
            var height = binarySearchTreee.Height(binarySearchTreee.Root);
            Console.WriteLine(height);

            // TODO: it will be greate to creta a tests with all delete cases or improve samples here 1 tree for each case
            // rather then just use one tree for all
            Console.WriteLine("-------Delete---------");
            
            Console.WriteLine($"Delete when not exists {12}");
            bool deleteResult = binarySearchTreee.DeleteValueRecursive(12);
            Console.WriteLine(deleteResult);

            Console.WriteLine($"Delete when exists {4}");
            deleteResult = binarySearchTreee.DeleteValueRecursive( 4);
            Console.WriteLine(deleteResult);
            binarySearchTreee.PrintDpethTreeRecursive(binarySearchTreee.Root);


            binarySearchTreee.InsertValueRecursive(4);
            Console.WriteLine($"Delete when exists {16}");
            deleteResult = binarySearchTreee.DeleteValueRecursive(16);
            Console.WriteLine(deleteResult);

            binarySearchTreee.PrintDpethTreeRecursive(binarySearchTreee.Root);
        }

        public static void ShowSearches()
        {
            Console.WriteLine();
            Console.WriteLine("------------------------");
            Console.WriteLine("-------Searches---------");
            Console.WriteLine("------------------------");
            Console.WriteLine();


            var search = new Search();
            var sortedArray = new int[] { 1, 2, 4, 7, 10, 12, 19, 20, 43, 55 };

            Console.WriteLine("-------Test Array---------");
            Console.WriteLine();
            foreach (var item in sortedArray)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine("-------Binary Search---------");
            Console.WriteLine();

            var target = 43;
            var pos = search.BinarySearch(sortedArray, target);

            Console.WriteLine($"Trget {target} Result position {pos}");

            target = 2;
            pos = search.BinarySearch(sortedArray, target);

            Console.WriteLine($"Trget {target} Result position {pos}");
        }




        public static void AVLTree()
        {
            var avlTree = new AVLTree(20);
            avlTree.InsertValue(10);
            avlTree.InsertValue(25);
            avlTree.InsertValue(15);
            avlTree.InsertValue(9);
            avlTree.InsertValue(22);
            avlTree.InsertValue(30);

            avlTree.PrintInOrder(avlTree.Root);
            Console.WriteLine();
            Console.WriteLine();

            TreeHelpers.LevelOrder(avlTree.Root);

        }

        /// <summary>
        /// TODO move to LeetCode easy and use tree structure there
        /// </summary>
        public static void SumInTree()
        {
            var binarySearchTreee = new BinarySearchTree<int>(2);
            binarySearchTreee.InsertValueRecursive(1);            
            binarySearchTreee.InsertValueRecursive(3);
            //binarySearchTreee.InsertValueRecursive(2);
            //binarySearchTreee.InsertValueRecursive(4);
            //binarySearchTreee.InsertValueRecursive(7);           
            var target = 3;
            var result = FindTarget(binarySearchTreee.Root, target);

            Console.WriteLine(result);
        }

        public static bool FindTarget(Node<int> root, int k)
        {
            var hasSet = new Dictionary<int, int>();

            return PreOrderTree(root, k, hasSet);
        }
        public static bool PreOrderTree(Node<int> root, int k, Dictionary<int, int> hasSet)
        {
            if (root == null)
            {
                return false;
            }

            var result = k - root.Value;
            if (hasSet.ContainsKey(result))
            {
                return true;
            }
            else
            {
                hasSet.Add(root.Value, root.Value);
            }

            bool isSumExists = PreOrderTree(root.LeftChild, k, hasSet);

            // if we node found for the root + left
            // retrun result for the root + right
            if (!isSumExists)
            {
                isSumExists = PreOrderTree(root.RightChild, k, hasSet);
            }
            return isSumExists;
        }
    }
}
