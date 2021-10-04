using AlgorithmsAndDataStructures.Searches;
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

            SumInTree();
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

            return InOrderTree(root, k, hasSet);
        }
        public static bool InOrderTree(Node<int> root, int k, Dictionary<int, int> hasSet)
        {
            var result = k - root.Value;
            if (hasSet.TryGetValue(result, out int _))
            {
                return true;
            }
            else
            {
                hasSet.TryAdd(root.Value, root.Value);
            }

            bool isSumExists = false;

            if (root.LeftChild != null && !isSumExists)
            {
                isSumExists = InOrderTree(root.LeftChild, k, hasSet);
            }

            if (root.RightChild != null && !isSumExists)
            {
                isSumExists = InOrderTree(root.RightChild, k, hasSet); ;
            }
            return isSumExists;
        }
    }
}
