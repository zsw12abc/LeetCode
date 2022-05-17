using System.Collections.Generic;
using System.Linq;

namespace BinaryTree
{
    /// <summary>
    /// 103. 二叉树的锯齿形层序遍历
    /// 给你二叉树的根节点 root ，返回其节点值的 锯齿形层序遍历 。（即先从左往右，再从右往左进行下一层遍历，以此类推，层与层之间交替进行）。
    /// </summary>
    public static class ZigzagLevelOrderSolution
    {
        public static IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var res = new List<IList<int>>();
            if (root == null)
            {
                return res;
            }

            var isToRight = true;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var count = queue.Count;
                var level = new int[count];
                while (count > 0)
                {
                    var node = queue.Dequeue();
                    level[isToRight ? (level.Length - count) : (count - 1)] = node.Val;
                    count--;
                    if (node.Left != null)
                    {
                        queue.Enqueue(node.Left);
                    }

                    if (node.Right != null)
                    {
                        queue.Enqueue(node.Right);
                    }
                }

                res.Add(level.ToList());
                isToRight = !isToRight;
            }

            return res;
        }
    }
}