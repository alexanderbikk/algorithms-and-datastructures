using System;
using System.Collections.Generic;

namespace LeetCodeMedium.Arrays
{
    public class Solution
    {
        /// <summary>
        /// Using arrays
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int MinMeetingRooms(int[][] intervals)
        {
            var comparer = Comparer<int>.Default;
            Array.Sort(intervals, (x, y) => comparer.Compare(x[0], y[0]));

            var rooms = new List<int>(intervals.Length);

            for (var i = 0; i < intervals.Length; i++)
            {
                MoveMeetingToAvaliableRoom(rooms, intervals[i][1]);
            }

            return rooms.Count;
        }

        private void MoveMeetingToAvaliableRoom(List<int> rooms, int meetingLastTime)
        {
            for (var i = 0; i < rooms.Count; i++)
            {
                var lastMeetingTime = rooms[i];
                if (lastMeetingTime <= meetingLastTime)
                {
                    rooms[i] = meetingLastTime;
                    return;
                }
            }

            rooms.Add(meetingLastTime);
        }
    }
}
