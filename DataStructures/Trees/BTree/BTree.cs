using System;

namespace AlgorithmsAndDataStructures.Trees.BTree
{
    /// <summary>
    /// Good implementation
    /// https://github.com/rsdcastro/btree-dotnet/blob/dc8448ff57101fdc71cbf04d5644f22430d33b5d/BTree/BTree.cs#L336
    /// </summary>
    public class BTree
    {
        // minimum degree oder t >=2
        // https://cs.stackexchange.com/a/80294/144521
        public int MinDegree { get; set; }

        public BTreeNode Root { get; set; }


        public BTree(int minDegree)
        {
            MinDegree = minDegree;
            Root = new BTreeNode(minDegree);
        }

        public void Traverse()
        {
            if (Root != null)
            {
                TraverseInternal(Root);
            }
        }

        public void Insert(int key)
        {
            if (Root.Keys.Count == 0)
            {
                Root.Keys.Add(key);
                return;
            }

            if (Root.IsMaxKeysCount)
            {
                // Create new root and set current root to it's children
                var newRoot = new BTreeNode(MinDegree);
                newRoot.Children.Insert(0, Root);

                // Split the old root and move 1 key to the new root
                SplitChild(newRoot, 0, Root);

                // New root has two children now.  Decide which of the
                // two children is going to have new key
                int i = 0;
                // newRoot will always has only one key
                // so just simply check where to add in left or right child
                if (newRoot.Keys[0] < key)
                {
                    i++;
                }

                InsertNonFull(newRoot.Children[i], key);

                // Change root
                Root = newRoot;
            }
            else
            {
                InsertNonFull(Root, key);
            }
        }

        public BTreeNode Search(int key)
        {
            if (Root == null)
            {
                return null;
            }

            return SearchInternal(Root, key);
        }

        private void TraverseInternal(BTreeNode root)
        {
            // traverse for each key
            int i = 0;
            for (; i < root.Keys.Count; i++)
            {
                if (!root.IsLeaf)
                {
                    // traverse all children first - recursion
                    TraverseInternal(root.Children[i]);
                }
                // print current key
                Console.WriteLine(root.Keys[i]);
            }

            // since we have always _keysCount + 1 childred
            // travers last right children if not a leaf
            if (!root.IsLeaf)
            {
                TraverseInternal(root.Children[i]);
            }
        }

        private void InsertNonFull(BTreeNode root, int key)
        {
            var keyIndex = root.Keys.Count - 1;

            // for leaf just insert in the right place in Keys array
            if (root.IsLeaf)
            {
                // a) Finds the location of new key to be inserted
                // b) Moves all greater keys to one place ahead
                while (keyIndex >= 0 && root.Keys[keyIndex] > key)
                {                    
                    keyIndex--;
                }

                root.Keys.Insert(keyIndex + 1, key);
            }
            else
            {
                // search appropriate child index in current level
                while (keyIndex >= 0 && root.Keys[keyIndex] > key)
                {
                    keyIndex--;
                }

                var childIndex = keyIndex + 1;

                // children count = kyes count + 1
                if (root.Children[childIndex].IsMaxKeysCount)
                {
                    // children is full we should split it before recursion (proctive insertion -> split before recursion)
                    SplitChild(root, childIndex, root.Children[childIndex]);

                    // After split, the middle key of Cchildren[i] goes up and
                    // Children[i] is splitted into two.  See which of the two
                    // is going to have the new key
                    if (root.Keys[childIndex] < key)
                    {
                        childIndex++;
                    }
                }

                InsertNonFull(root.Children[childIndex], key);
            }


        }

        // A utility function to split the child y of this node
        // Note that childNode y must be full when this function is called
        private void SplitChild(BTreeNode parent, int childIndex, BTreeNode nodeToBeSplited)
        {
            var newChild = new BTreeNode(MinDegree);

            // Split keys and children between child nodes

            // copy the last minDegree - 1 Keys to newChild 
            // so newChild will contain greates  Keys
            // for 2-3-4 tree copy last key, one key stay in child and one key go up to node
            newChild.Keys.AddRange(nodeToBeSplited.Keys.GetRange(MinDegree, MinDegree - 1));

            // copy children to newChild for non-leaf node
            if (!nodeToBeSplited.IsLeaf)
            {
                // children count = Keys cout + 1
                // for 2-3-4 tree copy last 2 children             
                newChild.Children.AddRange(nodeToBeSplited.Children.GetRange(MinDegree, MinDegree));
                nodeToBeSplited.Children.RemoveRange(MinDegree, MinDegree);
            }

            // Update parent node

            // Copy the middle key of child node y to parent
            parent.Keys.Insert(childIndex, nodeToBeSplited.Keys[MinDegree - 1]);
            // Link the newChild to this node, link newChild to the next position of current child
            parent.Children.Insert(childIndex + 1, newChild);


            // Clean up keys in splitted node middle key which moved to parent + lats keys copied to newChild
            nodeToBeSplited.Keys.RemoveRange(MinDegree - 1, MinDegree);
        }

        private BTreeNode SearchInternal(BTreeNode root, int key)
        {
            int i = 0;

            // search in keys on current level
            while (i < root.Keys.Count && key > root.Keys[i])
            {
                i++;
            }

            // check if we found the key
            if (i != root.Keys.Count &&  key == root.Keys[i])
            {
                return root;
            }

            // no such key
            if (root.IsLeaf)
            {
                return null;
            }

            // do down to related child node based on key value
            return SearchInternal(root.Children[i], key);
        }
    }
}
