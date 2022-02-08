using System.Collections;

namespace LyftLeetCode.Heaps;


public class Solution
{
    public class TaxiTimeCostsComparer : IComparer<int[]>
    {
        /// Ideally we shouldn't care about sorting when different tripTimes have the same tripCosts. Since we don't care wich car do the trip when the tripCosts the same
        /// So only tripCosts should be sorted
        public int Compare(int[]? x, int[]? y)
        {
            return x![1] - y![1];
        }
    }

    /// <summary>
    /// https://leetcode.com/discuss/interview-question/1189312/Lyft-Taxi-Scheduling
    /// Ideally we shouldn't care about sorting when different tripTimes have the same tripCosts. Since we don't care wich car do the trip when the tripCosts the same    
    /// It was sorted in leetcode example.
    /// </summary>
    /// <returns></returns>
    public int TaxiScheduling(int n, int[] cabTravelTime)
    {      
        var minHeap = new PriorityQueue<int[], int[]>(cabTravelTime.Length, new TaxiTimeCostsComparer());

        //put init cost in min heap. So the lowest time cost taxi will be on top of the heap.
        //e.g [3, 1, 4] -> [{1, 1}; {3, 3}; {4, 4};]
        for (var i = 0; i < cabTravelTime.Length; i++)
        {
            // tripInfo -> {tripCost, totalTripCost}. initially it will be the same values
            var tripInfo = new int[] {cabTravelTime[i], cabTravelTime[i]};
            //since we can't get TPriority when Dequeue .net PriorityQueue we should store info in TElement as well.
            minHeap.Enqueue(tripInfo, tripInfo);
        }

        var minTime = 0;
        // until we don't make all trips
        while (n != 0)
        {
            //get trip info
            var tripInfo = minHeap.Dequeue();
            var tripCost = tripInfo[0];
            var totalTripCost = tripInfo[1];
            
            minTime = totalTripCost;

            totalTripCost += tripCost;
            tripInfo[1] = totalTripCost;

            //return tripInfo bavk with updated totalTripCost
            // so we know the next trip will be again the lowest cost since we always compare by totalTripCost(see minheap comparer)
            minHeap.Enqueue(tripInfo, tripInfo);
            n--;
        }

        return minTime;
    }
}


