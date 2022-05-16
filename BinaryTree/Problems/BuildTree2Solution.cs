using System.Collections.Generic;

namespace BinaryTree
{
    /// <summary>
    /// 106. 从中序与后序遍历序列构造二叉树
    /// 给定两个整数数组 inorder 和 postorder ，其中 inorder 是二叉树的中序遍历， postorder 是同一棵树的后序遍历，请你构造并返回这颗 二叉树 。
    /// </summary>
    public class BuildTree2Solution
    {
        private static Dictionary<int, int> inorderDictionary = new Dictionary<int, int>();

        public static TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            var len = inorder.Length;
            for (int i = 0; i < len; i++)
            {
                inorderDictionary.Add(inorder[i], i);
            }

            return BuildTree(inorder, postorder, 0, len - 1, 0, len - 1);
        }

        private static TreeNode BuildTree(int[] inorder, int[] postorder, int inStart, int inEnd, int postStart,
            int postEnd)
        {
            if (inStart > inEnd)
            {
                return null;
            }

            var rootVal = postorder[postEnd];
            var rootIndex = inorderDictionary[rootVal];
            var leftLen = rootIndex - inStart;
            var root = new TreeNode(rootVal) { };
            root.left = BuildTree(inorder, postorder, inStart, rootIndex - 1, postStart, postStart + leftLen - 1);
            root.right = BuildTree(inorder, postorder, rootIndex + 1, inEnd, postStart + leftLen, postEnd - 1);
            return root;
        }
    }
}