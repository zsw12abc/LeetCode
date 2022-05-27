namespace Heap.Problems
{
    /// <summary>
    /// 239. 滑动窗口最大值
    /// 给你一个整数数组 nums，有一个大小为k的滑动窗口从数组的最左侧移动到数组的最右侧。你只可以看到在滑动窗口内的 k个数字。滑动窗口每次只向右移动一位。
    /// 返回 滑动窗口中的最大值 。
    /// </summary>
    public class MaxSlidingWindowSolution
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums == null || nums.Length < 1 || k < 1)
            {
                return null;
            }

            if (nums.Length < 2)
            {
                return nums;
            }

            var list = new LinkedList<int>(); //C#自带的LinkedList就是一个双端队列
            var array = new int[nums.Length - k + 1];
            var tail = 0; //窗口尾部指针
            var head = tail - k + 1; //窗口尾部指针
            while (tail < nums.Length)
            {
                while (list.Count != 0 && nums[list.Last.Value] <= nums[tail])
                {
                    list.RemoveLast(); //移除所有比插入节点小的元素索引（要判空队列不然报错）
                }

                list.AddLast(tail); //插入窗口尾部索引
                if (list.First.Value < head)
                {
                    list.RemoveFirst(); //移除不合法的窗口头部索引（不用while的原因是每次只移动一格）
                }

                if (head >= 0)
                {
                    array[head] = nums[list.First.Value]; //head合法则可以添加进最大值数组
                }

                ++head;
                ++tail;
            }

            return array;
        }
    }
}