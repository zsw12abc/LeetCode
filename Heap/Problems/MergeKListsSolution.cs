using Heap.BasicClass;

namespace Heap.Problems
{
    /// <summary>
    /// 23. 合并K个升序链表
    /// 给你一个链表数组，每个链表都已经按升序排列。
    /// 请你将所有链表合并到一个升序链表中，返回合并后的链表。
    /// </summary>
    public class MergeKListsSolution
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public ListNode MergeKLists(ListNode[] lists)
        {
            return Merge(lists, 0, lists.Length - 1);
        }

        // 分治合并
        private ListNode Merge(ListNode[] lists, int l, int r)
        {
            if (l == r)
            {
                return lists[l];
            }

            if (l > r)
            {
                return null;
            }

            var mid = (l + r) >> 1;
            return MergeTwoLists(Merge(lists, l, mid), Merge(lists, mid + 1, r));
        }

        private ListNode MergeTwoLists(ListNode a, ListNode b)
        {
            if (a == null || b == null)
            {
                return a ?? b;
            }

            var head = new ListNode(0);
            var tail = head;
            var aPtr = a;
            var bPtr = b;
            while (aPtr != null && bPtr != null)
            {
                if (aPtr.val < bPtr.val)
                {
                    tail.next = aPtr;
                    aPtr = aPtr.next;
                }
                else
                {
                    tail.next = bPtr;
                    bPtr = bPtr.next;
                }

                tail = tail.next;
            }

            tail.next = (aPtr ?? bPtr);
            return head.next;
        }
    }
}