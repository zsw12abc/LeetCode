namespace BinaryTree
{
    /// <summary>
    /// 100. 相同的树
    /// 给你两棵二叉树的根节点 p 和 q ，编写一个函数来检验这两棵树是否相同。
    /// 如果两个树在结构上相同，并且节点具有相同的值，则认为它们是相同的。
    /// </summary>
    public static class IsSameTreeSolution
    {
        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            return CheckTwoTree(p, q);
        }

        private static bool CheckTwoTree(TreeNode p, TreeNode q)
        {
            var result = true;
            if (p == null && q != null)
            {
                return false;
            }

            if (p != null && q == null)
            {
                return false;
            }

            if (p == null && q == null)
            {
                return true;
            }

            if (p.Val != q.Val)
            {
                return false;
            }
            else
            {
                result = result && CheckTwoTree(p.Left, q.Left);
                result = result && CheckTwoTree(p.Right, q.Right);
            }

            return result;
        }
    }
}