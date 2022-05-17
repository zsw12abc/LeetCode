using System.Collections.Generic;
using System.Linq;

namespace BinaryTree
{
    /// <summary>
    /// 109. 有序链表转换二叉搜索树
    /// 给定一个单链表的头节点 head，其中的元素 按升序排序 ，将其转换为高度平衡的二叉搜索树。
    /// 本题中，一个高度平衡二叉树是指一个二叉树每个节点的左右两个子树的高度差不超过 1。
    /// </summary>
    public class SortedListToBst2Solution
    {
        private ListNode _globalHead = new ListNode();

        public TreeNode SortedListToBst(ListNode head)
        {
            _globalHead = head;
            var length = GetLength(head);
            return BuildTree(0, length - 1);
        }

        private int GetLength(ListNode head)
        {
            var ret = 0;
            while (head != null)
            {
                ++ret;
                head = head.Next;
            }

            return ret;
        }

        private TreeNode BuildTree(int left, int right)
        {
            if (left > right)
            {
                return null;
            }

            var mid = (left + right + 1) / 2;
            var root = new TreeNode();
            root.Left = BuildTree(left, mid - 1);
            root.Val = _globalHead.Val;
            _globalHead = _globalHead.Next;
            root.Right = BuildTree(mid + 1, right);
            return root;
        }
    }
}