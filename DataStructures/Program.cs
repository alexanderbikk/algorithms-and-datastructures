using DataStructures.Trees.BST;
using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
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
    }
}
