using System.Collections.Generic;

namespace Graph.Problems
{
    /// <summary>
    /// 399. 除法求值
    /// 给你一个变量对数组 equations 和一个实数值数组 values 作为已知条件，其中 equations[i] = [Ai, Bi] 和 values[i] 共同表示等式 Ai / Bi = values[i] 。每个 Ai 或 Bi 是一个表示单个变量的字符串。
    /// 另有一些以数组 queries 表示的问题，其中 queries[j] = [Cj, Dj] 表示第 j 个问题，请你根据已知条件找出 Cj / Dj = ? 的结果作为答案。
    /// 返回 所有问题的答案 。如果存在某个无法确定的答案，则用 -1.0 替代这个答案。如果问题中出现了给定的已知条件中没有出现的字符串，也需要用 -1.0 替代这个答案。
    /// 注意：输入总是有效的。你可以假设除法运算中不会出现除数为 0 的情况，且不存在任何矛盾的结果。
    /// </summary>
    public static class CalcEquationSolution
    {
        public static double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            var equationSize = equations.Count;
            var unionFind = new UnionFind(2 * equationSize);
            // 映射变量的值与id, 方便编码
            var hashMap = new Dictionary<string, int>(2 * equationSize);
            var id = 0;
            for (var i = 0; i < equationSize; i++)
            {
                var equation = equations[i];
                var var1 = equation[0];
                var var2 = equation[1];
                // 把equations的内容编码为id
                if (!hashMap.ContainsKey(var1))
                {
                    hashMap.Add(var1, id);
                    id++;
                }

                if (!hashMap.ContainsKey(var2))
                {
                    hashMap.Add(var2, id);
                    id++;
                }

                unionFind.Union(hashMap[var1], hashMap[var2], values[i]);
            }

            //查询 queries的答案
            var queriesSize = queries.Count;
            var res = new double[queriesSize];
            for (var i = 0; i < queriesSize; i++)
            {
                var var1 = queries[i][0];
                var var2 = queries[i][1];

                if (hashMap.TryGetValue(var1, out var id1) == false || hashMap.TryGetValue(var2, out var id2) == false)
                {
                    //如果查询没有节点, 就返回-0.1
                    res[i] = -1.0d;
                }
                else
                {
                    res[i] = unionFind.IsConnected(id1, id2);
                }
            }

            return res;
        }

        private class UnionFind
        {
            private int[] _parent;

            // 指向父节点的权重
            private double[] _weight;

            public UnionFind(int n)
            {
                this._parent = new int[n];
                this._weight = new double[n];

                for (var i = 0; i < n; i++)
                {
                    _parent[i] = i;
                    _weight[i] = 1.0d;
                }
            }

            /// <summary>
            /// 寻找X的root和Y的root, 然后把Xroot指向Yroot, 根据权重修改X的value
            /// </summary>
            /// <param name="x">x节点</param>
            /// <param name="y">y节点</param>
            /// <param name="value">x*y的值</param>
            public void Union(int x, int y, double value)
            {
                var rootX = Find(x);
                var rootY = Find(y);
                if (rootX == rootY)
                {
                    return;
                }

                _parent[rootX] = rootY;
                _weight[rootX] = _weight[y] * value / _weight[x];
            }

            /// <summary>
            /// 路径压缩
            /// </summary>
            /// <param name="x"></param>
            /// <returns></returns>
            private int Find(int x)
            {
                if (x != _parent[x])
                {
                    var origin = _parent[x];
                    _parent[x] = Find(_parent[x]);
                    _weight[x] *= _weight[origin];
                }

                return _parent[x];
            }

            public double IsConnected(int x, int y)
            {
                var rootX = Find(x);
                var rootY = Find(y);
                if (rootX == rootY)
                {
                    return _weight[x] / _weight[y];
                }
                else
                {
                    return -1.0d;
                }
            }
        }
    }
}