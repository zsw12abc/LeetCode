using System;
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
            var result95 = GenerateTreesIiSolution.GenerateTrees(3);

            // 98. 验证二叉搜索树
            var testCase98 = new TreeNode(new List<object>() { 5, 4, 6, null, null, 3, 7 });
            var result98 = IsValidBstSolution.IsValidBst(testCase98);

            // 99. 恢复二叉搜索树
            var testCase99 = new TreeNode(new List<object>() { 3, 1, 4, null, null, 2, null });
            RecoverTreeSolution.RecoverTreeStack(testCase99);

            //100. 相同的树
            var testCase1001 = new TreeNode(new List<object>() { 1, 2, 3, null, null, 4, null });
            var testCase1002 = new TreeNode(new List<object>() { 1, 2, 3, null, null, 4, null });
            IsSameTreeSolution.IsSameTree(testCase1001, testCase1002);

            //101. 对称二叉树
            var testCase101 = new TreeNode(new List<object>() { 1, 2, 2, 3, 4, 4, 3 });
            var result101 = IsSymmetricSolution.IsSymmetric(testCase101);

            //103. 二叉树的锯齿形层序遍历
            var testCase103 = new TreeNode(new List<object>() { 3, 9, 20, null, null, 15, 7 });
            var result103 = ZigzagLevelOrderSolution.ZigzagLevelOrder(testCase103);

            //105. 从前序与中序遍历序列构造二叉树
            var testCase105Preorder = new int[] { 3, 9, 20, 15, 7 };
            var testCase105Inorder = new int[] { 9, 3, 15, 20, 7 };
            var result105 = BuildTreeSolution.BuildTree(testCase105Preorder, testCase105Inorder);
            
            //106. 从中序与后序遍历序列构造二叉树
            var testCase106Inorder = new int[] { 9, 3, 15, 20, 7};
            var testCase106Postorder = new int[] { 9, 15, 7, 20, 3};
            var result106 = BuildTree2Solution.BuildTree(testCase106Inorder, testCase106Postorder);
            
            //110. 平衡二叉树
            var testCase110 = new TreeNode(new List<object>(){1,2,2,3,null, null, 3,4, null, null, 4}) ;
            var result110 = IsBalancedSolution.IsBalanced(testCase110);
        }
    }
}