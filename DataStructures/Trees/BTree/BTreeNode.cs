using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Trees.BTree
{
    public class BTreeNode
    {
        // minimum degree oder t >=2
        // https://cs.stackexchange.com/a/80294/144521
        private int _minDegree;

        public List<int> Keys { get; set; }

        public List<BTreeNode> Children { get; set; }

        public bool IsLeaf => Children.Count == 0;

        public bool IsMaxKeysCount => Keys.Count == (2 * _minDegree - 1);

        public BTreeNode(int minDegree)
        {
            _minDegree = minDegree;
            Keys = new List<int>(2 * minDegree - 1);
            Children = new List<BTreeNode>(2 * minDegree);
        }
    }
}
