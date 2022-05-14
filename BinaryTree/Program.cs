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
            var result95 = GenerateTreesIISolution.GenerateTrees(3);
            
            // 98. 验证二叉搜索树
            var testCase98 = new TreeNode(new List<object>() { 5, 4, 6, null, null, 3, 7 });
            var result98 = IsValidBSTSolution.IsValidBST(testCase98);
        }
    }
}