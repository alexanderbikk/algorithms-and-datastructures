using System.Collections.Generic;

namespace LeetCodeMedium.Design
{
    public class LRUCache
    {
        private readonly LinkedList<(int, int)> _cache;
        private readonly Dictionary<int, LinkedListNode<(int, int)>> _keys;
        private int _capacity;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _cache = new LinkedList<(int, int)>();
            _keys = new Dictionary<int, LinkedListNode<(int, int)>>(capacity);
        }

        public int Get(int key)
        {
            if (!_keys.ContainsKey(key))
            {
                return -1;
            }

            var cacheNode = UpdateResentlyUsedCacheItem(key);

            return cacheNode.Value.Item2;
        }

        public void Put(int key, int value)
        {
            if (_keys.ContainsKey(key))
            {
                var existingCacheNode = UpdateResentlyUsedCacheItem(key);
                existingCacheNode.Value = new(key, value);
                return;
            }


            if (_cache.Count == _capacity)
            {
                EvictValue();
            }

            var cacheNode = _cache.AddFirst((key, value));
            _keys.Add(key, cacheNode);
        }

        private LinkedListNode<(int, int)> UpdateResentlyUsedCacheItem(int key)
        {
            var cacheNode = _keys[key];
            _cache.Remove(cacheNode);
            _keys[key] = _cache.AddFirst((cacheNode.Value.Item1, cacheNode.Value.Item2));

            return _keys[key];
        }

        private void EvictValue()
        {
            var cacheNode = _cache.Last;
            _keys.Remove(cacheNode.Value.Item1);
            _cache.RemoveLast();
        }
    }
}
