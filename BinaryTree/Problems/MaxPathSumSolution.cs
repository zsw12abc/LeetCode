using System;

namespace BinaryTree
{
    /// <summary>
    /// 124. 二叉树中的最大路径和
    /// 路径 被定义为一条从树中任意节点出发，沿父节点-子节点连接，达到任意节点的序列。同一个节点在一条路径序列中 至多出现一次 。该路径 至少包含一个 节点，且不一定经过根节点。
    /// 路径和 是路径中各节点值的总和。
    /// 给你一个二叉树的根节点 root ，返回其 最大路径和 。
    /// </summary>
    public class MaxPathSumSolution
    {
        private int maxSum = Int32.MinValue;

        public int MaxPathSum(TreeNode root)
        {
            MaxSum(root);
            return maxSum;
        }

        private int MaxSum(TreeNode node)
        {
            if (node == null) return 0;

            var leftMax = Math.Max(MaxSum(node.left), 0);
            var rightMax = Math.Max(MaxSum(node.right), 0);
            var totalSum = leftMax + rightMax + node.val;
            maxSum = Math.Max(maxSum, totalSum);
            return node.val + Math.Max(leftMax, rightMax);
        }
    }
}