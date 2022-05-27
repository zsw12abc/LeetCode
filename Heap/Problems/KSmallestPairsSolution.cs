namespace Heap.Problems;

/// <summary>
/// 373. 查找和最小的 K 对数字
/// 给定两个以 升序排列 的整数数组 nums1 和 nums2,以及一个整数 k。
/// 定义一对值(u,v)，其中第一个元素来自nums1，第二个元素来自 nums2。
/// 请找到和最小的 k个数对(u1,v1), (u2,v2) ... (uk,vk)。
/// </summary>
public class KSmallestPairsSolution
{
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
    {
        var pq = new PriorityQueue<int[], int[]>(
            Comparer<int[]>.Create((x, y) => nums1[x[0]] + nums2[x[1]] - nums1[y[0]] - nums2[y[1]])
        );
        var ans = new List<IList<int>>();
        var m = nums1.Length;
        var n = nums2.Length;
        for (var i = 0; i < Math.Min(m, k); i++)
        {
            pq.Enqueue(new int[] { i, 0 }, new int[] { i, 0 });
        }

        while (k-- > 0 && pq.Count > 0)
        {
            var idxPiar = pq.Dequeue();
            var list = new List<int>();
            list.Add(nums1[idxPiar[0]]);
            list.Add(nums2[idxPiar[1]]);
            ans.Add(list);
            if (idxPiar[1] + 1 < n)
            {
                pq.Enqueue(new[] { idxPiar[0], idxPiar[1] + 1 }, new[] { idxPiar[0], idxPiar[1] + 1 });
            }
        }

        return ans;
    }
}