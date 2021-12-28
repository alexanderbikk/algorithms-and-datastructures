using AlgorithmsAndDataStructures.Trees.BST;
using System.Text;

namespace LeetCodeMedium.Trees.BinaryTree
{
    public class TreeSerializer
    {
        private readonly StringBuilder _data = new();
        private readonly string _separator = ",";
        private readonly string _nullAlias = "#";

        // Encodes a tree to a single string.
        public string Serialize(Node<int> root)
        {
            _data.Append('[');

            if (root != null)
            {
                SerializeInternal(root);

                _data.Replace(_separator, string.Empty, _data.Length - 1, 1);
            }

            _data.Append(']');

            return _data.ToString();
        }

        // Decodes your encoded data to tree.
        public Node<int> Deserialize(string data)
        {
            if (data == "[]")
            {
                return null;
            }
            var values = GetValues(data);
            var index = 0;

            return DeserializeInternal(values, ref index);
        }

        private void SerializeInternal(Node<int> root)
        {
            if (root == null)
            {
                _data.Append(_nullAlias);
                _data.Append(_separator);
                return;
            }

            _data.Append(root.Value);
            _data.Append(_separator);

            SerializeInternal(root.LeftChild);
            SerializeInternal(root.RightChild);
        }

        private Node<int> DeserializeInternal(string[] values, ref int index)
        {
            var root = values[index] != _nullAlias ? CreateNewNode(values[index]) : null;
            index++;
            if (root == null)
            {
                return root;
            }

            root.LeftChild = DeserializeInternal(values, ref index);
            root.RightChild = DeserializeInternal(values, ref index);

            return root;
        }

        private string[] GetValues(string data)
        {
            var values = data.Split(_separator);
            values[0] = values[0].Replace("[", string.Empty);
            values[^1] = values[^1].Replace("]", string.Empty);

            return values;
        }

        private static Node<int> CreateNewNode(string value)
        {
            var result = int.Parse(value);

            return new Node<int>(result);
        }

    }
}
