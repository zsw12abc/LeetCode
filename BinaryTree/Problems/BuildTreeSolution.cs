using System.Collections.Generic;

namespace BinaryTree
{
    /// <summary>
    /// 105. 从前序与中序遍历序列构造二叉树
    /// 给定两个整数数组preorder 和 inorder，其中preorder 是二叉树的先序遍历，
    /// inorder是同一棵树的中序遍历，请构造二叉树并返回其根节点。。
    /// </summary>
    public static class BuildTreeSolution
    {
        private static Dictionary<int, int> _inorderDictionary = new Dictionary<int, int>();

        public static TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            for (var i = 0; i < inorder.Length; i++)
            {
                _inorderDictionary.Add(inorder[i], i);
            }

            return BuildTree(preorder, inorder, 0, preorder.Length - 1, 0, inorder.Length - 1);
        }

        private static TreeNode BuildTree(int[] preorder, int[] inorder, int preStart, int preEnd, int inStart, int inEnd)
        {
            if (preStart > preEnd)
            {
                return null;
            }
            var rootVal = preorder[preStart];
            var indexOfRoot = _inorderDictionary[rootVal];
            var lengthOfLeft = indexOfRoot - inStart;
            var root = new TreeNode(rootVal);
            root.left = BuildTree(preorder, inorder, preStart + 1, preStart + lengthOfLeft, inStart, indexOfRoot - 1);
            root.right = BuildTree(preorder, inorder, preStart + lengthOfLeft + 1, preEnd, indexOfRoot + 1, inEnd);
            return root;
        }
    }
}