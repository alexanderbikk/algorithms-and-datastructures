using System.Collections.Generic;
using System.Linq;

namespace LeetCodeMedium.Heaps
{
    public class CommonSolution
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            var numsPriority = new Dictionary<int, int>();
            var minHeap = new PriorityQueue<int, int>(k);

            for (var i = 0; i < nums.Length; i++)
            {
                if (numsPriority.ContainsKey(nums[i]))
                {
                    numsPriority[nums[i]] = ++numsPriority[nums[i]];
                }
                else
                {
                    numsPriority.Add(nums[i], 1);
                }
            }

            var j = 0;
            foreach (var item in numsPriority)
            {
                var numPriority = item.Value;
                if (j < k)
                {
                    minHeap.Enqueue(item.Key, numPriority);
                }
                else
                {
                    var num = minHeap.Peek();
                    var minPriority = numsPriority[num];
                    if (numPriority > minPriority)
                    {
                        minHeap.Dequeue();
                        minHeap.Enqueue(item.Key, numPriority);
                    }
                }

                j++;
            }

            return minHeap.UnorderedItems.Select(x => x.Item1).ToArray();
        }


        public int[] TopKFrequentBucketSort(int[] nums, int k)
        {
            // create heap with count of each element
            var numPriorities = GetNumPriorities(nums);

            // create array of lists, array index - frequency count for each num
            // in num exits 3 times it should be placed in bukets[3]. 
            // so if both 1 and 2 exist 3 times it will be added in list at bukets[3] index -> {1, 2}
            var buckets = BucketSort(numPriorities, nums.Length);

            var result = PopulateTopKFrequent(buckets, k);

            return result;
        }

        private Dictionary<int, int> GetNumPriorities(int[] nums)
        {
            var numPriorities = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                if (numPriorities.ContainsKey(nums[i]))
                {
                    numPriorities[nums[i]]++;
                }
                else
                {
                    numPriorities.Add(nums[i], 1);
                }
            }

            return numPriorities;
        }

        private List<int>[] BucketSort(Dictionary<int, int> numPriorities, int length)
        {
            var buckets = new List<int>[length];

            foreach (var numPriority in numPriorities)
            {
                var priority = numPriority.Value - 1;
                if (buckets[priority] == null)
                {
                    buckets[priority] = new List<int>();
                }
                buckets[priority].Add(numPriority.Key);
            }

            return buckets;
        }

        public int[] PopulateTopKFrequent(List<int>[] buckets, int k)
        {
            var result = new int[k];
            var resultIndex = 0;

            //iterate from last bucket(since we are looking for max k)
            for (var bucketPos = buckets.Length - 1; bucketPos >= 0 && resultIndex < k; bucketPos--)
            {
                if (buckets[bucketPos] == null)
                {
                    continue;
                }
                //internalPos < k cehck required if we expect that it will be more them k elements in same bucket
                //e.g if 1,2,3 and 4 has count 3 but we need top 3 elements only
                //however this is not possible in current problem(see problem requirements)
                for (var internalPos = 0; internalPos < buckets[bucketPos].Count && internalPos < k; internalPos++)
                {
                    result[resultIndex++] = buckets[bucketPos][internalPos];
                }
            }

            return result;
        }
    }
}
