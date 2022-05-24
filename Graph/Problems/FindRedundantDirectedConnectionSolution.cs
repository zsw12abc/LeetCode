namespace Graph.Problems
{
    /// <summary>
    /// 685. 冗余连接 II
    /// 在本问题中，有根树指满足以下条件的 有向 图。该树只有一个根节点，所有其他节点都是该根节点的后继。该树除了根节点之外的每一个节点都有且只有一个父节点，而根节点没有父节点。
    /// 输入一个有向图，该图由一个有着 n 个节点（节点值不重复，从 1 到 n）的树及一条附加的有向边构成。附加的边包含在 1 到 n 中的两个不同顶点间，这条附加的边不属于树中已存在的边。
    /// 结果图是一个以边组成的二维数组edges 。 每个元素是一对 [ui, vi]，用以表示 有向 图中连接顶点 ui 和顶点 vi 的边，其中 ui 是 vi 的一个父节点。
    /// 返回一条能删除的边，使得剩下的图是有 n 个节点的有根树。若有多个答案，返回最后出现在给定二维数组的答案。
    /// </summary>
    public static class FindRedundantDirectedConnectionSolution
    {
        public static int[] FindRedundantDirectedConnection(int[][] edges)
        {
            var n = edges.Length;
            var parent = new int[n + 1];
            var ancestor = new int[n + 1];
            for (var i = 0; i < n; i++)
            {
                ancestor[i] = i;
            }

            for (var i = 0; i <= n; i++)
            {
                parent[i] = i;
            }

            var conflict = -1;
            var cycle = -1;
            for (var i = 0; i < n; i++)
            {
                var edge = edges[i];
                var node1 = edge[0];
                var node2 = edge[1];
                if (parent[node2] != node2)
                {
                    conflict = i;
                }
                else
                {
                    parent[node2] = node1;
                    if (Find(ancestor, node1) == Find(ancestor, node2))
                    {
                        cycle = i;
                    }
                    else
                    {
                        Union(ancestor, node1, node2);
                    }
                }
            }

            if (conflict < 0)
            {
                var redundant = new int[] { edges[cycle][0], edges[cycle][1] };
                return redundant;
            }
            else
            {
                var conflictEdge = edges[conflict];
                if (cycle >= 0)
                {
                    var redundant = new int[] { parent[conflictEdge[1]], conflictEdge[1] };
                    return redundant;
                }
                else
                {
                    var redundant = new int[] { conflictEdge[0], conflictEdge[1] };
                    return redundant;
                }
            }
        }

        private static void Union(int[] ancestor, int index1, int index2)
        {
            ancestor[Find(ancestor, index1)] = Find(ancestor, index2);
        }

        private static int Find(int[] ancestor, int index)
        {
            if (ancestor[index] != index)
            {
                ancestor[index] = Find(ancestor, ancestor[index]);
            }

            return ancestor[index];
        }
    }
}