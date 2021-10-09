using LeetCodeMedium.Trees;
using System;

namespace LeetCodeMedium
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            
            var parentArray = new int[] { 1, 5, 5, 2, 2, - 1, 3 };
            //var parentArray = new int[] { -1, 0, 0, 1, 1, 3, 5 };

            var root = solution.CreateTreeFromParentArray(parentArray, parentArray.Length);
            
            solution.LevelOrder(root);


        }
    }
}
