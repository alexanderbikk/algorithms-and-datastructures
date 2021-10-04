using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures.Searches
{
    public class Search
    {
        public int BinarySearch( int[] numbers, int value)
        {
            var startPos = 0;
            var lastPos = numbers.Length;

            while (startPos < lastPos)
            {
                var currentPos = (startPos + lastPos) / 2;
                if (value == numbers[currentPos])
                {
                    return currentPos;
                }

                if (value > numbers[currentPos])
                {
                    startPos = currentPos;
                }
                else
                {
                    lastPos = currentPos;
                }
            }

            return 0;
        }
    }
}
