using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.LinkedList
{
    public class LinkedList
    {
        private Node _head;
        public Node Head => _head;
        public bool IsEmpty => Head == null;

        public LinkedList()
        {
            _head = null;
        }

        public void InsertAtHead(int value)
        {
            var newNode = new Node(value);
            newNode.Next = _head;
            _head = newNode;
        }

        public void InsertAtHead(Node newNode)
        {
            newNode.Next = _head;
            _head = newNode;
        }

        public void InsertAtTail(int value)
        {
            var newNode = new Node(value);

            if (IsEmpty)
            {
                _head = newNode;
                return;
            }
            var temp = _head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = newNode;
        }

        public void InsertAfter(Node node, int value)
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("List is empty");
            }

            var temp = _head;
            while (temp != node)
            {
                temp = temp.Next;
            }

            var newNode = new Node(value);
            var tempNext = temp.Next;
            temp.Next = newNode;
            newNode.Next = tempNext;
        }

        public bool Search(int value)
        {
            if (IsEmpty)
            {
                return false;
            }

            var temp = _head;
            while (temp != null && temp.Value != value)
            {
                temp = temp.Next;
            }

            return temp != null;
        }

        public void Delete(int value)
        {
            if (IsEmpty)
            {
                return;
            }

            if (_head.Value == value)
            {
                _head = null;
                return;
            }

            var tempPrev = _head;
            var temp = _head.Next;

            while (temp != null && temp.Value != value)
            {
                tempPrev = temp;
                temp = temp.Next;
            }

            // value not found
            if (temp == null)
            {
                return;
            }
            else
            {
                tempPrev.Next = temp.Next;
            }
        }

        public int Length()
        {
            var count = 0;
            if (IsEmpty)
            {
                return count;
            }

            var temp = _head;
            while (temp != null)
            {
                count++;
                temp = temp.Next;
            }

            return count;
        }


        public void Reverse()
        {
            if (IsEmpty)
            {
                return;
            }

            Node previous = null;
            var temp = _head;
            Node next = null;

            while (temp != null)
            {
                // store next for further traversal
                next = temp.Next;

                // swap next with previous
                temp.Next = previous;

                // traverse list storing previous
                previous = temp;
                temp = next;
            }

            // set the tail as new head
            _head = previous;

            PrintList();
        }

        public void ReverseRecursion()
        {            
            _head = ReverseListRecursion(_head);
            PrintList();
        }

        private Node ReverseListRecursion(Node head)
        { 
            if (head == null || head.Next == null)
            {
                return head;
            }

            var newHead = ReverseListRecursion(head.Next);
            head.Next.Next = head;
            head.Next = null;

            return newHead;
        }

        public bool HasCycle(Node head) 
        {
            if(head == null)
            {
                return false;
            }
            bool hasCycle = false;
            var slow = head;
            var fast = head;
        
            while(slow.Next != null && 
                (fast != null && fast.Next != null))
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            
                if(slow == fast)
                {
                    hasCycle = true;
                    break;
                }
            }
        
            return hasCycle;
        }

        public Node MiddleNode()
        {
            if (IsEmpty)
            {
                return null;
            }

            var slow = _head;
            var fast = _head;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            return slow;
        }

        public void RemoveDublicates()
        {
            if (IsEmpty)
            {
                return;
            }

            var nodes = new Dictionary<int, Node>();
            var temp = _head;
            Node prev = null;

            while (temp != null)
            {
                if (nodes.ContainsKey(temp.Value))
                {
                    if (prev != null)
                    {
                        prev.Next = temp.Next;                        
                    }
                }
                else
                {
                    nodes.Add(temp.Value, temp);
                    prev = temp;
                }
                
                temp = temp.Next;
                
            }
            
        }

        public void PrintList()
        {
            if (IsEmpty)
            {
                Console.WriteLine("List is empty");
                return;
            }

            var temp = _head;
            while (temp != null)
            {
                Console.Write(temp.Value + "->");
                temp = temp.Next;
            }
            Console.WriteLine("null");
        }
    }
}
