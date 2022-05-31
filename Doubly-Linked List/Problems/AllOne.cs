namespace Doubly_Linked_List.Problems;

/// <summary>
/// 432. 全 O(1) 的数据结构
/// 请你设计一个用于存储字符串计数的数据结构，并能够返回计数最小和最大的字符串。
/// 实现 AllOne 类：
/// AllOne() 初始化数据结构的对象。
///     inc(String key) 字符串 key 的计数增加 1 。如果数据结构中尚不存在 key ，那么插入计数为 1 的 key 。
///     dec(String key) 字符串 key 的计数减少 1 。如果 key 的计数在减少后为 0 ，那么需要将这个 key 从数据结构中删除。测试用例保证：在减少计数前，key 存在于数据结构中。
///     getMaxKey() 返回任意一个计数最大的字符串。如果没有元素存在，返回一个空字符串 "" 。
///     getMinKey() 返回任意一个计数最小的字符串。如果没有元素存在，返回一个空字符串 "" 。
/// 注意：每个函数都应当满足 O(1) 平均时间复杂度。
/// </summary>
public class AllOne
{
    LinkedNode root;
    Dictionary<string, LinkedNode> nodes;

    public AllOne()
    {
        root = new LinkedNode();
        root.Prev = root;
        root.Next = root; // 初始化链表哨兵，下面判断节点的 Next 若为 root，则表示 Next 为空（Prev 同理）
        nodes = new Dictionary<string, LinkedNode>();
    }

    public void Inc(string key)
    {
        if (nodes.ContainsKey(key))
        {
            var cur = nodes[key];
            var nxt = cur.Next;
            if (nxt == root || nxt.Count > cur.Count + 1)
            {
                nodes[key] = cur.Insert(new LinkedNode(key, cur.Count + 1));
            }
            else
            {
                nxt.Keys.Add(key);
                nodes[key] = nxt;
            }

            cur.Keys.Remove(key);
            if (cur.Keys.Count == 0)
            {
                cur.Remove();
            }
        }
        else
        {
            // key 不在链表中
            if (root.Next == root || root.Next.Count > 1)
            {
                nodes.Add(key, root.Insert(new LinkedNode(key, 1)));
            }
            else
            {
                root.Next.Keys.Add(key);
                nodes.Add(key, root.Next);
            }
        }
    }

    public void Dec(string key)
    {
        var cur = nodes[key];
        if (cur.Count == 1)
        {
            // key 仅出现一次，将其移出 nodes
            nodes.Remove(key);
        }
        else
        {
            var pre = cur.Prev;
            if (pre == root || pre.Count < cur.Count - 1)
            {
                nodes[key] = cur.Prev.Insert(new LinkedNode(key, cur.Count - 1));
            }
            else
            {
                pre.Keys.Add(key);
                nodes[key] = pre;
            }
        }

        cur.Keys.Remove(key);
        if (cur.Keys.Count == 0)
        {
            cur.Remove();
        }
    }

    public string GetMaxKey()
    {
        if (root.Prev == null)
        {
            return "";
        }

        var maxKey = "";
        foreach (var key in root.Prev.Keys)
        {
            maxKey = key;
            break;
        }

        return maxKey;
    }

    public string GetMinKey()
    {
        if (root.Next == null)
        {
            return "";
        }

        var minKey = "";
        foreach (var key in root.Next.Keys)
        {
            minKey = key;
            break;
        }

        return minKey;
    }
}

class LinkedNode
{
    public LinkedNode Prev { get; set; }
    public LinkedNode Next { get; set; }
    public ISet<string> Keys { get; set; }
    public int Count { get; set; }

    public LinkedNode() : this("", 0)
    {
    }

    public LinkedNode(string key, int count)
    {
        this.Count = count;
        Keys = new HashSet<string>();
        Keys.Add(key);
    }

    public LinkedNode Insert(LinkedNode node)
    {
        // 在 this 后插入 node
        node.Prev = this;
        node.Next = this.Next;
        node.Prev.Next = node;
        node.Next.Prev = node;
        return node;
    }

    public void Remove()
    {
        this.Prev.Next = this.Next;
        this.Next.Prev = this.Prev;
    }
}