namespace BinaryTree
{
    public class QueueNode
    {
        public TreeNode node;
        public int depth;

        public QueueNode(TreeNode node, int depth)
        {
            this.node = node;
            this.depth = depth;
        }
    }
}