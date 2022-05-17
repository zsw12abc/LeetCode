using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public class TreeNode
    {
        public int Val;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.Val = val;
            this.Left = left;
            this.Right = right;
        }

        public TreeNode(List<object> numList, int index = 0)
        {
            GenerateTreeViaList(this, numList, index);
        }

        private void GenerateTreeViaList(TreeNode tree, List<object> numList, int index)
        {
            this.Val = (int)(numList[index]);

            if ((index * 2 + 1) < numList.Count)
            {
                if (numList[index * 2 + 1] != null)
                {
                    this.Left = new TreeNode(numList, index * 2 + 1);
                }
                else
                {
                    this.Left = null;
                }
            }

            if ((index * 2 + 2) < numList.Count)
            {
                if (numList[index * 2 + 2] != null)
                {
                    this.Right = new TreeNode(numList, index * 2 + 2);
                }
                else
                {
                    this.Right = null;
                }
            }
        }
    }
}