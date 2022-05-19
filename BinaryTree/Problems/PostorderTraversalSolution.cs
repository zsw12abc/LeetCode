using System.Collections.Generic;

namespace BinaryTree
{
    /// <summary>
    /// 145. 二叉树的后序遍历
    /// 给你一棵二叉树的根节点 root ，返回其节点值的 后序遍历 。
    /// </summary>
    public class PostorderTraversalSolution
    {
        private List<int> _result = new List<int>();

        public IList<int> PostorderTraversal(TreeNode root)
        {
            if (root == null)
            {
                return _result;
            }

            PostorderTraversal(root.left);
            PostorderTraversal(root.right);
            _result.Add(root.val);
            return _result;
        }
    }
}