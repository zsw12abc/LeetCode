using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public TreeNode(List<object> numList, int index = 0)
        {
            GenerateTreeViaList(this, numList, index);
        }

        public void PrintTree()
        {
            Console.WriteLine(
                $"Root Value: {(this.val.ToString())}, Left: {(this.left == null ? "Empty" : this.left.val.ToString())}, Right,{(this.right == null ? "Empty" : this.right.val.ToString())}");
        }

        private void GenerateTreeViaList(TreeNode tree, List<object> numList, int index)
        {
            this.val = (int)(numList[index]);

            if ((index * 2 + 1) < numList.Count)
            {
                if (numList[index * 2 + 1] == null)
                {
                    this.left = null;
                }
                else
                {
                    this.left = new TreeNode(numList, index * 2 + 1);
                }
            }

            if ((index * 2 + 2) < numList.Count)
            {
                if (numList[index * 2 + 2] == null)
                {
                    this.right = null;
                }
                else
                {
                    this.right = new TreeNode(numList, index * 2 + 2);
                }
            }
        }
    }
}