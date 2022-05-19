using System.Collections.Generic;

namespace BinaryTree
{
    /// <summary>
    /// 114. 二叉树展开为链表
    /// 给你二叉树的根结点 root ，请你将它展开为一个单链表：
    /// 展开后的单链表应该同样使用 TreeNode ，其中 right 子指针指向链表中下一个结点，而左子指针始终为 null 。
    /// 展开后的单链表应该与二叉树 先序遍历 顺序相同。
    /// </summary>
    public static class FlattenSolution
    {
        private static List<TreeNode> nodeList = new List<TreeNode>();

        public static void Flatten(TreeNode root)
        {
            Dfs(root);
            if (nodeList.Count == 0)
            {
                return;
            }

            for (var i = 1; i < nodeList.Count; i++)
            {
                var prev = nodeList[i - 1];
                var cur = nodeList[i];
                prev.left = null;
                prev.right = cur;
            }
        }

        private static void Dfs(TreeNode node)
        {
            if (node == null) return;
            nodeList.Add(node);
            Dfs(node.left);
            Dfs(node.right);
        }
    }
}