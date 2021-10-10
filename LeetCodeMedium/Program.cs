using AlgorithmsAndDataStructures.Trees.BST;
using LeetCodeMedium.Trees;
using System;

namespace LeetCodeMedium
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();


            var parentArray = new int[] { 1, 5, 5, 2, 2, -1, 3 };
            //var parentArray = new int[] { -1, 0, 0, 1, 1, 3, 5 };

            var root = solution.CreateTreeFromParentArrayBFS(parentArray, parentArray.Length);
            solution.LevelOrder(root);

            root = solution.CreateTreeFromParentArrayBFS(parentArray, parentArray.Length);
            solution.LevelOrder(root);


            var values = new int?[] { 1, 10, 12, 5, 78, 7, 15, 4, null, 3, null, 11, 8, 9, null };
            var newRoot = solution.CreatePreOrderTree(values, values[0].Value, 0);
            solution.LevelOrder(newRoot);

            root = solution.CreateTreeFromParentArraySimpleLoop(parentArray);
            solution.LevelOrder(root);


            Console.WriteLine("Tree height from parent array");
            var height = solution.CalculateTreeHeightFromParentArray(parentArray);
            Console.WriteLine(height);

            parentArray = new int[] { 1, 5, 5, 2, 2, -1, 3, 3, 4, 4,0, 0, 1, 10 };
            height = solution.CalculateTreeHeightFromParentArray(parentArray);
            Console.WriteLine(height);
        }
    }
}
