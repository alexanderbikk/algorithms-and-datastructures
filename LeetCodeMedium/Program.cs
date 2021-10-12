using AlgorithmsAndDataStructures.Trees.BST;
using LeetCodeMedium.Trees;
using LeetCodeMedium.Trees.BinaryTree;
using System;

namespace LeetCodeMedium
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Binary Tree");
            BinaryTree();
            Console.WriteLine();

            Console.WriteLine("BST");
            BST();
            Console.WriteLine();
        }

        /// <summary>
        /// Practice with BST
        /// </summary>
        public static void BST()
        { 

        }

        /// <summary>
        /// Practice with binary tree
        /// </summary>
        public static void BinaryTree()
        {
            var solution = new Solution();

            var parentArray = new int[] { 1, 5, 5, 2, 2, -1, 3 };
            //var parentArray = new int[] { -1, 0, 0, 1, 1, 3, 5 };

            Console.WriteLine("Create tree from level order array BFS");
            var root = solution.CreateTreeFromParentArrayBFS(parentArray, parentArray.Length);
            solution.LevelOrder(root);


            Console.WriteLine("Create tree from level order array DFS");
            root = solution.CreateTreeFromParentArrayDFS(parentArray, parentArray.Length);
            solution.LevelOrder(root);

            Console.WriteLine("Create tree from level order array");
            var values = new int?[] { 1, 10, 12, 5, 78, 7, 15, 4, null, 3, null, 11, 8, 9, null };
            var newRoot = solution.CreateTreeFromLevelOrderArray(values, values[0].Value, 0);
            solution.LevelOrder(newRoot);

            Console.WriteLine("Create tree from level order array simple loop");
            root = solution.CreateTreeFromParentArraySimpleLoop(parentArray);
            solution.LevelOrder(root);


            Console.WriteLine("Tree height from parent array");
            var height = solution.CalculateTreeHeightFromParentArray(parentArray);
            Console.WriteLine(height);

            parentArray = new int[] { 1, 5, 5, 2, 2, -1, 3, 3, 4, 4, 0, 0, 1, 10 };
            height = solution.CalculateTreeHeightFromParentArray(parentArray);
            Console.WriteLine(height);
        }
    }
}
