using System;
using System.Collections.Generic;
using System.Threading;

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
            if (head == null)
            {
                return false;
            }
            bool hasCycle = false;
            var slow = head;
            var fast = head;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast)
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

        /// <summary>
        /// Keep all values without dublicates e.g. 1->3->5->5->4->1 to 1->3->5->4
        /// </summary>
        public void RemoveDublicatesInUnsortedList()
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
                    prev.Next = temp.Next;
                }
                else
                {
                    nodes.Add(temp.Value, temp);
                    prev = temp;
                }

                temp = temp.Next;

            }

        }

        /// <summary>
        /// Keep all values without dublicates e.g. 1->3->3->5->5 to 1->3->5
        /// Idea is similar as in RemoveDublicatesInUnsortedList but no Hash required since values sorted
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node RemoveDuplicatesInSortedList(Node head)
        {
            if (head == null)
            {
                return null;
            }
            var temp = head;
            Node prev = null;

            while (temp != null)
            {
                if (temp.Value == prev?.Value)
                {
                    prev.Next = temp.Next;
                }
                else
                {
                    prev = temp;
                }
                temp = temp.Next;
            }
            return head;
        }

        /// <summary>
        /// Keep only non-dublicate values 1->1->1->2->3->4 to 2->3->4 or 1->2->3->3->3->4->4->5 to 1->2->5
        /// No Sentinel node and temp pointer used
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public void RemoveDuplicatesInSortedListAll()
        {
            if (IsEmpty)
            {
                return;
            }

            var temp = _head;
            Node prev = null;

            while (temp != null && temp.Next != null)
            {
                if (temp.Value != temp.Next.Value)
                {
                    // traverse if no dublicates storing prev
                    prev = temp;
                }
                else
                {
                    // traverse until last dublicate value                    
                    while (temp.Next != null && temp.Value == temp.Next.Value)
                    {
                        temp = temp.Next;
                    }

                    // skip all dublicate values
                    if (prev == null)
                    {
                        // prev can be null only when temp == head
                        // so just set head to next non-dublicate value
                        _head = temp.Next;
                    }
                    else
                    {
                        prev.Next = temp.Next;
                    }
                }
                // set temp to next non-dublicate value for further traversing
                temp = temp.Next;
            }
        }

        /// <summary>
        /// Same as RemoveDuplicatesInSortedListAll but optimazire after LeetCode solution review
        /// Using Sentinel node + no temp pointer since head could be changed during traversal when we have  Sentinel node
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public void RemoveDuplicatesInSortedListAllOptimized()
        {
            if (IsEmpty)
            {
                return;
            }

            // create sentinel node
            var sentinelNode = new Node(0);
            sentinelNode.Next = _head;


            Node prev = sentinelNode;

            while (_head != null && _head.Next != null)
            {
                if (_head.Value != _head.Next.Value)
                {
                    // traverse if no dublicates storing prev
                    prev = prev.Next;
                }
                else
                {
                    // find sub-list with dublicates and traverse head poiter            
                    while (_head.Next != null && _head.Value == _head.Next.Value)
                    {
                        _head = _head.Next;
                    }

                    // skip all duplicate values
                    prev.Next = _head.Next;
                }
                // set head to next for further traversing
                // next non-duplicate value
                _head = _head.Next;
            }
            _head = sentinelNode.Next;
        }


        /// <summary>
        /// Keep only non-dublicate values 3->2->2->1->3->2->4 to 1->4
        /// </summary>
        public void RemoveDuplicatesInUnsortedListAll()
        {
            if (IsEmpty)
            {
                return;
            }

            var sentinelNode = new Node(0);
            sentinelNode.Next = _head;

            Node prev = null;

            var duplicateNodes = new Dictionary<int, int>();

            while (_head != null)
            {
                if (duplicateNodes.ContainsKey(_head.Value))
                {
                    duplicateNodes[_head.Value]++;
                    prev.Next = _head.Next;
                }
                else
                {
                    duplicateNodes.Add(_head.Value, 1);
                    prev = _head;
                }
                _head = _head.Next;
            }

            _head = sentinelNode.Next.Next;
            prev = sentinelNode;

            while (_head != null)
            {
                if (duplicateNodes[_head.Value] > 1)
                {
                    prev.Next = _head.Next;
                }
                else
                {
                    prev = _head;
                }
                _head = _head.Next;
            }

            _head = sentinelNode.Next;
        }

        public void Intersection(LinkedList list)
        {
            var nodes = new Dictionary<int, Node>();
            var temp = list.Head;

            while (temp != null)
            {
                nodes.Add(temp.Value, temp);
                temp = temp.Next;
            }

            var sentinelNode = new Node(0);
            sentinelNode.Next = _head;
            Node prev = sentinelNode;

            while (_head != null)
            {
                if (!nodes.ContainsKey(_head.Value))
                {
                    prev.Next = _head.Next;
                }

                _head = _head.Next;
            }

            _head = sentinelNode.Next;
        }

        public int GetNthFromEnd(int k)
        {
            if (IsEmpty)
            {
                return -1;
            }
            var temp = _head;
            var count = 0;
            while (temp != null)
            {
                count++;
                temp = temp.Next;
            }

            if (k > count)
            {
                return -1;
            }

            temp = _head;
            while (count-- != k)
            {
                temp = temp.Next;
            }

            return temp.Value;
        }

        public int GetNthFromEndTwoPointers(int k)
        {
            if (IsEmpty)
            {
                return -1;
            }
            var nthPointer = _head;
            while (k-- != 0)
            {
                if (nthPointer == null)
                {
                    return -1;
                }
                nthPointer = nthPointer.Next;
            }

            var temp = _head;

            while (nthPointer != null)
            {
                nthPointer = nthPointer.Next;
                temp = temp.Next;
            }

            return temp.Value;
        }

        public void RemoveNthFromEnd(int n)
        {
            if (IsEmpty)
            {
                return;
            }

            var nthPointer = _head;
            while (n-- != 0)
            {
                if (nthPointer == null)
                {
                    return;
                }
                nthPointer = nthPointer.Next;
            }


            var temp = _head;
            Node prev = null;
            while (nthPointer != null)
            {
                nthPointer = nthPointer.Next;
                prev = temp;
                temp = temp.Next;
            }

            if (prev == null)
            {
                _head = _head.Next;
            }
            else
            {
                prev.Next = temp.Next;
            }
        }

        public void OddEvenList()
        {
            if (IsEmpty)
            {
                return;
            }

            var tail = _head;
            var count = 1;
            while (tail.Next != null)
            {
                count++;
                tail = tail.Next;
            }

            var even = _head.Next;
            var prev = _head;
            //stop count - when all even nodes will be traversed
            var k = count / 2;
            while (k-- != 0 && even != null && even.Next != null)
            {
                // delete even node
                prev.Next = even.Next;
                prev = prev.Next;

                // put even node to the end and traverse tail
                tail.Next = even;
                tail = tail.Next;

                even = even.Next.Next;
                // avoid circular list
                tail.Next = null;
            }
        }

        public void OddEvenListOptimized()
        {
            if (IsEmpty)
            {
                return;
            }

            var odd = _head;
            var even = _head.Next;
            var evenList = even;

            while (even != null && even.Next != null)
            {
                odd.Next = even.Next;
                //odd.next = odd.next.next;
                odd = odd.Next;

                even.Next = odd.Next;
                //even.next = even.next.next;
                even = even.Next;
            }

            odd.Next = evenList;
        }

        public bool IsPalindrome()
        {
            if (IsEmpty)
            {
                return false;
            }

            var middleNode = FindMiddleOfTheList(_head);
            var secondPartReversedHead = ReverseListInternal(middleNode.Next);

            var firstPart = _head;
            var secondPart = secondPartReversedHead;
            while (secondPart != null)
            {
                if (firstPart.Value != secondPart.Value)
                {
                    return false;
                }
                secondPart = secondPart.Next;
                firstPart = firstPart.Next;
            }

            var secondPartNormalHead = ReverseListInternal(secondPartReversedHead);

            middleNode.Next = secondPartNormalHead;

            return true;
        }

        /// <summary>
        /// Adjusted to find first middle node for even list i ncase if there 2 middle node
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        private Node FindMiddleOfTheList(Node head)
        {
            var slow = head;
            var fast = head;

            // important check to find first middle node for even lists 
            while (fast.Next != null && fast.Next.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
            }

            return slow;
        }

        private Node ReverseListInternal(Node head)
        {
            var temp = head;
            Node prev = null;
            while (temp != null)
            {
                var next = temp.Next;
                temp.Next = prev;

                prev = temp;
                temp = next;
            }

            return prev;
        }

        public void RotateRight(int k)
        {
            if (IsEmpty || k == 0)
            {
                return;
            }

            var tail = _head;
            var count = 1;
            while (tail.Next != null)
            {
                count++;
                tail = tail.Next;
            }

            if (k % count == 0)
            {
                //list will be the same e.g. count = 5 k = 5, 10, 15 etc
                return;
            }

            // make list circular
            tail.Next = _head;

            var n = count - k;
            Node prev = null;
            while (n != 0)
            {
                prev = _head;
                _head = _head.Next;
                n--;
            }
            //remove circle in list
            //set new tail next to null
            prev.Next = null;
            
            return;
        }

        public void CreateCircularList()
        {
            if (IsEmpty)
            {
                _head.Next = _head;
            }

            var tail = _head;
            while (tail.Next != null)
            {
                tail = tail.Next;
            }
            tail.Next = _head;
        }

        public void Insert(int insertVal)
        {
            if (IsEmpty)
            {
                _head = new Node(insertVal);
                _head.Next = _head;
                return;
            }

            var (minNode, maxNode) = FindMinMaxNode(_head);
            var newNode = new Node(insertVal);
            if (insertVal < minNode.Value)
            {
                maxNode.Next = newNode;
                newNode.Next = minNode;                
            }
            else
            {
                var targetNode = minNode;
                while (targetNode.Next != minNode && newNode.Value > targetNode.Next.Value)
                {
                    targetNode = targetNode.Next;
                }
                newNode.Next = targetNode.Next;
                targetNode.Next = newNode;
            }
            return;
        }

        private (Node minNode, Node prev) FindMinMaxNode(Node head)
        {
            Node prev = head;
            var slow = head;
            var fast = head.Next;
            var minNode = head;
            var maxNode = prev;
            while (fast != null && fast.Next != null)
            {
                if (slow.Value < minNode.Value)
                {
                    minNode = slow;
                   
                }
                if (slow.Value >= maxNode.Value)
                {
                    maxNode = slow;

                }               
                if (slow == fast)
                {
                    break;
                }
                
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            return (minNode, maxNode);
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
