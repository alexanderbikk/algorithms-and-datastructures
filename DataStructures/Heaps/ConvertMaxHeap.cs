using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndDataStructures
{
    public class ConvertMaxHeap
    {
        private List<int> _heap;

        public string ConvertToMinHeap(List<int> maxHeap)
        {
            _heap = maxHeap;

            var lastParent = (maxHeap.Count - 1) / 2;
            for (var i = lastParent; i >= 0; i--)
            {
                Heapify(i);
            }

            return ToString();
        }

        private void Heapify(int index)
        {
            while (index <= (_heap.Count - 1) / 2)
            {
                var left = LeftChild(index);
                var right = RightChild(index);

                var minIndex = index;
                if (left < _heap.Count && _heap[minIndex] > _heap[left])
                {
                    minIndex = left;
                }

                if (right < _heap.Count && _heap[minIndex] > _heap[right])
                {
                    minIndex = right;
                }

                if (minIndex != index)
                {
                    SwapElements(index, minIndex);
                    index = minIndex;
                }
                else
                {
                    break;
                }
            }
        }

        private void SwapElements(int index1, int index2)
        {
            var temp = _heap[index1];
            _heap[index1] = _heap[index2];
            _heap[index2] = temp;
        }

        private static int LeftChild(int index) => 2 * index + 1;

        private static int RightChild(int index) => 2 * index + 2;

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < _heap.Count; i++)
            {
                sb.Append($"{_heap[i]},");
            }

            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
    }
}
