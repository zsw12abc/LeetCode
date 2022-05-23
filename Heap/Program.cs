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
        }
    }
}