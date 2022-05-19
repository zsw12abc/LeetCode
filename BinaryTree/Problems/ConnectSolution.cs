using System.Collections.Generic;

namespace BinaryTree
{
    /// <summary>
    /// 116. 填充每个节点的下一个右侧节点指针
    /// 给定一个完美二叉树，其所有叶子节点都在同一层，每个父节点都有两个子节点
    /// 填充它的每个 next 指针，让这个指针指向其下一个右侧节点。如果找不到下一个右侧节点，
    /// 则将 next 指针设置为 NULL。初始状态下，
    /// 所有next 指针都被设置为 NULL。
    /// </summary>
    public class ConnectSolution
    {
        public Node Connect(Node root)
        {
            if (root == null) return root;

            var queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var len = queue.Count;
                for (int i = 0; i < len; i++)
                {
                    var node = queue.Dequeue();
                    if (i < len - 1)
                    {
                        node.next = queue.Peek();
                    }

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
            }
            return root;
        }
    }
}