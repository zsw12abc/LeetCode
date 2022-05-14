namespace BinaryTree
{
    /// <summary>
    /// 98. 验证二叉搜索树
    /// 给你一个二叉树的根节点 root ，判断其是否是一个有效的二叉搜索树。
    /// 有效 二叉搜索树定义如下：
    /// 节点的左子树只包含 小于 当前节点的数。
    /// 节点的右子树只包含 大于 当前节点的数。
    /// 所有左子树和右子树自身必须也是二叉搜索树。
    /// </summary>
    public static class IsValidBSTSolution
    {
        // test case included int.MinValue and int.MaxValue, therefore, need to use long.
        public static bool IsValidBST(TreeNode root)
        {
            return IsValidBST(root, long.MinValue, long.MaxValue);
        }

        private static bool IsValidBST(TreeNode root, long min, long max)
        {
            if (root == null) return true;
            if (root.val <= min || root.val >= max) return false;
            return IsValidBST(root.left, min, root.val) && IsValidBST(root.right, root.val, max);
        }
    }
}