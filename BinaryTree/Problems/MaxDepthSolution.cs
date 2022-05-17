using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree
{
    /// <summary>
    /// 104. 二叉树的最大深度
    /// 给定一个二叉树，找出其最大深度。
    /// 二叉树的深度为根节点到最远叶子节点的最长路径上的节点数。
    /// 说明: 叶子节点是指没有子节点的节点。
    /// </summary>
    public class MaxDepthSolution
    {
        // 深度优先
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                var leftDepth = MaxDepth(root.left);
                var rightDepth = MaxDepth(root.right);
                return Math.Max(leftDepth, rightDepth) + 1;
            }
        }

        //广度优先算法
        public int MaxDepthBreadth(TreeNode root)
        {
            if (root == null) return 0;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            var depth = 0;
            while (queue.Count > 0)
            {
                var size = queue.Count;
                while (size > 0)
                {
                    var node = queue.Dequeue();
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }

                    size--;
                }

                depth++;
            }

            return depth;
        }
    }
}