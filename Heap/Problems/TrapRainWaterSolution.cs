namespace Heap.Problems;

/// <summary>
/// 407. 接雨水 II
/// 给你一个 m x n 的矩阵，其中的值均为非负整数，代表二维高度图每个单元的高度，请计算图中形状最多能接多少体积的雨水。
/// </summary>
public class TrapRainWaterSolution
{
    public int TrapRainWater(int[][] heightMap)
    {
        if (heightMap.Length <= 2 || heightMap[0].Length <= 2)
        {
            return 0;
        }

        var m = heightMap.Length;
        var n = heightMap[0].Length;
        var visit = new bool[m, n];
        var pq = new PriorityQueue<int[], int[]>(Comparer<int[]>.Create((a, b) => a[1] - b[1]));
        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (i == 0 || i == m - 1 || j == 0 || j == n - 1)
                {
                    pq.Enqueue(new int[] { i * n + j, heightMap[i][j] }, new int[] { i * n + j, heightMap[i][j] });
                    visit[i, j] = true;
                }
            }
        }

        var res = 0;
        var dirs = new[] { -1, 0, 1, 0, -1 };
        while (pq.Count > 0)
        {
            var curr = pq.Dequeue();
            for (var k = 0; k < 4; k++)
            {
                var nx = curr[0] / n + dirs[k];
                var ny = curr[0] % n + dirs[k + 1];
                if (nx >= 0 && nx < m && ny >= 0 && ny < n && !visit[nx, ny])
                {
                    if (curr[1] > heightMap[nx][ny])
                    {
                        res += curr[1] - heightMap[nx][ny];
                    }

                    pq.Enqueue(new int[] { nx * n + ny, Math.Max(heightMap[nx][ny], curr[1]) }, new int[] { nx * n + ny, Math.Max(heightMap[nx][ny], curr[1]) });
                    visit[nx, ny] = true;
                }
            }
        }

        return res;
    }
}