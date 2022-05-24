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

        private void GenerateTreeViaList(TreeNode tree, List<object> numList, int index)
        {
            this.val = (int)(numList[index]);

            if ((index * 2 + 1) < numList.Count)
            {
                if (numList[index * 2 + 1] != null)
                {
                    this.left = new TreeNode(numList, index * 2 + 1);
                }
                else
                {
                    this.left = null;
                }
            }

            if ((index * 2 + 2) < numList.Count)
            {
                if (numList[index * 2 + 2] != null)
                {
                    this.right = new TreeNode(numList, index * 2 + 2);
                }
                else
                {
                    this.right = null;
                }
            }
        }
    }
}