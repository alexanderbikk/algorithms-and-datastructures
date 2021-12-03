using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures.LinkedList
{
    public class MyLinkedList
    {

        private DoublyListNode _head;

        public bool IsEmpty => _head == null;

        public MyLinkedList()
        {
            _head = null;
        }

        public int Get(int index)
        {
            var node = GetNode(index);
            return node != null ? node.val : -1;
        }

        public DoublyListNode GetNode(int index)
        {
            if (IsEmpty)
            {
                return null;
            }

            var temp = _head;
            var i = 0;
            while (temp != null)
            {
                if (i == index)
                {
                    return temp;
                }
                i++;
                temp = temp.next;
            }
            return null;
        }



        public void AddAtHead(int val)
        {
            var newNode = new DoublyListNode(val);
            if (IsEmpty)
            {
                _head = newNode;
                return;
            }

            newNode.next = _head;
            _head.prev = newNode;
            _head = newNode;
        }

        public void AddAtTail(int val)
        {
            if (IsEmpty)
            {
                AddAtHead(val);
                return;
            }

            var temp = _head;
            while (temp.next != null)
            {
                temp = temp.next;
            }

            var newNode = new DoublyListNode(val);
            temp.next = newNode;
            newNode.prev = temp;
        }

        public void AddAtIndex(int index, int val)
        {
            if (index == 0)
            {
                AddAtHead(val);
            }

            var node = GetNode(index - 1);

            // no such index found
            if (node == null)
            {
                return;
            }
            var newNode = new DoublyListNode(val);

            // add at tail
            if (node.next == null)
            {
                node.next = newNode;
                newNode.prev = node;
                return;
            }

            //add in the middle
            newNode.prev = node;
            newNode.next = node.next;

            node.next.prev = newNode;
            node.next = newNode;
        }

        public void DeleteAtIndex(int index)
        {
            if (IsEmpty)
            {
                return;
            }

            var node = GetNode(index);

            // no such index found
            if (node == null)
            {
                return;
            }

            //delete at head
            if (node == _head)
            {
                if (_head.next == null)
                {
                    _head = null;
                    return;
                }
                _head.next.prev = null;
                _head = _head.next;
                return;
            }

            //delete at tail
            if (node.next == null)
            {
                node.prev.next = null;
                return;
            }

            //delete in the middle
            node.prev.next = node.next;
            node.next.prev = node.prev;

        }

    }

    public class DoublyListNode
    {
        public int val;
        public DoublyListNode prev;
        public DoublyListNode next;

        public DoublyListNode(int value, DoublyListNode prev = null, DoublyListNode next = null)
        {
            this.val = value;
            this.prev = prev;
            this.next = next;
        }
    }
}
