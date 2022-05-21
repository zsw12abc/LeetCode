using System;
using System.Collections.Generic;

namespace Graph.Problems
{
    /// <summary>
    /// 329. 矩阵中的最长递增路径
    /// 给定一个m x n 整数矩阵matrix ，找出其中 最长递增路径 的长度。
    /// 对于每个单元格，你可以往上，下，左，右四个方向移动。 你 不能 在 对角线 方向上移动或移动到 边界外（即不允许环绕）。
    /// </summary>
    public static class LongestIncreasingPathSolution
    {
        //移动轨迹
        private static readonly int[][] _dirs = new int[][] { new[] { -1, 0 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { 0, 1 } };
        private static int _rows, _columns;

        public static int LongestIncreasingPath(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return 0;
            }

            _rows = matrix.Length;
            _columns = matrix[0].Length;
            var memo = new int[_rows, _columns];
            var ans = 0;
            for (var i = 0; i < _rows; ++i)
            {
                for (var j = 0; j < _columns; ++j)
                {
                    ans = Math.Max(ans, Dfs(matrix, i, j, memo));
                }
            }

            return ans;
        }

        private static int Dfs(int[][] matrix, int row, int column, int[,] memo)
        {
            if (memo[row, column] != 0)
            {
                return memo[row, column];
            }

            ++memo[row, column];
            foreach (var dir in _dirs)
            {
                var newRow = row + dir[0];
                var newColumn = column + dir[1];
                if (newRow >= 0 && newRow < _rows && newColumn >= 0 && newColumn < _columns && matrix[newRow][newColumn] > matrix[row][column])
                {
                    memo[row, column] = Math.Max(memo[row, column], Dfs(matrix, newRow, newColumn, memo) + 1);
                }
            }

            return memo[row, column];
        }

        public static int LongestIncreasingPathTopological(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return 0;
            }

            _rows = matrix.Length;
            _columns = matrix[0].Length;
            var outDegrees = new int[_rows, _columns];
            for (var i = 0; i < _rows; ++i)
            {
                for (var j = 0; j < _columns; ++j)
                {
                    foreach (var dir in _dirs)
                    {
                        var newRow = i + dir[0];
                        var newColumn = j + dir[1];
                        if (newRow >= 0 && newRow < _rows && newColumn >= 0 && newColumn < _columns && matrix[newRow][newColumn] > matrix[i][j])
                        {
                            ++outDegrees[i, j];
                        }
                    }
                }
            }

            var queue = new Queue<int[]>();
            for (var i = 0; i < _rows; ++i)
            {
                for (var j = 0; j < _columns; ++j)
                {
                    if (outDegrees[i, j] == 0)
                    {
                        queue.Enqueue(new int[] { i, j });
                    }
                }
            }

            var ans = 0;
            while (queue.Count > 0)
            {
                ++ans;
                var size = queue.Count;
                for (var i = 0; i < size; ++i)
                {
                    var cell = queue.Dequeue();
                    var row = cell[0];
                    var column = cell[1];
                    foreach (var dir in _dirs)
                    {
                        var newRow = row + dir[0];
                        var newColumn = column + dir[1];
                        if (newRow >= 0 && newRow < _rows && newColumn >= 0 && newColumn < _columns && matrix[newRow][newColumn] > matrix[row][column])
                        {
                            --outDegrees[newRow, newColumn];
                            if (outDegrees[newRow, newColumn] == 0)
                            {
                                queue.Enqueue(new int[] { newRow, newColumn });
                            }
                        }
                    }
                }
            }

            return ans;
        }
    }
}