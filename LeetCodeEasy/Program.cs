using AlgorithmsAndDataStructures.Trees;
using LeetCodeEasy.Arrays;
using LeetCodeEasy.Trees.BinaryTree;
using System;

namespace LeetCodeEasy
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Arrays();
            CommonBinaryTree();
        }

        public static void CommonBinaryTree()
        {
            var solution = new CommonSolution();
            var values = new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 };
            var root = TreeHelpers.CreateTreeFromLevelOrderArrayDFS(values, 0);
            TreeHelpers.LevelOrder(root);

            var count = 0;
            var result = solution.IsBalancedOptimized(root);
            Console.WriteLine(result);
            Console.WriteLine();

            values = new int?[] { 1, 2, 2, 3, null, null, 3, 4, null, null, null, null, null, null, 4 };
            root = TreeHelpers.CreateTreeFromLevelOrderArrayDFS(values, 0);
            TreeHelpers.LevelOrder(root);

            count = 0;
            result = solution.IsBalancedOptimized(root);
            Console.WriteLine(result);
            Console.WriteLine();


            values = new int?[] { 3, 9, 20, null, null, 15, 7 };
            root = TreeHelpers.CreateTreeFromLevelOrderArrayDFS(values, 0);
            TreeHelpers.LevelOrder(root);

            count = 0;
            result = solution.IsBalancedOptimized(root);
            Console.WriteLine(result);
            Console.WriteLine();


            values = new int?[] { 1, 2, null,3, null,null,null };
            root = TreeHelpers.CreateTreeFromLevelOrderArrayDFS(values, 0);
            TreeHelpers.LevelOrder(root);
            
            // revert tree
            root = solution.InvertTree(root);
            TreeHelpers.LevelOrder(root);

            // revert back
            root = solution.InvertTree(root);
            TreeHelpers.LevelOrder(root);

            values = new int?[] { 4,2,3,1,2,5,6 };
            root = TreeHelpers.CreateTreeFromLevelOrderArrayDFS(values, 0);
            TreeHelpers.LevelOrder(root);

            var list = solution.PreorderTraversalStack(root);

            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }

            Console.WriteLine();

            list = solution.InOrderTraversalStack(root);
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
        }

        static void Arrays()
        {
            var solution = new Solution();

            var nums = new int[] { 11, 2, 7, 15 };
            var target = 9;

            var result = solution.TwoSumUnsorted(nums, target);
            Console.WriteLine(result[0] + " " + result[1]);


            nums = new int[] { -2, -1, 0, 3, 5, 11, 12 };
            target = 9;
            result = solution.TwoSumSorted(nums, target);
            Console.WriteLine(result[0] + " " + result[1]);


            nums = new int[] { 2, 0, 1};
            solution.SortColors(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write(nums[i] + " ");
            }
        }

    }


}
