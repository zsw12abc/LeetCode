namespace Heap.Problems
{
    /// <summary>
    /// 215. 数组中的第K个最大元素
    /// 给定整数数组 nums 和整数 k，请返回数组中第 k 个最大的元素。
    /// 请注意，你需要找的是数组排序后的第 k 个最大的元素，而不是第 k 个不同的元素。
    /// </summary>
    public static class FindKthLargestSolution
    {
        public static int FindKthLargest(int[] nums, int k)
        {
            var len = nums.Length;
            BuildHeap(nums, len);
            for (var i = 0; i < k - 1; i++)
            {
                Swap(nums, 0, len - i - 1);
                BuildHeap(nums, len - i - 2);
            }

            return nums[0];
        }

        private static void BuildHeap(int[] nums, int n)
        {
            var lastNode = n - 1;
            var parent = (lastNode - 1) / 2;
            for (var i = parent; i >= 0; i--)
            {
                Heapify(nums, n, i);
            }
        }

        private static void Heapify(int[] nums, int n, int i)
        {
            if (i >= n)
            {
                return;
            }

            var c1 = 2 * i + 1;
            var c2 = 2 * i + 2;
            var max = i;
            if (c1 < n && nums[c1] > nums[max])
            {
                max = c1;
            }

            if (c2 < n && nums[c2] > nums[max])
            {
                max = c2;
            }

            if (max != i)
            {
                Swap(nums, max, i);
                Heapify(nums, n, max);
            }
        }

        private static void Swap(int[] a, int i, int j)
        {
            (a[i], a[j]) = (a[j], a[i]);
        }
    }
}