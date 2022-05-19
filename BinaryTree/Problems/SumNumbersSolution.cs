using System.Collections.Generic;

namespace BinaryTree
{
    /// <summary>
    /// 129. 求根节点到叶节点数字之和
    /// 给你一个二叉树的根节点 root ，树中每个节点都存放有一个 0 到 9 之间的数字。
    /// 每条从根节点到叶节点的路径都代表一个数字：
    /// 例如，从根节点到叶节点的路径 1 -> 2 -> 3 表示数字 123 。
    /// 计算从根节点到叶节点生成的 所有数字之和 。
    /// 叶节点 是指没有子节点的节点。
    /// </summary>
    public class SumNumbersSolution
    {
        private List<int> leafSumList = new List<int>();

        public int SumNumbers(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            Dfs(root, 0);
            var result = 0;
            foreach (var leafSum in leafSumList)
            {
                result += leafSum;
            }

            return result;
        }

        private void Dfs(TreeNode node, int levelSum)
        {
            if (node == null)
            {
                return;
            }

            levelSum = levelSum * 10 + node.val;
            if (node.left == null && node.right == null)
            {
                leafSumList.Add(levelSum);
                return;
            }

            if (node.left != null)
            {
                Dfs(node.left, levelSum);
            }

            if (node.right != null)
            {
                Dfs(node.right, levelSum);
            }
        }
    }
}