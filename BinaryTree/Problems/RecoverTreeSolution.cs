using System.Collections.Generic;

namespace BinaryTree
{
    /// <summary>
    /// 99. 恢复二叉搜索树
    /// 给你二叉搜索树的根节点 root ，该树中的 恰好 两个节点的值被错误地交换。请在不改变其结构的情况下，恢复这棵树 。
    /// </summary>
    public static class RecoverTreeSolution
    {
        public static void RecoverTree(TreeNode root)
        {
            var nums = new List<int>();
            //中序遍历 -- 因为二叉树的中序遍历的结果是单调递增的数列
            Inorder(root, nums);
            //查找2个不是单调递增的节点
            var swapped = FindTwoSwapped(nums);
            //查找两个
            Recover(root, 2, swapped[0], swapped[1]);
        }

        private static void Inorder(TreeNode root, List<int> nums)
        {
            if (root == null)
            {
                return;
            }

            Inorder(root.Left, nums);
            nums.Add(root.Val);
            Inorder(root.Right, nums);
        }

        private static int[] FindTwoSwapped(List<int> nums)
        {
            var n = nums.Count;
            int index1 = -1, index2 = -1;
            for (var i = 0; i < n - 1; i++)
            {
                if (nums[i + 1] < nums[i])
                {
                    index2 = i + 1;
                    if (index1 == -1)
                    {
                        index1 = i;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            var x = nums[index1];
            var y = nums[index2];
            return new[] { x, y };
        }

        private static void Recover(TreeNode root, int count, int x, int y)
        {
            if (root != null)
            {
                if (root.Val == x || root.Val == y)
                {
                    root.Val = root.Val == x ? y : x;
                    if (--count == 0)
                    {
                        return;
                    }
                }

                Recover(root.Right, count, x, y);
                Recover(root.Left, count, x, y);
            }
        }

        // 用stack去做隐藏式的中序遍历
        public static void RecoverTreeStack(TreeNode root)
        {
            var stack = new Stack<TreeNode>();
            TreeNode x = null;
            TreeNode y = null;
            TreeNode pred = null;

            while (stack.Count != 0 || root != null)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.Left;
                }

                root = stack.Pop();
                
                //存一个Pred
                if (pred != null && root.Val < pred.Val)
                {
                    y = root;
                    if (x == null)
                    {
                        x = pred;
                    }
                    else
                    {
                        break;
                    }
                }

                pred = root;
                root = root.Right;
            }

            Swap(x, y);
        }

        private static void Swap(TreeNode x, TreeNode y)
        {
            (x.Val, y.Val) = (y.Val, x.Val);
        }
    }
}