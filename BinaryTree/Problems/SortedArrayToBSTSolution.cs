﻿using System.Linq;

namespace BinaryTree
{
    /// <summary>
    /// 108. 将有序数组转换为二叉搜索树
    /// 给你一个整数数组 nums ，其中元素已经按 升序 排列，请你将其转换为一棵 高度平衡 二叉搜索树。
    /// 高度平衡 二叉树是一棵满足「每个节点的左右两个子树的高度差的绝对值不超过 1 」的二叉树。
    /// </summary>
    public class SortedArrayToBstSolution
    {
        public TreeNode SortedArrayToBst(int[] nums)
        {
            var len = nums.Length;
            var midIndex = nums.Length / 2;
            if (nums.Length == 0)
            {
                return null;
            }

            return new TreeNode(nums[midIndex])
            {
                left = SortedArrayToBst(nums.Where((val, index) => index < midIndex).ToArray()),
                right = SortedArrayToBst(nums.Where((val, index) => index > midIndex).ToArray())
            };
        }
    }
}