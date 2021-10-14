using AlgorithmsAndDataStructures.Trees;
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
            CommonBinaryTree();


            //TreeFromParentArray();
            //Console.WriteLine();

            Console.WriteLine("BST");
            BST();
            Console.WriteLine();
        }

        /// <summary>
        /// Practice with BST
        /// </summary>
        public static void BST()
        {

            var soulution = new Trees.BST.Solution();
            var values = new int?[] { 6, 4, 9, 2, 5, 8, 12, null, null, null, null, null, null, 10, 14 };
            var root = TreeHelpers.CreateTreeFromLevelOrderArrayDFS(values, 0);

            var result = soulution.FindMaxKthRecursive(root, 3);
            Console.WriteLine(result);

            Console.WriteLine();

            var count = 0;
            var target = -1;
            soulution.RightRootLeft(root, 3, ref count, ref target);
            Console.WriteLine(target);
        }

        public static void CommonBinaryTree()
        {
            var solution = new CommonSolution();
            var values = new int?[] { 1, 2, 2, 3, 4, 4, 3, 5, 6, 7, 8, 8, 7, 6, 5 };
            var root = TreeHelpers.CreateTreeFromLevelOrderArrayDFS(values, 0);
            TreeHelpers.LevelOrder(root);


            var result = solution.IsSymetricTree(root);
            Console.WriteLine(result);
            Console.WriteLine();

            values = new int?[] { 1, 2, 2, null, 3, null, 3 };

            root = TreeHelpers.CreateTreeFromLevelOrderArrayDFS(values, 0);
            TreeHelpers.LevelOrder(root);

            result = solution.IsSymetricTree(root);
            Console.WriteLine(result);
            Console.WriteLine();


            values = new int?[] { 1, 2, 2, 3, null, null, 3, 4, null, null, 4 };

            root = TreeHelpers.CreateTreeFromLevelOrderArrayDFS(values, 0);
            TreeHelpers.LevelOrder(root);
            
        }


        /// <summary>
        /// Practice with binary tree from paretn array
        /// </summary>
        public static void TreeFromParentArray()
        {
            var solution = new TreeFromParentArraySolution();

            var parentArray = new int[] { 1, 5, 5, 2, 2, -1, 3 };
            //var parentArray = new int[] { -1, 0, 0, 1, 1, 3, 5 };

            Console.WriteLine("Create tree from level order array BFS");
            var root = solution.CreateTreeFromParentArrayBFS(parentArray, parentArray.Length);
            TreeHelpers.LevelOrder(root);


            Console.WriteLine("Create tree from level order array DFS");
            root = solution.CreateTreeFromParentArrayDFS(parentArray, parentArray.Length);
            TreeHelpers.LevelOrder(root);

            Console.WriteLine("Create tree from level order array");
            var values = new int?[] { 1, 10, 12, 5, 78, 7, 15, 4, null, 3, null, 11, 8, 9, null };
            var newRoot = TreeHelpers.CreateTreeFromLevelOrderArrayDFS(values, 0);
            TreeHelpers.LevelOrder(newRoot);

            Console.WriteLine("Create tree from level order array simple loop");
            root = solution.CreateTreeFromParentArraySimpleLoop(parentArray);
            TreeHelpers.LevelOrder(root);


            Console.WriteLine("Tree height from parent array");
            var height = solution.CalculateTreeHeightFromParentArray(parentArray);
            Console.WriteLine(height);

            parentArray = new int[] { 1, 5, 5, 2, 2, -1, 3, 3, 4, 4, 0, 0, 1, 10 };
            height = solution.CalculateTreeHeightFromParentArray(parentArray);
            Console.WriteLine(height);
        }
    }
}
