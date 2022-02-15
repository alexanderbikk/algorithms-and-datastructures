using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMedium.Heaps
{
    public class MedianFinder
    {
        private readonly List<int> _data = new List<int>();

        public bool IsOdd => _data.Count % 2 != 0;

        public MedianFinder()
        {

        }

        public void AddNum(int num)
        {
            if (_data.Count == 0)
            {
                _data.Add(num);
            }
            else
            {               
                var pos = FindPos(num);
                _data.Insert(pos, num);
            }
        }

        private int FindPos(int num)
        {
            var startPos = 0;
            var lastPos = _data.Count - 1;

            while (startPos <= lastPos)
            {
                var midPos = (startPos + lastPos) / 2;
               
                if (num >= _data[midPos])
                {
                    startPos = midPos + 1;
                }
                else
                {
                    lastPos = midPos - 1;
                }
            }
            return startPos;
        }

        public double FindMedian()
        {
            var midPos = _data.Count / 2;
            if (IsOdd)
            {
                return _data[midPos];
            }
            else
            {
                return (_data[midPos] + _data[midPos - 1]) / 2.0;
            }
        }
    }

}
