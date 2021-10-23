namespace AlgorithmsAndDataStructures.Trees.BTree
{
    public class BTree
    {
        // minimum degree oder t >=2
        // https://cs.stackexchange.com/a/80294/144521
        private int _t;

        public BTreeNode Root { get; set; }


        public BTree(int t)
        {
            _t = t;
            Root = new BTreeNode(t, false);
        }

        public void Traverse()
        {
            Root?.Traverse();
        }

        public BTreeNode Search(int key)
        {
            if (Root == null)
            {
                return null;
            }

            return Root.Search(key);
        }
    }
}
