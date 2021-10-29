using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeEasy.Arrays
{
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


        public void SortColors(int[] nums)
        {
            var redCount = 0;
            var whiteCount = 0;
            var blueCount = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    redCount++;
                }
                else if (nums[i] == 1)
                {
                    whiteCount++;
                }
                else if (nums[i] == 2)
                {
                    blueCount++;
                }              

            }

            for (int i = 0; i < nums.Length;)
            {
                while (redCount != 0)
                {
                    nums[i] = 0;
                    redCount--;
                    i++;
                }
                while (whiteCount != 0)
                {
                    nums[i] = 1;
                    whiteCount--;
                    i++;
                }
                while (blueCount != 0)
                {
                    nums[i] = 2;
                    blueCount--;
                    i++;
                }
            }
        }
    }
}
