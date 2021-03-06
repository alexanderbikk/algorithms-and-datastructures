using AlgorithmsAndDataStructures.Trees;
using LeetCodeMedium.Design;
using LeetCodeMedium.Trees.BinaryTree;
using System;
using System.Linq;

namespace LeetCodeMedium
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Binary Tree");
            //CommonBinaryTree();


            //TreeFromParentArray();
            //Console.WriteLine();

            //Console.WriteLine("BST");
            //BST();
            //Console.WriteLine();

            //Console.WriteLine("Heap");
            //Heap();
            //Console.WriteLine();

            //Console.WriteLine("Arrays");
            //Arrays();
            //Console.WriteLine();

            Console.WriteLine("Design");
            Design();
            Console.WriteLine();
        }

        /// <summary>
        /// Practice with BST
        /// </summary>
        public static void BST()
        {

            var soulution = new Trees.BST.Solution();
            var values = new int?[] { 6, 4, 9, 2, 5, 8, 12, null, null, null, null, null, null, 10, 14 };
            var root = TreeHelpers.CreateTreeFromLevelOrderArrayDFS(values, 0);

            Console.WriteLine("Find kth max in BST - DFS for Right to Root and Left until count is not equeal to k. " +
                "Return when foud to avoid unnesesary traversal");
            var result = soulution.FindMaxKthRecursive(root, 3);
            Console.WriteLine(result);

            Console.WriteLine();

            var count = 0;
            var target = -1;
            Console.WriteLine("Find kth max in without return from left subtree BST");
            soulution.RightRootLeft(root, 3, ref count, ref target);
            Console.WriteLine(target);

            values = new int?[] { 1, null, 2, null, null, null, 3, null, null, null, null, null, null, null, 4 };
            root = TreeHelpers.CreateTreeFromLevelOrderArrayDFS(values, 0);

            Console.WriteLine();
            Console.WriteLine("Balance BST - convert to array then build from array using mid pos and divide left and right sub-tree by 2");
            root = soulution.BalanceBST(root);
            TreeHelpers.LevelOrder(root);
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Containce dublicate 3");
            var k = 2;
            var t = 3;
            var nums = new int[] { 1, 5, 9, 1, 5, 9 };

            bool isContains = soulution.ContainsNearbyAlmostDuplicate(nums, k, t);            
            Console.WriteLine(isContains);

            Console.WriteLine();

        }

        public static void CommonBinaryTree()
        {

            var solution = new CommonSolution();

            Console.WriteLine("Is Symetric Tree - Compare left and right subtree");

            var values = new int?[] { 1, 2, 2, 3, 4, 4, 3, 5, 6, 7, 8, 8, 7, 6, 5 };
            var root = TreeHelpers.CreateTreeFromLevelOrderArrayDFS(values, 0);
            TreeHelpers.LevelOrder(root);


            var result = solution.IsSymetricTree(root);
            Console.WriteLine(result);
            Console.WriteLine();

            values = new int?[] { 1, 2, 2, null, 3, null, 3 };

            root = TreeHelpers.CreateTreeFromLevelOrderArrayDFS(values, 0);
            TreeHelpers.LevelOrder(root);

            result = solution.IsSymetricTree(root);
            Console.WriteLine(result);
            Console.WriteLine();


            Console.WriteLine("Complete Binary tree insertor. O(1) for insert - " +
                "store last not completed level on creation and then insert will be O(1) but createion O(n)");
            Console.WriteLine("Another solution insert using Level Order traversal so insert will be O(n) but creation O(1)");

            values = new int?[] { 2, 3, 4, 5, null, null, null };

            root = TreeHelpers.CreateTreeFromLevelOrderArrayDFS(values, 0);
            TreeHelpers.LevelOrder(root);

            var cbtInserter = new CBTInserter(root);
            cbtInserter.Insert(7);
            cbtInserter.Insert(8);
            cbtInserter.Insert(9);
            cbtInserter.Insert(10);

            TreeHelpers.LevelOrder(cbtInserter.Get_root());

            Console.WriteLine("Left View of Binary tree Recursion + Iterative");
            values = new int?[] { 1, 2, 3, null, null, 4, 6, null, null, null, null, null, 5, null, null };

            root = TreeHelpers.CreateTreeFromLevelOrderArrayDFS(values, 0);
            TreeHelpers.LevelOrder(root);

            var leftList = solution.LeftView(root);
            foreach (var item in leftList)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            leftList = solution.LeftViewRecursion(root);
            foreach (var item in leftList)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Flatten Binary try to linked list pre-order ordering");
            values = new int?[] { 1, null, 2, 3 };
            root = TreeHelpers.BstFromPreorder(values);

            solution.FlattenBinaryTree(root);
            TreeHelpers.LevelOrder(root);


            Console.WriteLine();
            Console.WriteLine("Tree to doubly-linked list");            
            values = new int?[] { 4, 2, 5, 1, 3 };
            root = TreeHelpers.BstFromPreorder(values);

            root = solution.TreeToDoublyList(root);

            root = TreeHelpers.BstFromPreorder(values);
            root = solution.TreeToDoublyListRecursion(root);

            Console.WriteLine();
            Console.WriteLine("Populating Next Right Pointers in Each Node II");
            values = new int?[] { 0, 2, 4, 1, null, 3, -1, 5, 1, null, 6, null, 8 };
            root = TreeHelpers.BstFromPreorder(values);

            root = solution.Connect(root);

            Console.WriteLine();
            Console.WriteLine("Populating Next Right Pointers in Each Node");
            values = new int?[] { 1,2,3,4,5,6,7};
            root = TreeHelpers.BstFromPreorder(values);

            root = solution.ConnectPerfectTree(root);            





            Console.WriteLine();
            Console.WriteLine("Serialize binary tree");
            values = new int?[] { 1, 2, 3, null, null, 4, 5 };
            root = TreeHelpers.BstFromPreorder(values);

            TreeSerializer treeSerializer = new();
            var tree = treeSerializer.Serialize(root);
            root = treeSerializer.Deserialize(tree);

            TreeHelpers.LevelOrder(root);

        }

        public static void Heap()
        {

            var solution = new Heaps.CommonSolution();           

            Console.WriteLine("TopKFrequent - Bucket sort");
            solution.TopKFrequent(new int[] { 1,1,3,2,2}, 2);
            //new int[] { 1, 1,1, 2, 2, 3 }
            var result = solution.TopKFrequentBucketSort(new int[] { 1, 1, 3, 3, 1, 2, 2, 2 }, 2);                       

            foreach (var item in result)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine("KthSmallest in sorted matrix");
            var k = 8;
            var matrix = new int[3][]
                {
                    new int[3] { 1, 5, 9},
                    new int[3] { 10, 11, 13},
                    new int[3] { 12, 13, 15}
                };

            var value = solution.KthSmallest(matrix, k);
            Console.WriteLine(value);
            Console.WriteLine();

            var medianFinder = new Heaps.MedianFinder();

            medianFinder.AddNum(6);
            var median = medianFinder.FindMedian();
            medianFinder.AddNum(10);
            median = medianFinder.FindMedian();
            medianFinder.AddNum(2);
            median = medianFinder.FindMedian();
            medianFinder.AddNum(6);
            median = medianFinder.FindMedian();
            medianFinder.AddNum(5);
            median = medianFinder.FindMedian();
            medianFinder.AddNum(0);
            median = medianFinder.FindMedian();
            medianFinder.AddNum(6);
            median = medianFinder.FindMedian();
            medianFinder.AddNum(3);
            median = medianFinder.FindMedian();
            Console.WriteLine(median);
        }

        public static void Arrays()
        {
            var solution = new Arrays.Solution();

            var intervals = new int[3][]
                {
                    new int[] { 0, 30},
                    new int[] { 5, 10},
                    new int[] {15, 20}
                };

            //var intervals = new int[7][]
            //{
            //    new int[] { 2, 4 },
            //    new int[] { 4, 5},
            //    new int[] {5, 6},
            //    new int[] {4, 6},
            //    new int[] {8, 9},
            //    new int[] {7, 10},
            //    new int[] {8, 10}
            //};            

            var roomsCount = solution.MinMeetingRooms(intervals);
            Console.WriteLine(roomsCount.ToString());
        }


        public static void Design()
        {
            var lruCache = new LRUCache(2);


            lruCache.Put(1, 1);
            lruCache.Put(2, 2);
            lruCache.Get(1);
            lruCache.Put(3, 3);
            lruCache.Get(2);
            lruCache.Put(4, 4);

            lruCache.Put(3, 3);
            lruCache.Get(1);
            lruCache.Get(3);
            lruCache.Get(4);

            //lruCache.Put(2, 1);
            //lruCache.Put(1, 1);
            //lruCache.Put(2, 3);
            //lruCache.Put(4, 1);
            //lruCache.Get(1);

            //lruCache.Put(3, 3);
            //lruCache.Get(2);
        }

        /// <summary>
        /// Practice with binary tree from paretn array
        /// </summary>
        public static void TreeFromParentArray()
        {
            var solution = new TreeFromParentArraySolution();

            var parentArray = new int[] { 1, 5, 5, 2, 2, -1, 3 };
            //var parentArray = new int[] { -1, 0, 0, 1, 1, 3, 5 };

            Console.WriteLine("Create tree from level order array BFS");
            var root = solution.CreateTreeFromParentArrayBFS(parentArray, parentArray.Length);
            TreeHelpers.LevelOrder(root);


            Console.WriteLine("Create tree from level order array DFS");
            root = solution.CreateTreeFromParentArrayDFS(parentArray, parentArray.Length);
            TreeHelpers.LevelOrder(root);

            Console.WriteLine("Create tree from level order array");
            var values = new int?[] { 1, 10, 12, 5, 78, 7, 15, 4, null, 3, null, 11, 8, 9, null };
            var newRoot = TreeHelpers.CreateTreeFromLevelOrderArrayDFS(values, 0);
            TreeHelpers.LevelOrder(newRoot);

            Console.WriteLine("Create tree from level order array simple loop");
            root = solution.CreateTreeFromParentArraySimpleLoop(parentArray);
            TreeHelpers.LevelOrder(root);


            Console.WriteLine("Tree height from parent array");
            var height = solution.CalculateTreeHeightFromParentArray(parentArray);
            Console.WriteLine(height);

            parentArray = new int[] { 1, 5, 5, 2, 2, -1, 3, 3, 4, 4, 0, 0, 1, 10 };
            height = solution.CalculateTreeHeightFromParentArray(parentArray);
            Console.WriteLine(height);
        }
    }
}
