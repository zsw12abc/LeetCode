using System;
using System.Collections.Generic;

namespace Graph.Problems
{
    /// <summary>
    /// 547. 省份数量
    /// 有 n 个城市，其中一些彼此相连，另一些没有相连。如果城市 a 与城市 b 直接相连，且城市 b 与城市 c 直接相连，那么城市 a 与城市 c 间接相连。
    /// 省份 是一组直接或间接相连的城市，组内不含其他没有相连的城市。
    /// 给你一个 n x n 的矩阵 isConnected ，其中 isConnected[i][j] = 1 表示第 i 个城市和第 j 个城市直接相连，而 isConnected[i][j] = 0 表示二者不直接相连。
    /// 返回矩阵中 省份 的数量。
    /// </summary>
    public static class FindCircleNumSolution
    {
        /// <summary>
        /// 深度优先
        /// </summary>
        /// <param name="isConnected"></param>
        /// <returns>省份的数量</returns>
        public static int FindCircleNum(int[][] isConnected)
        {
            var cities = isConnected.Length;
            var provinces = 0;
            var visited = new bool[cities];
            for (var i = 0; i < cities; i++)
            {
                if (!visited[i])
                {
                    Dfs(isConnected, visited, cities, i);
                    provinces++;
                }
            }

            return provinces;
        }

        private static void Dfs(int[][] isConnected, bool[] visited, int cities, int i)
        {
            for (var j = 0; j < cities; j++)
            {
                if (!visited[i] && isConnected[i][j] == 1)
                {
                    visited[j] = true;
                    Dfs(isConnected, visited, cities, j);
                }
            }
        }

        /// <summary>
        /// 广度优先
        /// </summary>
        /// <param name="isConnected"></param>
        /// <returns></returns>
        public static int FindCircleNumBreath(int[][] isConnected)
        {
            var cities = isConnected.Length;
            var visited = new bool[cities];
            var provinces = 0;
            var queue = new Queue<int>();
            for (var i = 0; i < cities; i++)
            {
                if (!visited[i])
                {
                    queue.Enqueue(i);
                    while (queue.Count > 0)
                    {
                        var j = queue.Dequeue();
                        visited[j] = true;
                        for (var k = 0; k < cities; k++)
                        {
                            if (isConnected[j][k] == 1 && !visited[k])
                            {
                                queue.Enqueue(k);
                            }
                        }
                    }

                    provinces++;
                }
            }

            return provinces;
        }
    }
}