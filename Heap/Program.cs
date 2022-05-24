using System.Collections.Generic;
using Heap.BasicClass;
using Heap.Problems;

namespace Heap
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //23. 合并K个升序链表
            var testCase23 = new ListNode[] { new ListNode(new List<int>() { 1, 4, 5 }), new ListNode(new List<int>() { 1, 3, 4 }), new ListNode(new List<int>() { 2, 6 }) };
            var result23 = new MergeKListsSolution().MergeKLists(testCase23);
            result23.DisplayListNode();

            //215. 数组中的第K个最大元素
            var testCase215Nums = new int[] { 3, 2, 1, 5, 6, 4 };
            var testCase215K = 2;
            var result215 = FindKthLargestSolution.FindKthLargest(testCase215Nums, testCase215K);
        }
    }
}