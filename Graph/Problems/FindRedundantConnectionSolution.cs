namespace Graph.Problems
{
    /// <summary>
    /// 684. 冗余连接
    /// 树可以看成是一个连通且 无环的无向图。
    /// 给定往一棵n 个节点 (节点值1～n) 的树中添加一条边后的图。添加的边的两个顶点包含在 1 到 n中间，且这条附加的边不属于树中已存在的边。
    /// 图的信息记录于长度为 n 的二维数组 edges，edges[i] = [ai, bi]表示图中在 ai 和 bi 之间存在一条边。
    /// 请找出一条可以删去的边，删除后可使得剩余部分是一个有着 n 个节点的树。如果有多个答案，则返回数组edges中最后出现的边。
    /// </summary>
    public static class FindRedundantConnectionSolution
    {
        /// <summary>
        /// 并查集
        /// 如果两个顶点属于不同的连通分量，则说明在遍历到当前的边之前，这两个顶点之间不连通，因此当前的边不会导致环出现，合并这两个顶点的连通分量。
        /// 如果两个顶点属于相同的连通分量，则说明在遍历到当前的边之前，这两个顶点之间已经连通，因此当前的边导致环出现，为附加的边，将当前的边作为答案返回。
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        public static int[] FindRedundantConnection(int[][] edges)
        {
            var n = edges.Length;
            var parent = new int[n + 1];
            for (var i = 0; i < n; i++)
            {
                parent[i] = i;
            }

            for (var i = 0; i < n; i++)
            {
                var edge = edges[i];
                var node1 = edge[0];
                var node2 = edge[1];
                if (Find(parent, node1) != Find(parent, node2))
                {
                    Union(parent, node1, node2);
                }
                else
                {
                    return edge;
                }
            }

            return new int[0];
        }

        private static void Union(int[] parent, int index1, int index2)
        {
            parent[Find(parent, index1)] = Find(parent, index2);
        }

        private static int Find(int[] parent, int index)
        {
            if (parent[index] != index)
            {
                parent[index] = Find(parent, parent[index]);
            }

            return parent[index];
        }
    }
}