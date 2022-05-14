using System.Collections.Generic;
using System.Diagnostics;

namespace BinaryTree
{
    /// <summary>
    /// 94. 二叉树的中序遍历
    /// 给定一个二叉树的根节点 root ，返回 它的 中序 遍历 。
    /// </summary>
    public class InorderTraversalSolution
    {
        //递归
        public static IList<int> InorderTraversal(TreeNode root)
        {
            IList<int> res = new List<int>();
            Inorder(root, res);
            return res;
        }

        public static void Inorder(TreeNode root, IList<int> res)
        {
            if (root == null)
            {
                return;
            }

            Inorder(root.left, res);
            res.Add((int)root.val);
            Inorder(root.right, res);
        }

        //迭代
        public static IList<int> InorderTraversalIteration(TreeNode root)
        {
            var res = new List<int>();
            var stk = new Stack<TreeNode>();
            while (root != null || stk.Count != 0)
            {
                while (root != null)
                {
                    stk.Push(root);
                    root = root.left;
                }

                root = stk.Pop();
                res.Add((int)root.val);
                root = root.right;
            }

            return res;
        }
    }
}