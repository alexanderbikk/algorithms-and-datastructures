using AlgorithmsAndDataStructures;
using AlgorithmsAndDataStructures.LinkedList;
using AlgorithmsAndDataStructures.Queues;
using AlgorithmsAndDataStructures.Searches;
using AlgorithmsAndDataStructures.Trees;
using AlgorithmsAndDataStructures.Trees.AVL;
using AlgorithmsAndDataStructures.Trees.BST;
using AlgorithmsAndDataStructures.Trees.BTree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            //LinkedList();
            //DoublyLinkedList();

            //ShowBSTTree();
            //ShowSearches();

            //SumInTree();
            //AVLTree();

            //BTree();

            //Heap();
            //HeapCustom();

            Queue();
        }

        private static void Queue()
        {
            var cQueue = new CircularQueue(3);
            cQueue.EnQueue(1);
            cQueue.EnQueue(2);
            cQueue.EnQueue(3);
            cQueue.DeQueue();
            cQueue.DeQueue();
            cQueue.EnQueue(3);
            cQueue.EnQueue(5);
            cQueue.DeQueue();
            cQueue.DeQueue();
            cQueue.DeQueue();
            cQueue.DeQueue();
        }

        public static void DoublyLinkedList()
        {
            MyLinkedList myLinkedList = new MyLinkedList();
            //myLinkedList.AddAtHead(1);
            //myLinkedList.AddAtTail(3);
            myLinkedList.AddAtIndex(0, 10);    
            myLinkedList.AddAtIndex(0, 20);    
            myLinkedList.AddAtIndex(1, 30);    
            //myLinkedList.Get(1);              // return 2
            //myLinkedList.DeleteAtIndex(0);    // now the linked list is 1->3
            myLinkedList.Get(0);
        }

        public static void LinkedList()
        {
            var linkedList = new LinkedList();
            Console.WriteLine(linkedList.IsEmpty);
            linkedList.PrintList();
            Console.WriteLine();


            Console.WriteLine("Insert at head");
            linkedList.InsertAtHead(1);
            linkedList.InsertAtHead(2);
            linkedList.InsertAtHead(3);

            linkedList.PrintList();
            Console.WriteLine();

            Console.WriteLine("Insert at tail");

            linkedList = new LinkedList();

            linkedList.InsertAtTail(10);
            linkedList.InsertAtTail(20);
            linkedList.InsertAtHead(1);

            linkedList.PrintList();
            Console.WriteLine();


            Console.WriteLine("Insert after Node");

            linkedList = new LinkedList();

            var node = new Node(10);
            linkedList.InsertAtHead(node);
            linkedList.InsertAtHead(new Node(20));

            linkedList.InsertAfter(node, 15);
            linkedList.InsertAfter(node, 17);


            linkedList.PrintList();
            Console.WriteLine();

            Console.WriteLine("Search");

            var result = linkedList.Search(15);
            Console.WriteLine(result);


            result = linkedList.Search(20);
            Console.WriteLine(result);

            result = linkedList.Search(17);
            Console.WriteLine(result);

            result = linkedList.Search(18);
            Console.WriteLine(result);
            Console.WriteLine();

            Console.WriteLine("Length");

            var length = linkedList.Length();
            Console.WriteLine(length);
            Console.WriteLine();

            Console.WriteLine("Reverse");


            linkedList.Reverse();
            linkedList.Reverse();

            linkedList.ReverseRecursion();
            linkedList.ReverseRecursion();

            Console.WriteLine("Delete");
            linkedList.Delete(10);
            // not exists
            linkedList.Delete(18);
            linkedList.Delete(17);
            linkedList.Delete(15);
            // delete head
            linkedList.Delete(20);

            linkedList.PrintList();
            Console.WriteLine();


            Console.WriteLine("Has cycle");

            // list with cycle
            var headWithCycle = new Node(3);
            headWithCycle.Next = new Node(2);
            headWithCycle.Next.Next = new Node(0);
            headWithCycle.Next.Next.Next = new Node(-4);
            headWithCycle.Next.Next.Next.Next = headWithCycle;

            result = linkedList.HasCycle(headWithCycle);
            Console.WriteLine(result);

            // list without cycle
            var headWithOutCycle = new Node(3);
            headWithOutCycle.Next = new Node(2);
            headWithOutCycle.Next.Next = new Node(0);
            headWithOutCycle.Next.Next.Next = new Node(-4);

            result = linkedList.HasCycle(headWithOutCycle);
            Console.WriteLine(result);
            Console.WriteLine();

            Console.WriteLine("Middle Node. Two pointers");
            linkedList.InsertAtHead(1);
            linkedList.InsertAtHead(2);
            linkedList.InsertAtHead(3);
            linkedList.InsertAtHead(4);

            linkedList.PrintList();
            Console.WriteLine();
            var middleNode = linkedList.MiddleNode();
            Console.WriteLine(middleNode.Value);

            Console.WriteLine("Remove Dublicates In Unsorted List. Keep all except dublicates");
            linkedList = new LinkedList();
            linkedList.InsertAtTail(7);
            linkedList.InsertAtTail(14);
            linkedList.InsertAtTail(21);
            linkedList.InsertAtTail(22);
            linkedList.InsertAtTail(14);
            linkedList.InsertAtTail(7);

            linkedList.PrintList();
            Console.WriteLine();

            linkedList.RemoveDublicatesInUnsortedList();
            linkedList.PrintList();
            Console.WriteLine();

            Console.WriteLine("Remove Dublicates In Sorted List. Keep only non-dublicate nodes");
            linkedList = new LinkedList();
            linkedList.InsertAtTail(1);
            linkedList.InsertAtTail(1);
            linkedList.InsertAtTail(1);
            linkedList.InsertAtTail(2);
            linkedList.InsertAtTail(3);
            linkedList.InsertAtTail(3);
            linkedList.InsertAtTail(3);
            linkedList.InsertAtTail(4);
            linkedList.InsertAtTail(5);

            linkedList.PrintList();
            Console.WriteLine();

            linkedList.RemoveDuplicatesInSortedListAll();
            //linkedList.RemoveDuplicatesInSortedListAllOptimized();
            linkedList.PrintList();
            Console.WriteLine();


            Console.WriteLine("Remove Dublicates In Unsorted List. Keep only non-dublicate nodes");
            linkedList = new LinkedList();
            linkedList.InsertAtTail(1);
            linkedList.InsertAtTail(1);
            linkedList.InsertAtTail(2);
            linkedList.InsertAtTail(3);
            linkedList.InsertAtTail(2);
            linkedList.InsertAtTail(4);

            linkedList.PrintList();
            Console.WriteLine();

            linkedList.RemoveDuplicatesInUnsortedListAll();
            
            linkedList.PrintList();
            Console.WriteLine();


            Console.WriteLine("Intersection");
            linkedList = new LinkedList();
            linkedList.InsertAtTail(15);
            linkedList.InsertAtTail(20);
            linkedList.InsertAtTail(14);

            var linkedList2 = new LinkedList();
            linkedList2.InsertAtTail(14);
            linkedList2.InsertAtTail(7);
            linkedList2.InsertAtTail(21);

            linkedList.PrintList();
            linkedList2.PrintList();
            Console.WriteLine();

            linkedList.Intersection(linkedList2);

            linkedList.PrintList();
            Console.WriteLine();

            Console.WriteLine("Get Nth value from end of linked list");
            linkedList = new LinkedList();
            linkedList.InsertAtTail(1);
            linkedList.InsertAtTail(2);
            linkedList.InsertAtTail(3);
            linkedList.InsertAtTail(4);
            linkedList.InsertAtTail(5);
            linkedList.InsertAtTail(6);
            linkedList.InsertAtTail(7);
            linkedList.InsertAtTail(8);
            linkedList.InsertAtTail(9);

            linkedList.PrintList();
            Console.WriteLine();

            var n = 3;
            //var nthResult = linkedList.GetNthFromEnd(n);

            var nthResult = linkedList.GetNthFromEndTwoPointers(n);

            Console.WriteLine(nthResult);

            Console.WriteLine("Odd Even List");
            linkedList = new LinkedList();
            linkedList.InsertAtTail(1);
            linkedList.InsertAtTail(2);
            linkedList.InsertAtTail(3);
            linkedList.InsertAtTail(4);
            //linkedList.InsertAtTail(5);

            linkedList.PrintList();
            Console.WriteLine();

            linkedList.OddEvenListOptimized();
            linkedList.PrintList();
            Console.WriteLine();


            Console.WriteLine("Is Palindrome");
            linkedList = new LinkedList();
            linkedList.InsertAtTail(1);
            linkedList.InsertAtTail(2);
            //linkedList.InsertAtTail(6);
            //linkedList.InsertAtTail(6);
            linkedList.InsertAtTail(2);
            linkedList.InsertAtTail(1);            

            linkedList.PrintList();
            Console.WriteLine();

            result = linkedList.IsPalindrome();
            linkedList.PrintList();
            Console.WriteLine(result);

            Console.WriteLine("Rotate list");
            linkedList = new LinkedList();
            linkedList.InsertAtTail(1);
            linkedList.InsertAtTail(2);

            linkedList.PrintList();
            Console.WriteLine();

            linkedList.RotateRight(1);
            linkedList.PrintList();
            Console.WriteLine(result);


            Console.WriteLine("Insert in circular sorted list");
            linkedList = new LinkedList();
           
            linkedList.InsertAtTail(1);
            linkedList.InsertAtTail(2);
            linkedList.InsertAtTail(3);

            linkedList.PrintList();
            Console.WriteLine();

            linkedList.CreateCircularList();
            linkedList.Insert(0);                        

        }

        public static void BTree()
        {
            // create 2-3-4 tree
            var btree = new BTree(2);

            Console.WriteLine("Insert");
            btree.Insert(1);
            btree.Insert(3);
            btree.Insert(2);

            // split root
            btree.Insert(4);
            btree.Insert(5);

            // split leaf
            btree.Insert(6);
            btree.Insert(7);


            // split leaf
            btree.Insert(8);

            // root is full split
            btree.Insert(9);

            btree.Insert(10);
            btree.Insert(11);
            btree.Insert(12);

            // split non-leaf since we split before go to next level - unnesesary split
            btree.Insert(13);

            Console.WriteLine("Insert completed");

            Console.WriteLine();
            Console.WriteLine("Traverse");
            btree.Traverse();

            Console.WriteLine();
            Console.WriteLine("Seach");
            var target = 4;
            var resultNode = btree.Search(target);
            if (resultNode == null)
            {
                Console.WriteLine($"Target : {target} not found");
            }
            else
            {
                Console.WriteLine(resultNode.Keys.Find(x => x == target));
            }
        }

        public static void ShowBSTTree()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("-------BST Tree---------");
            Console.WriteLine("------------------------");
            Console.WriteLine();

            Console.WriteLine("-------Init and Insert---------");
            Console.WriteLine();

            var binarySearchTreee = new BinarySearchTree<int>(13);
            binarySearchTreee.InsertValueRecursive(4);
            binarySearchTreee.InsertValueRecursive(7);
            binarySearchTreee.InsertValueRecursive(16);
            binarySearchTreee.InsertValueRecursive(19);
            binarySearchTreee.InsertValueRecursive(15);
            binarySearchTreee.InsertValueRecursive(17);
            binarySearchTreee.InsertValueRecursive(18);
            binarySearchTreee.InsertValueRecursive(3);
            binarySearchTreee.InsertValueRecursive(1);
            binarySearchTreee.InsertValueRecursive(9);
            binarySearchTreee.InsertValueRecursive(2);

            Console.WriteLine("-------Print Depth First Recurive---------");
            Console.WriteLine();

            binarySearchTreee.PrintDpethTreeRecursive(binarySearchTreee.Root);

            Console.WriteLine("-------Print Depth First Iterative Stack---------");
            Console.WriteLine();

            var result = binarySearchTreee.PrintDepthTree(binarySearchTreee.Root);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------Print Breadth First Iterative Queueu---------");
            Console.WriteLine();
            result = binarySearchTreee.PrintBreadthTree(binarySearchTreee.Root);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------Search---------");
            Console.WriteLine();

            var value = 4;
            var resultNode = binarySearchTreee.SearchRecursive(binarySearchTreee.Root, value);
            if (resultNode != null)
            {
                Console.WriteLine($"Result node {resultNode.Value}");
            }
            else
            {
                Console.WriteLine($"Node with value {value} not found.");
            }


            Console.WriteLine("-------Height---------");
            var height = binarySearchTreee.Height(binarySearchTreee.Root);
            Console.WriteLine(height);

            // TODO: it will be greate to creta a tests with all delete cases or improve samples here 1 tree for each case
            // rather then just use one tree for all
            Console.WriteLine("-------Delete---------");

            Console.WriteLine($"Delete when not exists {12}");
            bool deleteResult = binarySearchTreee.DeleteValueRecursive(12);
            Console.WriteLine(deleteResult);

            Console.WriteLine($"Delete when exists {4}");
            deleteResult = binarySearchTreee.DeleteValueRecursive(4);
            Console.WriteLine(deleteResult);
            binarySearchTreee.PrintDpethTreeRecursive(binarySearchTreee.Root);


            binarySearchTreee.InsertValueRecursive(4);
            Console.WriteLine($"Delete when exists {16}");
            deleteResult = binarySearchTreee.DeleteValueRecursive(16);
            Console.WriteLine(deleteResult);

            binarySearchTreee.PrintDpethTreeRecursive(binarySearchTreee.Root);
        }

        public static void ShowSearches()
        {
            Console.WriteLine();
            Console.WriteLine("------------------------");
            Console.WriteLine("-------Searches---------");
            Console.WriteLine("------------------------");
            Console.WriteLine();


            var search = new Search();
            var sortedArray = new int[] { 1, 2, 4, 7, 10, 12, 19, 20, 43, 55 };

            Console.WriteLine("-------Test Array---------");
            Console.WriteLine();
            foreach (var item in sortedArray)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine("-------Binary Search---------");
            Console.WriteLine();

            var target = 43;
            var pos = search.BinarySearch(sortedArray, target);

            Console.WriteLine($"Trget {target} Result position {pos}");

            target = 1;
            pos = search.BinarySearch(sortedArray, target);

            Console.WriteLine($"Trget {target} Result position {pos}");
        }

        public static void AVLTree()
        {
            var avlTree = new AVLTree(10);
            avlTree.InsertValue(7);
            avlTree.InsertValue(15);
            avlTree.InsertValue(9);
            avlTree.InsertValue(6);
            //LL
            avlTree.InsertValue(3);
            //LR
            //avlTree.InsertValue(8);


            avlTree.PrintInOrder(avlTree.Root);
            Console.WriteLine();
            Console.WriteLine();

            TreeHelpers.LevelOrder(avlTree.Root);
            Console.WriteLine();
            Console.WriteLine();

            var avlTreeDelete = new AVLTree(50);

            avlTreeDelete.InsertValue(70);
            avlTreeDelete.InsertValue(30);

            avlTreeDelete.InsertValue(20);
            avlTreeDelete.InsertValue(35);
            avlTreeDelete.InsertValue(55);
            avlTreeDelete.InsertValue(80);

            avlTreeDelete.InsertValue(10);
            avlTreeDelete.InsertValue(51);
            avlTreeDelete.InsertValue(75);
            avlTreeDelete.InsertValue(90);

            avlTreeDelete.InsertValue(72);
            avlTreeDelete.InsertValue(92);

            TreeHelpers.LevelOrder(avlTreeDelete.Root);
            Console.WriteLine();
            Console.WriteLine();

            avlTreeDelete.DeleteValue(70);
            TreeHelpers.LevelOrder(avlTreeDelete.Root);
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void Heap()
        {
            var items = new (string, int)[] { new("a", 10), new("b", 20), new("d", 1) };
            var minHeap = new PriorityQueue<string, int>(items);
            Console.WriteLine(minHeap.Dequeue());
            Console.WriteLine(minHeap.Count);
            Console.WriteLine(minHeap.Dequeue());
            Console.WriteLine(minHeap.Count);
            Console.WriteLine(minHeap.Dequeue());
            Console.WriteLine(minHeap.Count);

            minHeap.Enqueue("test", 10);
            Console.WriteLine(minHeap.Peek());


            Console.WriteLine();

            var maxHeap = new PriorityQueue<string, int>(items, new MaxInt32IComparer());
            Console.WriteLine(maxHeap.Dequeue());
            Console.WriteLine(maxHeap.Count);
            Console.WriteLine(maxHeap.Dequeue());
            Console.WriteLine(maxHeap.Count);
            Console.WriteLine(maxHeap.Dequeue());
            Console.WriteLine(maxHeap.Count);

            maxHeap.Enqueue("test", 10);

            maxHeap.UnorderedItems.Select(x => x.Element).ToArray();

            Console.WriteLine(maxHeap.Peek());
        }

        public static void HeapCustom()
        {
            var items = new int[] { 2, 8, 15, 5, 1, 20 };

            var minHeap = new Heap<int>(items);
            minHeap.Print();

            Console.WriteLine(minHeap.Peek());
            minHeap.Dequeue();

            Console.WriteLine(minHeap.Peek());
            minHeap.Dequeue();

            minHeap.Enqueue(-10);
            Console.WriteLine(minHeap.Peek());
            minHeap.Print();

            items = new int[] { 1, 2, 3, 4, 5, 6 };

            var maxHeap = new Heap<int>(items, new MaxInt32IComparer());
            maxHeap.Print();

            Console.WriteLine(maxHeap.Peek());
            maxHeap.Dequeue();

            Console.WriteLine(maxHeap.Peek());
            maxHeap.Dequeue();

            Console.WriteLine(maxHeap.Peek());
            maxHeap.Dequeue();

            maxHeap.Enqueue(1000);
            Console.WriteLine(maxHeap.Peek());
            maxHeap.Print();

            items = new int[] { 2, 8, 15, 5, 1, 20 };
            
            var maxHeap2 = new Heap<int>(items, new MaxInt32IComparer());
            maxHeap2.Print();


            ConvertMaxHeap convertor = new();
            var max = new List<int> { 9, 4, 7, 1, -2, 6, 5 };
            var minHeapString = convertor.ConvertToMinHeap(max);
            Console.WriteLine(minHeapString);
        }

        public class MaxInt32IComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y - x;
            }
        }

        public class MixInt32IComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return x - y;
            }
        }


        /// <summary>
        /// TODO move to LeetCode easy and use tree structure there
        /// </summary>
        public static void SumInTree()
        {
            var binarySearchTreee = new BinarySearchTree<int>(2);
            binarySearchTreee.InsertValueRecursive(1);
            binarySearchTreee.InsertValueRecursive(3);
            //binarySearchTreee.InsertValueRecursive(2);
            //binarySearchTreee.InsertValueRecursive(4);
            //binarySearchTreee.InsertValueRecursive(7);           
            var target = 3;
            var result = FindTarget(binarySearchTreee.Root, target);

            Console.WriteLine(result);
        }

        public static bool FindTarget(Node<int> root, int k)
        {
            var hasSet = new Dictionary<int, int>();

            return PreOrderTree(root, k, hasSet);
        }
        public static bool PreOrderTree(Node<int> root, int k, Dictionary<int, int> hasSet)
        {
            if (root == null)
            {
                return false;
            }

            var result = k - root.Value;
            if (hasSet.ContainsKey(result))
            {
                return true;
            }
            else
            {
                hasSet.Add(root.Value, root.Value);
            }

            bool isSumExists = PreOrderTree(root.LeftChild, k, hasSet);

            // if we node found for the root + left
            // retrun result for the root + right
            if (!isSumExists)
            {
                isSumExists = PreOrderTree(root.RightChild, k, hasSet);
            }
            return isSumExists;
        }
    }
}
