﻿using System.Collections.Generic;

namespace BinaryTree
{
    /// <summary>
    /// 101. 对称二叉树
    /// 给你一个二叉树的根节点 root ， 检查它是否轴对称。
    /// </summary>
    public static class IsSymmetricSolution
    {
        public static bool IsSymmetric(TreeNode root)
        {
            return IsSymmetric(root.Left, root.Right);
        }

        private static bool IsSymmetric(TreeNode left, TreeNode right)
        {
            if (left == null && right == null)
            {
                return true;
            }

            if (left == null || right == null)
            {
                return false;
            }

            return left.Val == right.Val && IsSymmetric(left.Left, right.Right) && IsSymmetric(left.Right, right.Left);
        }

        public static bool IsSymmetricQueue(TreeNode root)
        {
            return IsSymmetricQueue(root, root);
        }

        private static bool IsSymmetricQueue(TreeNode left, TreeNode right)
        {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(left);
            queue.Enqueue(right);
            while (queue.Count > 0)
            {
                left = queue.Dequeue();
                right = queue.Dequeue();
                if (left == null && right == null)
                {
                    continue;
                }

                if ((left == null || right == null) || (left.Val != right.Val))
                {
                    return false;
                }

                queue.Enqueue(left.Left);
                queue.Enqueue(right.Right);
                queue.Enqueue(left.Right);
                queue.Enqueue(right.Left);
            }

            return true;
        }
    }
}