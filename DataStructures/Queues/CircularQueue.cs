using System;

namespace AlgorithmsAndDataStructures.Queues
{
    public class CircularQueue
    {
        private int _head;
        private int _tail;

        private int[] _queue;

        public int Count => _queue.Length;

        public CircularQueue(int k)
        {
            _head = -1;
            _tail = -1;

            _queue = new int[k];
        }

        public bool EnQueue(int value)
        {
            if (IsFull())
                return false;

            if (IsEmpty())
            {
                _head++;
            }

            _tail++;
            if (_tail == Count)
            {
                _tail = 0;
            }
            _queue[_tail] = value;

            return true;
        }

        public bool DeQueue()
        {
            if (IsEmpty())
                return false;

            if (_head == _tail)
            {
                _head = -1;
                _tail = -1;
                return true;
            }

            _head++;
            if (_head == Count)
            {
                _head = 0;
            }
            return true;
        }

        public int Front()
        {
            if (IsEmpty())
                return -1;

            return _queue[_head];
        }

        public int Rear()
        {
            if (IsEmpty())
                return -1;

            return _queue[_tail];
        }

        public bool IsEmpty()
        {
            return _head == -1 && _tail == -1;
        }

        public bool IsFull()
        {
            //next tail if we will add 1 element will be either +1 or 0 if tail already point to the end of the queue
            var nextTail = _tail == Count - 1 ? 0 : _tail + 1;
            
            return nextTail == _head;
        }
    }

}
