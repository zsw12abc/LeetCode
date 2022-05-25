namespace Heap.Problems;

/// <summary>
/// 347. 前 K 个高频元素
/// 给你一个整数数组 nums 和一个整数 k ，请你返回其中出现频率前 k 高的元素。你可以按 任意顺序 返回答案。
/// </summary>
public static class TopKFrequentSolution
{
    public static int[] TopKFrequent(int[] nums, int k)
    {
        var trees = new Dictionary<int, int>();
        var result = new int[k];

        foreach (var num in nums)
        {
            if (trees.ContainsKey(num))
            {
                trees[num]++;
            }
            else
            {
                trees.Add(num, 1);
            }
        }

        var len = trees.Count;
        var keyList = new int[len];
        var valueList = new int[len];
        var index = 0;
        foreach (var tree in trees)
        {
            keyList[index] = tree.Key;
            valueList[index] = tree.Value;
            index++;
        }

        if (len == k)
        {
            return keyList;
        }

        for (var i = 0; i < k; i++)
        {
            Build_Heap(keyList, valueList, trees.Count - i);
            result[i] = keyList[0];
            Swap(keyList, 0, trees.Count - 1 - i);
            Swap(valueList, 0, trees.Count - 1 - i);
        }

        return result;
    }

    private static void Build_Heap(int[] keyList, int[] valueList, int n)
    {
        var lastNode = n - 1;
        var parent = (lastNode - 1) / 2;
        for (var i = parent; i >= 0; i--)
        {
            Heapify(keyList, valueList, n, i);
        }
    }

    private static void Heapify(int[] keyList, int[] valueList, int n, int i)
    {
        var c1 = 2 * i + 1;
        var c2 = 2 * i + 2;
        var max = i;
        if (c1 < n && valueList[max] <= valueList[c1])
        {
            max = c1;
        }

        if (c2 < n && valueList[max] <= valueList[c2])
        {
            max = c2;
        }

        if (max != i)
        {
            Swap(valueList, max, i);
            Swap(keyList, max, i);
            Heapify(keyList, valueList, n, max);
        }
    }

    private static void Swap(int[] nums, int a, int b)
    {
        (nums[a], nums[b]) = (nums[b], nums[a]);
    }
}