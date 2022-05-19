using System.Collections.Generic;

namespace BinaryTree
{
    /// <summary>
    /// 144. 二叉树的前序遍历
    /// 给你二叉树的根节点 root ，返回它节点值的 前序 遍历。
    /// </summary>
    public class PreorderTraversalSolution
    {
        private List<int> result = new List<int>();

        public IList<int> PreorderTraversal(TreeNode root)
        {
            if (root == null)
            {
                return result;
            }

            result.Add(root.val);
            PreorderTraversal(root.left);
            PreorderTraversal(root.right);
            return result;
        }
    }
}