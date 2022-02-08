namespace LyftLeetCode.Heaps;


public class Solution
{
    public TaxiSchedulingSolution TaxiScheduling { get; init; }

    public MeetingRoomsSolution MeetingRoomsAdjusted { get; init; }

    public Solution()
    {
        TaxiScheduling = new TaxiSchedulingSolution();
        MeetingRoomsAdjusted = new MeetingRoomsSolution();
    }

    public class TaxiSchedulingSolution
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
                var tripInfo = new int[] { cabTravelTime[i], cabTravelTime[i] };
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

    public class MeetingRoomsSolution
    {

        public class RoomComparer : IComparer<int[]>
        {
            public int Compare(int[]? x, int[]? y)
            {
                return x![1] == y![1] ? x[0] - y[0] : x[1] - y[1];
            }
        }

        public int[][] MinMeetingRooms(int[][] intervals)
        {
            int[][] resultRooms = new int[intervals.Length][];

            var comparer = Comparer<int>.Default;
            Array.Sort(intervals, (x, y) =>  comparer.Compare(x[0], y[0]));

            var meetings = new PriorityQueue<int[], int[]>(intervals.Length, new RoomComparer());

            for (var i = 0; i < intervals.Length; i++)
            {
                var roomNumber = ScheduleMeetingInAvaliableRoom(meetings, (intervals[i][0], intervals[i][1]));
                UpdateResultRooms(resultRooms, i, roomNumber);
            }

            return resultRooms;
        }

        private int ScheduleMeetingInAvaliableRoom(PriorityQueue<int[], int[]> meetings, (int startTime, int endTime) interval)
        {
            var roomNumber = 0;
            if (meetings.Count == 0)
            {
                var room = new int[] { roomNumber, interval.endTime };
                meetings.Enqueue(room, room);
                return roomNumber;
            }

            var roomInfo = meetings.Peek();
            roomNumber = roomInfo[0];
            var lastAvaliableRoomTime = roomInfo[1];          

            if (lastAvaliableRoomTime <= interval.startTime)
            {
                meetings.Dequeue();              
            }
            else
            {
                roomNumber = meetings.Count;
            }
            

            meetings.Enqueue(new int[] { roomNumber, interval.endTime }, new int[] { roomNumber, interval.endTime });
            return roomNumber;
        }

        private void UpdateResultRooms(int[][] rooms, int meetingIndex, int roomNumber)
        {
            rooms[meetingIndex] = new int[] { meetingIndex, roomNumber };
        }
    }
}


