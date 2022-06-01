using System.Data;

namespace Doubly_Linked_List.Problems;

/// <summary>
/// 460. LFU 缓存
/// 请你为 最不经常使用（LFU）缓存算法设计并实现数据结构。
/// 实现 LFUCache 类：
///     LFUCache(int capacity) - 用数据结构的容量capacity 初始化对象
///     int get(int key)- 如果键key 存在于缓存中，则获取键的值，否则返回 -1 。
///     void put(int key, int value)- 如果键key 已存在，则变更其值；如果键不存在，请插入键值对。当缓存达到其容量capacity 时，则应该在插入新项之前，移除最不经常使用的项。
///     在此问题中，当存在平局（即两个或更多个键具有相同使用频率）时，应该去除 最近最久未使用 的键。
///     为了确定最不常使用的键，可以为缓存中的每个键维护一个 使用计数器 。使用计数最小的键是最久未使用的键。
/// 当一个键首次插入到缓存中时，它的使用计数器被设置为 1 (由于 put 操作)。对缓存中的键执行 get 或 put 操作，使用计数器的值将会递增。
/// 函数 get 和 put 必须以 O(1) 的平均时间复杂度运行。
/// </summary>
public class LFUCache
{
    private Dictionary<int, int> cache;
    private Dictionary<int, int> keyFreqDic;
    private int capacity;
    private Dictionary<int, IList<int>> freKeyListDic;
    private int min;
    private List<int> minQueue;

    public LFUCache(int capacity)
    {
        this.capacity = capacity;
        cache = new Dictionary<int, int>();
        keyFreqDic = new Dictionary<int, int>();
        freKeyListDic = new Dictionary<int, IList<int>>();
        min = 0;
        minQueue = new List<int>();
    }

    public int Get(int key)
    {
        if (cache.ContainsKey(key))
        {
            UpdateFreq(key);
            UpdateMinFreq();
            return cache[key];
        }
        else
        {
            return -1;
        }
    }

    public void Put(int key, int value)
    {
        if (capacity != 0)
        {
            if (cache.ContainsKey(key))
            {
                cache[key] = value;
                UpdateFreq(key);
            }
            else
            {
                if (cache.Count == capacity)
                {
                    RemoveLowestKey();
                }

                cache.Add(key, value);

                AddFreq(key, 1);
            }
        }
    }

    private void UpdateFreq(int key)
    {
        var prefreq = keyFreqDic[key];
        var freqKeyList = freKeyListDic[prefreq];
        freqKeyList.Remove(key);
        if (freqKeyList.Count == 0)
        {
            freKeyListDic.Remove(prefreq);
            minQueue.Remove(prefreq);
        }

        if (freKeyListDic.ContainsKey(prefreq + 1))
        {
            freKeyListDic[prefreq + 1].Add(key);
        }
        else
        {
            freKeyListDic.Add(prefreq + 1, new List<int>() { key });
            minQueue.Add(prefreq + 1);
        }

        keyFreqDic[key] += 1;
        UpdateMinFreq();
    }

    private void RemoveLowestKey()
    {
        if (freKeyListDic.ContainsKey(min))
        {
            var lowFreqKey = freKeyListDic[min].First();
            freKeyListDic[min].RemoveAt(0);
            keyFreqDic.Remove(lowFreqKey);
            cache.Remove(lowFreqKey);
            if (freKeyListDic[min].Count == 0)
            {
                freKeyListDic.Remove(min);
                minQueue.Remove(min);
            }

            UpdateMinFreq();
        }
    }

    private void AddFreq(int key, int freq)
    {
        keyFreqDic.Add(key, freq);
        if (freKeyListDic.ContainsKey(freq))
        {
            freKeyListDic[freq].Add(key);
        }
        else
        {
            freKeyListDic.Add(freq, new List<int>() { key });
            minQueue.Add(freq);
        }

        UpdateMinFreq();
    }

    private void UpdateMinFreq()
    {
        minQueue.Sort();
        min = minQueue.Count > 0 ? minQueue[0] : 0;
    }
}