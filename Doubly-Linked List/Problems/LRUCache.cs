namespace Doubly_Linked_List.Problems;

/// <summary>
/// 146. LRU 缓存
/// 请你设计并实现一个满足 LRU (最近最少使用) 缓存 约束的数据结构。
/// 实现 LRUCache 类：
///     LRUCache(int capacity) 以 正整数 作为容量capacity 初始化 LRU 缓存
///     int get(int key) 如果关键字 key 存在于缓存中，则返回关键字的值，否则返回 -1 。
///     void put(int key, int value)如果关键字key 已经存在，则变更其数据值value ；如果不存在，则向缓存中插入该组key-value 。如果插入操作导致关键字数量超过capacity ，则应该 逐出 最久未使用的关键字。
/// 函数 get 和 put 必须以 O(1) 的平均时间复杂度运行。
/// </summary>
public class LRUCache
{
    class DLinkedNode
    {
        public int key;
        public int value;
        public DLinkedNode prev;
        public DLinkedNode next;

        public DLinkedNode()
        {
        }

        public DLinkedNode(int _key, int _value)
        {
            key = _key;
            value = _value;
        }
    }

    private Dictionary<int, DLinkedNode> cache = new Dictionary<int, DLinkedNode>();
    private int capacity;
    private int size;
    private DLinkedNode head, tail;

    public LRUCache(int capacity)
    {
        this.size = 0;
        this.capacity = capacity;
        // 使用伪头部和伪尾部节点
        head = new DLinkedNode();
        tail = new DLinkedNode();
        head.next = tail;
        tail.prev = head;
    }

    public int Get(int key)
    {
        if (!cache.ContainsKey(key))
        {
            return -1;
        }

        // 如果 key 存在，先通过哈希表定位，再移到头部
        var node = cache[key];
        MoveToHead(node);
        return node.value;
    }

    public void Put(int key, int value)
    {
        if (!cache.ContainsKey(key))
        {
            // 如果 key 不存在，创建一个新的节点
            var newNode = new DLinkedNode(key, value);
            // 添加进哈希表
            cache.Add(key, newNode);
            // 添加至双向链表的头部
            AddToHead(newNode);
            ++size;
            if (size > capacity)
            {
                // 如果超出容量，删除双向链表的尾部节点
                var tail = RemoveTail();
                // 删除哈希表中对应的项
                cache.Remove(tail.key);
                --size;
            }
        }
        else
        {
            // 如果 key 存在，先通过哈希表定位，再修改 value，并移到头部
            var node = cache[key];
            node.value = value;
            MoveToHead(node);
        }
    }

    private void AddToHead(DLinkedNode node)
    {
        node.prev = head;
        node.next = head.next;
        head.next.prev = node;
        head.next = node;
    }

    private void RemoveNode(DLinkedNode node)
    {
        node.prev.next = node.next;
        node.next.prev = node.prev;
    }

    private void MoveToHead(DLinkedNode node)
    {
        RemoveNode(node);
        AddToHead(node);
    }

    private DLinkedNode RemoveTail()
    {
        var res = tail.prev;
        RemoveNode(res);
        return res;
    }
}