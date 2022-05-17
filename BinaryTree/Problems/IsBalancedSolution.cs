using System;

namespace BinaryTree
{
    /// <summary>
    /// 110. 平衡二叉树
    /// 给定一个二叉树，判断它是否是高度平衡的二叉树。
    /// 本题中，一棵高度平衡二叉树定义为：
    /// 一个二叉树每个节点 的左右两个子树的高度差的绝对值不超过 1 。
    /// 所有的子树也是平衡二叉树
    /// </summary>
    public class IsBalancedSolution
    {
        public static bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;
            return IsBalancedCheck(root);
        }

        private static bool IsBalancedCheck(TreeNode root)
        {
            return (Math.Abs(MaxDepth(root.left) - MaxDepth(root.right)) <= 1) && IsBalanced(root.left) &&
                   IsBalanced(root.right);
        }

        private static int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
        }
    }
}