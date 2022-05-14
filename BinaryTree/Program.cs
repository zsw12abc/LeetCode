using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //94. 二叉树的中序遍历
            // var testCase = new TreeNode(1, null, new TreeNode(2, new TreeNode(3, null, null), null));
            var testCase = new TreeNode(new List<object>() { 1, null, 2, null, null, 3, null });
            InorderTraversalSolution.InorderTraversal(testCase);
            InorderTraversalSolution.InorderTraversalIteration(testCase, true);
        }
    }
}