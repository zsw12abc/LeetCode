using System.Collections.Generic;

namespace BinaryTree
{
    /// <summary>
    /// 199. 二叉树的右视图
    /// 给定一个二叉树的 根节点 root，想象自己站在它的右侧，按照从顶部到底部的顺序，返回从右侧所能看到的节点值。
    /// </summary>
    public class RightSideViewSolution
    {
        public IList<int> RightSideView(TreeNode root)
        {
            var result = new List<int>();
            if (root == null)
            {
                return result;
            }

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var level = new List<int>();
                var len = queue.Count;
                for (int i = 0; i < len; i++)
                {
                    var node = queue.Dequeue();
                    level.Add(node.val);
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }

                result.Add(level[level.Count - 1]);
            }

            return result;
        }
    }
}