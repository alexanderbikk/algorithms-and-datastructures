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

            var benarySearchTreee = new BinarySearchTree<int>(13);
            benarySearchTreee.InsertValueRecursive(4);
            benarySearchTreee.InsertValueRecursive(7);
            benarySearchTreee.InsertValueRecursive(16);
            benarySearchTreee.InsertValueRecursive(19);
            benarySearchTreee.InsertValueRecursive(3);
            benarySearchTreee.InsertValueRecursive(1);
            benarySearchTreee.InsertValueRecursive(9);
            benarySearchTreee.InsertValueRecursive(2);

            Console.WriteLine("-------Print---------");
            Console.WriteLine();

            benarySearchTreee.PrintTree(benarySearchTreee.Root);

            Console.WriteLine("-------Search---------");
            Console.WriteLine();

            var value = 4;
            var resultNode = benarySearchTreee.SearchRecursive(benarySearchTreee.Root, value);
            if (resultNode != null)
            {                
                Console.WriteLine($"Result node {resultNode.Value}");            
            }
            else
            {
                Console.WriteLine($"Node with value {value} not found.");
            }
        }
    }
}
