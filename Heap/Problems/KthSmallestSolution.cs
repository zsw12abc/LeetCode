namespace Heap.Problems;

/// <summary>
/// 378. 有序矩阵中第 K 小的元素
/// 给你一个n x n矩阵matrix ，其中每行和每列元素均按升序排序，找到矩阵中第 k 小的元素。
/// 请注意，它是 排序后 的第 k 小元素，而不是第 k 个 不同 的元素。
/// 你必须找到一个内存复杂度优于O(n^2) 的解决方案。
/// </summary>
public static class KthSmallestSolution
{
    public static int KthSmallest(int[][] matrix, int k)
    {
        var nums = new int[] { };
        foreach (var row in matrix)
        {
            nums = nums.Concat(row).ToArray();
        }

        var len = nums.Length;
        Build_Heap(nums, len);
        for (var i = 0; i < k - 1; i++)
        {
            Swap(nums, 0, len - i - 1);
            Build_Heap(nums, len - i - 1);
        }

        return nums[0];
    }

    private static void Build_Heap(int[] nums, int end)
    {
        var lastNode = end - 1;
        var parent = (lastNode - 1) / 2;
        for (var i = parent; i >= 0; i--)
        {
            Heapify(nums, end, i);
        }
    }

    private static void Heapify(int[] nums, int len, int index)
    {
        if (index >= len)
        {
            return;
        }
        
        var c1 = 2 * index + 1;
        var c2 = 2 * index + 2;
        var min = index;
        if (c1 < len && nums[min] > nums[c1])
        {
            min = c1;
        }

        if (c2 < len && nums[min] > nums[c2])
        {
            min = c2;
        }

        if (min != index)
        {
            Swap(nums, min, index);
            Heapify(nums, len, min);
        }
    }

    private static void Swap(int[] nums, int a, int b)
    {
        (nums[a], nums[b]) = (nums[b], nums[a]);
    }
}