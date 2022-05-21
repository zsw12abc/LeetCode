using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph.Problems
{
    /// <summary>
    /// 310. 最小高度树
    /// 树是一个无向图，其中任何两个顶点只通过一条路径连接。 换句话说，一个任何没有简单环路的连通图都是一棵树。
    /// 给你一棵包含n个节点的树，标记为0到n - 1 。给定数字n和一个有 n - 1 条无向边的 edges列表（每一个边都是一对标签），其中 edges[i] = [ai, bi] 表示树中节点 ai 和 bi 之间存在一条无向边。
    /// 可选择树中任何一个节点作为根。当选择节点 x 作为根节点时，设结果树的高度为 h 。在所有可能的树中，具有最小高度的树（即，min(h)）被称为 最小高度树 。
    /// 请你找到所有的 最小高度树 并按 任意顺序 返回它们的根节点标签列表。
    /// 树的 高度 是指根节点和叶子节点之间最长向下路径上边的数量。
    /// </summary>
    public static class FindMinHeightTreesSolution
    {
        /// <summary>
        /// 以任意节点 p 出现，利用广度优先搜索或者深度优先搜索找到以 p 为起点的最长路径的终点 x；
        /// 以节点 x 出发，找到以 x 为起点的最长路径的终点 y；
        /// x 到 y 之间的路径即为图中的最长路径，找到路径的中间节点即为根节点。
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public static IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            var ans = new List<int>();
            if (n == 1)
            {
                ans.Add(0);
                return ans;
            }

            var adj = new IList<int>[n];
            for (var i = 0; i < n; i++)
            {
                adj[i] = new List<int>();
            }

            foreach (var edge in edges)
            {
                //无向图需要加入来回双重路径
                adj[edge[0]].Add(edge[1]);
                adj[edge[1]].Add(edge[0]);
            }

            var parent = new int[n];
            parent = parent.Select(i => -1).ToArray();
            var x = FindLongestNode(0, parent, adj);
            var y = FindLongestNode(x, parent, adj);
            var path = new List<int>();
            parent[x] = -1;
            //通过parent记录的上一节点的路径来寻找从Y回到X的路径path
            while (y != -1)
            {
                path.Add(y);
                y = parent[y];
            }

            var m = path.Count;
            if (m % 2 == 0)
            {
                ans.Add(path[m / 2 - 1]);
            }

            ans.Add(path[m / 2]);
            return ans;
        }

        private static int FindLongestNode(int u, int[] parent, IList<int>[] adj)
        {
            var n = adj.Length;
            var queue = new Queue<int>();
            var visit = new bool[n];
            queue.Enqueue(u);
            visit[u] = true;
            var node = -1;
            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                //最后一个pop出queue的就是对于U来说最远的node
                node = curr;
                foreach (var v in adj[curr])
                {
                    if (!visit[v])
                    {
                        visit[v] = true;
                        parent[v] = curr;
                        queue.Enqueue(v);
                    }
                }
            }

            return node;
        }
    }
}