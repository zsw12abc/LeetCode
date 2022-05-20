using System;
using System.Collections.Generic;

namespace BinaryTree
{
    /// <summary>
    /// 111. 二叉树的最小深度
    /// 给定一个二叉树，找出其最小深度。最小深度是从根节点到最近叶子节点的最短路径上的节点数量。
    /// 说明：叶子节点是指没有子节点的节点。
    /// </summary>
    public class MinDepthSolution
    {
        /// <summary>
        /// 广度优先
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MinDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            if (root.left == null || root.right == null)
            {
                return 1;
            }

            var min_depth = Int32.MaxValue;
            if (root.left != null)
            {
                min_depth = Math.Min(MinDepth(root.left), min_depth);
            }

            if (root.right != null)
            {
                min_depth = Math.Min(MinDepth(root.right), min_depth);
            }

            return min_depth + 1;
        }

        /// <summary>
        /// 广度优先搜索
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MinDepthBreadth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var queue = new Queue<QueueNode>();
            queue.Enqueue(new QueueNode(root, 1));
            while (queue.Count > 0)
            {
                var nodeDepth = queue.Dequeue();
                var node = nodeDepth.node;
                var depth = nodeDepth.depth;
                if (node.left == null && node.right == null)
                {
                    return depth;
                }

                if (node.left != null)
                {
                    queue.Enqueue(new QueueNode(node.left, depth + 1));
                }

                if (node.right != null)
                {
                    queue.Enqueue(new QueueNode(node.right, depth + 1));
                }
            }

            return 0;
        }
    }
}