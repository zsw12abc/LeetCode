using System.Collections.Generic;
using Graph.BasicClass;

namespace Graph.Problems
{
    /// <summary>
    /// 133. 克隆图
    /// 给你无向 连通 图中一个节点的引用，请你返回该图的 深拷贝（克隆）。
    /// 图中的每个节点都包含它的值 val（int） 和其邻居的列表（list[Node]）。
    /// 测试用例格式：
    /// 简单起见，每个节点的值都和它的索引相同。例如，第一个节点值为 1（val = 1），第二个节点值为 2（val = 2），以此类推。该图在测试用例中使用邻接列表表示。
    /// 邻接列表 是用于表示有限图的无序列表的集合。每个列表都描述了图中节点的邻居集。
    /// 给定节点将始终是图中的第一个节点（值为 1）。你必须将 给定节点的拷贝 作为对克隆图的引用返回。
    /// </summary>
    public class CloneGraphSolution
    {
        private Dictionary<Node, Node> _visited = new Dictionary<Node, Node>();

        /// <summary>
        /// 深度优先
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node CloneGraph(Node node)
        {
            if (node == null)
            {
                return node;
            }

            if (_visited.ContainsKey(node))
            {
                return _visited[node];
            }

            var cloneNode = new Node(node.val, new List<Node>());
            _visited.Add(node, cloneNode);

            foreach (var nodeNeighbor in node.neighbors)
            {
                cloneNode.neighbors.Add(CloneGraph(nodeNeighbor));
            }

            return cloneNode;
        }

        /// <summary>
        /// 广度优先
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node CloneGraphBreadth(Node node)
        {
            if (node == null)
            {
                return node;
            }

            var visited = new Dictionary<Node, Node>();
            var queue = new Queue<Node>();
            visited.Add(node, new Node(node.val, new List<Node>()));
            while (queue.Count > 0)
            {
                var n = queue.Dequeue();
                foreach (var neighbor in n.neighbors)
                {
                    if (!visited.ContainsKey(neighbor))
                    {
                        visited.Add(neighbor, new Node(neighbor.val, new List<Node>()));
                        queue.Enqueue(neighbor);
                    }

                    visited[n].neighbors.Add(visited[neighbor]);
                }
            }

            return visited[node];
        }
    }
}