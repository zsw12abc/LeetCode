namespace Heap.Problems;

/// <summary>
/// 378. 有序矩阵中第 K 小的元素
/// 给你一个n x n矩阵matrix ，其中每行和每列元素均按升序排序，找到矩阵中第 k 小的元素。
/// 请注意，它是 排序后 的第 k 小元素，而不是第 k 个 不同 的元素。
/// 你必须找到一个内存复杂度优于O(n^2) 的解决方案。
/// </summary>
public static class KthSmallestSolution
{
    public static int KthSmallest(int[][] matrix, int k)
    {
        var pq = new PriorityQueue<int[], int[]>(Comparer<int[]>.Create((a, b) => a[0] - b[0]));
        var n = matrix.Length;
        for (var i = 0; i < n; i++)
        {
            pq.Enqueue(new int[] { matrix[i][0], i, 0 }, new int[] { matrix[i][0], i, 0 });
        }

        for (var i = 0; i < k - 1; i++)
        {
            var now = pq.Dequeue();
            if (now[2] != n - 1)
            {
                pq.Enqueue(new int[] { matrix[now[1]][now[2] + 1], now[1], now[2] + 1 }, new int[] { matrix[now[1]][now[2] + 1], now[1], now[2] + 1 });
            }
        }

        return pq.Dequeue()[0];
    }
}