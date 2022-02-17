using System.Collections.Generic;

namespace LeetCodeMedium.Design
{
    public class DoublyLinkedListNode
    {
        public DoublyLinkedListNode Next { get; set; }

        public DoublyLinkedListNode Prev { get; set; }

        public int Key { get; set; }

        public int Value { get; set; }

    }

    public class DoublyLinkedList
    {
        private DoublyLinkedListNode _dummyHead;
        private DoublyLinkedListNode _dummyTail;

        public int Count { get; set; } = 0;

        public DoublyLinkedListNode Last => _dummyTail.Prev;

        public DoublyLinkedList()
        {
            _dummyHead = new DoublyLinkedListNode();
            _dummyTail = new DoublyLinkedListNode();
            _dummyHead.Next = _dummyTail;
            _dummyTail.Prev = _dummyHead;
        }

        public DoublyLinkedListNode AddFirst((int key, int value) item)
        {
            var newNode = new DoublyLinkedListNode
            {
                Key = item.key,
                Value = item.value,
            };

            newNode.Next = _dummyHead.Next;
            newNode.Prev = _dummyHead;

            _dummyHead.Next.Prev = newNode;
            _dummyHead.Next = newNode;

            Count++;
            return newNode;
        }

        public void Remove(DoublyLinkedListNode node)
        {
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;

            node.Next = null;
            node.Prev = null;

            Count--;
        }
    }

    public class LRUCache
    {        
        private readonly DoublyLinkedList _cache;
        private readonly Dictionary<int, DoublyLinkedListNode> _keys;
        private int _capacity;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _cache = new DoublyLinkedList();
            _keys = new Dictionary<int, DoublyLinkedListNode>(capacity);
        }

        public int Get(int key)
        {
            if (!_keys.ContainsKey(key))
            {
                return -1;
            }

            var cacheNode = UpdateResentlyUsedCacheItem(key);

            return cacheNode.Value;
        }

        public void Put(int key, int value)
        {
            if (_keys.ContainsKey(key))
            {
                var existingCacheNode = UpdateResentlyUsedCacheItem(key);
                existingCacheNode.Value = value;
                return;
            }


            if (_cache.Count == _capacity)
            {
                EvictValue();
            }

            var cacheNode = _cache.AddFirst((key, value));
            _keys.Add(key, cacheNode);
        }

        private DoublyLinkedListNode UpdateResentlyUsedCacheItem(int key)
        {
            var cacheNode = _keys[key];

            _cache.Remove(cacheNode);
            _keys[key] = _cache.AddFirst((cacheNode.Key, cacheNode.Value));

            return _keys[key];
        }

        private void EvictValue()
        {
            var cacheNode = _cache.Last;
            _keys.Remove(cacheNode.Key);
            _cache.Remove(cacheNode);
        }
    }



}
