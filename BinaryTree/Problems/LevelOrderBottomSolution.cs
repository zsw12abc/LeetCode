using System.Collections.Generic;

namespace BinaryTree
{
    /// <summary>
    /// 107. 二叉树的层序遍历 II
    /// 给你二叉树的根节点 root ，返回其节点值 自底向上的层序遍历 。 （即按从叶子节点所在层到根节点所在的层，逐层从左向右遍历）
    /// </summary>
    public class LevelOrderBottomSolution
    {
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            var stack = new Stack<List<int>>();
            if (root == null)
            {
                return new List<IList<int>>();
            }

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var level = new List<int>();
                var size = queue.Count;
                for (var i = 0; i < size; i++)
                {
                    var node = queue.Dequeue();
                    level.Add(node.val);
                    var left = node.left;
                    var right = node.right;
                    if (left != null)
                    {
                        queue.Enqueue(left);
                    }

                    if (right != null)
                    {
                        queue.Enqueue(right);
                    }
                }

                stack.Push(level);
            }

            var levelOrder = new List<IList<int>>();
            while (stack.Count > 0)
            {
                levelOrder.Add(stack.Pop());
            }

            return levelOrder;
        }
    }
}