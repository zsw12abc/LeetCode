using System.Collections.Generic;
using System.Linq;

namespace BinaryTree
{
    /// <summary>
    /// 113. 路径总和 II
    /// 给你二叉树的根节点 root 和一个整数目标和 targetSum ，找出所有 从根节点到叶子节点 路径总和等于给定目标和的路径。
    /// 叶子节点 是指没有子节点的节点。
    /// </summary>
    public class PathSum2Solution
    {
        private static List<IList<int>> result = new List<IList<int>>();

        public static IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            Dfs(root, targetSum, new Stack<int>());
            return result;
        }

        private static void Dfs(TreeNode root, int targetSum, Stack<int> stack)
        {
            if (root == null)
            {
                return;
            }

            stack.Push(root.val);
            targetSum = targetSum - root.val;
            if (root.left == null && root.right == null)
            {
                if (targetSum == 0)
                {
                    AddStackToList(stack);
                }
            }

            if (root.left != null)
            {
                Dfs(root.left, targetSum, stack);
            }

            if (root.right != null)
            {
                Dfs(root.right, targetSum, stack);
            }

            stack.Pop();
            return;
        }

        private static void AddStackToList(Stack<int> stack)
        {
            var level = new List<int>();
            while (stack.Count > 0)
            {
                level.Add(stack.Pop());
            }

            level.Reverse();
            result.Add(level);
            foreach (var l in level)
            {
                stack.Push(l);
            }
        }
    }
}