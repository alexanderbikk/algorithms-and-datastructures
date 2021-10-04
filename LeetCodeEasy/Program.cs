using System;
using System.Collections.Generic;

namespace LeetCodeEasy
{
    class Program
    {
        static void Main(string[] args)
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
        }
    }

    public class Solution
    {
        /// <summary>
        /// Using hashset
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSumUnsorted(int[] nums, int target)
        {
            var hashSet = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                var result = target - nums[i];

                if (hashSet.TryGetValue(result, out int value) && value != i)
                {
                    return new int[] { value, i };
                }
                hashSet.TryAdd(nums[i], i);
            }
            return Array.Empty<int>();
        }


        /// <summary>
        /// Using Two pointers algorithm
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSumSorted(int[] numbers, int target)
        {
            var startPoint = 0;
            var endPoint = numbers.Length - 1;
            for (int i = 0; i < numbers.Length; i++)
            {
                var result = numbers[startPoint] + numbers[endPoint];

                if (result == target)
                {
                    return new int[] { startPoint + 1, endPoint + 1 };
                }

                if (result < target)
                {
                    startPoint++;
                }
                else
                {
                    endPoint--;
                }
            }
            return null;
        }
    }
}
