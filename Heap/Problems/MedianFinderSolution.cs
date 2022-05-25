using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace Heap.Problems
{
    /// <summary>
    /// 295. 数据流的中位数
    /// 中位数是有序列表中间的数。如果列表长度是偶数，中位数则是中间两个数的平均值。
    /// 例如，[2,3,4]的中位数是 3
    /// [2,3] 的中位数是 (2 + 3) / 2 = 2.5
    /// 设计一个支持以下两种操作的数据结构：
    /// void addNum(int num) - 从数据流中添加一个整数到数据结构中。
    /// double findMedian() - 返回目前所有元素的中位数。
    /// </summary>
    public class MedianFinderSolution
    {
        private PriorityQueue<int, int> queMin;
        private PriorityQueue<int, int> queMax;

        public MedianFinderSolution()
        {
            queMin = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y - x));
            queMax = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => x - y));
        }

        public void AddNum(int num)
        {
            if (queMin.Count == 0 || num <= queMin.Peek())
            {
                queMin.Enqueue(num, num);
                if (queMax.Count + 1 < queMin.Count)
                {
                    var el = queMin.Dequeue();
                    queMax.Enqueue(el, el);
                }
            }
            else
            {
                queMax.Enqueue(num, num);
                if (queMax.Count > queMin.Count)
                {
                    var el = queMax.Dequeue();
                    queMin.Enqueue(el, el);
                }
            }
        }

        public double FindMedian()
        {
            if (queMin.Count > queMax.Count)
            {
                return queMin.Peek();
            }

            return (queMin.Peek() + queMax.Peek()) / 2.0;
        }
    }
}