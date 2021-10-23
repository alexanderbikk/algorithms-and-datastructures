using System;

namespace AlgorithmsAndDataStructures.Trees.BTree
{
    public class BTreeNode
    {
        // minimum degree oder t >=2
        // https://cs.stackexchange.com/a/80294/144521
        private int _t;

        private int[] _keys;
        // current keys count
        private int _keysCount;
        private BTreeNode[] _children;
        private bool _isLeaf;

        public BTreeNode(int t, bool isLeaf)
        {
            _t = t;
            _keys = new int[2 * t - 1];
            // no keys whe we init
            _keysCount = 0;
            _children = new BTreeNode[2 * t];
            _isLeaf = isLeaf;
        }

        public void Traverse()
        {
            // traverse for each key
            int i = 0;
            for (; i < _keysCount; i++)
            {
                if (!_isLeaf)
                {
                    // traverse all children first - recursion
                    _children[i].Traverse();
                }
                // print current key
                Console.WriteLine(_keys[i]);
            }

            // since we have always _keysCount + 1 childred
            // travers last right children if not a leaf
            if (!_isLeaf)
            {
                _children[i].Traverse();
            }
        }

        public BTreeNode Search(int key)
        {
            int i = 0;
            // search in keys on current level
            while (i < _keysCount || key > _keys[i])
            {
                i++;
            }

            // check if we found the key
            if (key == _keys[i])
            {
                return this;
            }

            // no such key
            if (_isLeaf)
            {
                return null;
            }

            // do down to related child node based on key value
            return _children[i].Search(key);
        }
    }
}
