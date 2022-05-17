using System.Collections.Generic;

namespace BinaryTree
{
    /// <summary>
    /// 95. 不同的二叉搜索树 II
    /// 给你一个整数 n ，请你生成并返回所有由 n 个节点组成且节点值从 1 到 n 互不相同的不同 二叉搜索树 。可以按 任意顺序 返回答案。
    /// </summary>
    public class GenerateTreesIiSolution
    {
        public static IList<TreeNode> GenerateTrees(int n)
        {
            if (n == 0)
            {
                return new List<TreeNode>();
            }

            return GenerateTrees(1, n);
        }

        private static IList<TreeNode> GenerateTrees(int start, int end)
        {
            var allTrees = new List<TreeNode>();
            if (start > end)
            {
                allTrees.Add(null);
                return allTrees;
            }

            for (var i = start; i <= end; i++)
            {
                var leftTrees = GenerateTrees(start, i - 1);
                var rightTrees = GenerateTrees(i + 1, end);
                foreach (var left in leftTrees)
                {
                    foreach (var right in rightTrees)
                    {
                        var currTree = new TreeNode(i)
                        {
                            Left = left,
                            Right = right
                        };
                        allTrees.Add(currTree);
                    }
                }
            }

            return allTrees;
        }
    }
}