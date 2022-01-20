using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures
{
    public class Heap<T> where T : IComparable<T>
    {
        private readonly List<T> _items;

        private readonly IComparer<T> _comparer;

        public Heap(IComparer<T> comparer = null)
        {
            _items = new List<T>();
            _comparer = comparer;
        }

        public Heap(T[] items, IComparer<T> comparer = null)
        {
            _items = new List<T>(items.Length * 2);

            _items.AddRange(items);
            _comparer = comparer;
            Heapify();
        }

        public int Count => _items.Count;       

        public void Enqueue(T value)
        {
            // add new item in the end of the array -> leftmost child in the complete binary tree
            _items.Add(value);

            // restore heap properties -> put added value to the right place by comparing with parents
            ShiftUp(_items.Count - 1);
        }

        public T Peek()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("Heap is empty");
            }

            return _items[0];
        }

        public T Dequeue()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("Heap is empty");
            }

            //swap top element with last
            T value = _items[0];
            Swap(0, _items.Count - 1);

            // remove last
            // RemoveAt for last element in list will take O(1) since no merge required
            _items.RemoveAt(_items.Count - 1);

            //restore heap properies -> put current root to the right place by comparing with cildren
            ShiftDown(0);

            return value;
        }

        public void Print()
        {
            foreach (var item in _items)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        private void Heapify()
        {
            //compleat binary tree property
            var lastParentIndex = (_items.Count - 1) / 2;

            for (int i = lastParentIndex; i >= 0; i--)
            {
                ShiftDown(i);
            }
        }

        private void ShiftDown(int index)
        {
            // check heap properties untill the given item(index) is parent
            // leaf item already heapified itself
            var smallestChildIndex = index;
            while (smallestChildIndex <= (_items.Count - 1) / 2)
            {
                var leftChildIndex = GetLeftChild(smallestChildIndex);
                var rightChildIndex = GetRightChild(smallestChildIndex);             

                //if either left or right child < item (min heap properties) -> determine min existing child value and swap
                if (leftChildIndex < _items.Count && Compare(_items[leftChildIndex], _items[smallestChildIndex]) < 0)
                {
                    smallestChildIndex = leftChildIndex;
                }

                if (rightChildIndex < _items.Count && Compare(_items[rightChildIndex], _items[smallestChildIndex]) < 0)
                {
                    smallestChildIndex = rightChildIndex;
                }

                if (smallestChildIndex != index)
                {                    
                    Swap(index, smallestChildIndex);
                    index = smallestChildIndex;
                }
                else
                {
                    break;
                }
            }
        }

        private void ShiftUp(int index)
        {
            var parentIndex = GetParent(index);

            while (Compare(_items[parentIndex], _items[index]) > 0 && index > 0)
            {
                Swap(parentIndex, index);
                index = parentIndex;
                parentIndex = GetParent(index);
            }
        }

        private void Swap(int index1, int index2)
        {
            T temp = _items[index1];
            _items[index1] = _items[index2];
            _items[index2] = temp;
        }

        private int GetParent(int index) => (index - 1) / 2;

        private int GetLeftChild(int index) => index * 2 + 1;

        private int GetRightChild(int index) => index * 2 + 2;

        private int Compare(T value1, T value2)
        {
            return _comparer != null ? _comparer.Compare(value1, value2) : value1.CompareTo(value2);
        }

    }
}
