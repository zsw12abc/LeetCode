using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var tree = new TreeNode(new List<object>() { 1, null, 2, null, null, 3, null });
            //94 Inorder Traversal
            var solution = new InorderTraversalSolution();
            var testCase = new TreeNode(1, null, new TreeNode(2, new TreeNode(3, null, null), null));
            // InorderTraversalSolution.InorderTraversal(testCase);
            InorderTraversalSolution.InorderTraversalIteration(testCase, true);
        }
    }
}