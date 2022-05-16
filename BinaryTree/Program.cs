﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // 94. 二叉树的中序遍历
            var testCase94 = new TreeNode(new List<object>() { 1, null, 2, null, null, 3, null });
            InorderTraversalSolution.InorderTraversal(testCase94);
            InorderTraversalSolution.InorderTraversalIteration(testCase94);

            // 95. 不同的二叉搜索树 II
            var result95 = GenerateTreesIISolution.GenerateTrees(3);

            // 98. 验证二叉搜索树
            var testCase98 = new TreeNode(new List<object>() { 5, 4, 6, null, null, 3, 7 });
            var result98 = IsValidBSTSolution.IsValidBST(testCase98);

            // 99. 恢复二叉搜索树
            var testCase99 = new TreeNode(new List<object>() { 3, 1, 4, null, null, 2, null });
            RecoverTreeSolution.RecoverTreeStack(testCase99);

            //100. 相同的树
            var testCase100_1 = new TreeNode(new List<object>() { 1, 2, 3, null, null, 4, null });
            var testCase100_2 = new TreeNode(new List<object>() { 1, 2, 3, null, null, 4, null });
            IsSameTreeSolution.IsSameTree(testCase100_1, testCase100_2);

            //101. 对称二叉树
            var testCase101 = new TreeNode(new List<object>() { 1, 2, 2, 3, 4, 4, 3 });
            var result101 = IsSymmetricSolution.IsSymmetric(testCase101);

            //103. 二叉树的锯齿形层序遍历
            var testCase103 = new TreeNode(new List<object>() { 3, 9, 20, null, null, 15, 7 });
            var result103 = ZigzagLevelOrderSolution.ZigzagLevelOrder(testCase103);

            //105. 从前序与中序遍历序列构造二叉树
            var testCase105_preorder = new int[] { 3, 9, 20, 15, 7 };
            var testCase105_inorder = new int[] { 9, 3, 15, 20, 7 };
            var result105 = BuildTreeSolution.BuildTree(testCase105_preorder, testCase105_inorder);
            
            //106. 从中序与后序遍历序列构造二叉树
            var testCase106_inorder = new int[] { 9, 3, 15, 20, 7};
            var testCase106_postorder = new int[] { 9, 15, 7, 20, 3};
            var result106 = BuildTree2Solution.BuildTree(testCase106_inorder, testCase106_postorder);
        }
    }
}