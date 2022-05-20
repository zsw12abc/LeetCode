using System.Collections.Generic;

namespace Graph.Problems
{
    /// <summary>
    /// 207. 课程表
    /// 你这个学期必须选修 numCourses 门课程，记为0到numCourses - 1 。
    /// 在选修某些课程之前需要一些先修课程。 先修课程按数组prerequisites 给出，其中prerequisites[i] = [ai, bi] ，表示如果要学习课程ai 则 必须 先学习课程 bi 。
    /// 例如，先修课程对[0, 1] 表示：想要学习课程 0 ，你需要先完成课程 1 。
    /// 请你判断是否可能完成所有课程的学习？如果可以，返回 true ；否则，返回 false 。
    /// </summary>
    public class CanFinishSolution
    {
        private static List<List<int>> _edges;
        private static int[] _visited;
        private static bool _valid = true;

        /// <summary>
        /// 深度优先的拓扑排序
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            _edges = new List<List<int>>();
            for (var i = 0; i < numCourses; i++)
            {
                _edges.Add(new List<int>());
            }

            _visited = new int[numCourses];
            // 导入所有的路径依赖 [0]依赖[1]
            foreach (var info in prerequisites)
            {
                _edges[info[1]].Add(info[0]);
            }

            // 初始化所有的节点为未访问--0
            for (var i = 0; i < numCourses && _valid; i++)
            {
                if (_visited[i] == 0)
                {
                    Dfs(i);
                }
            }

            return _valid;
        }

        /// <summary>
        /// 我们将当前搜索的节点 u 标记为「搜索中」，遍历该节点的每一个相邻节点 v：
        ///     如果 v 为「未搜索」，那么我们开始搜索 v，待搜索完成回溯到 u；
        ///     如果 v 为「搜索中」，那么我们就找到了图中的一个环，因此是不存在拓扑排序的；
        ///     如果 v 为「已完成」，那么说明 v 已经在栈中了，而 u 还不在栈中，因此 u 无论何时入栈都不会影响到 (u, v) 之前的拓扑关系，以及不用进行任何操作。
        /// 当 u 的所有相邻节点都为「已完成」时，我们将 u 放入栈中，并将其标记为「已完成」。
        /// </summary>
        /// <param name="u">搜索的节点</param>
        private static void Dfs(int u)
        {
            _visited[u] = 1; //搜索中
            foreach (var v in _edges[u])
            {
                if (_visited[v] == 0)
                {
                    Dfs(v);
                    if (!_valid)
                    {
                        return;
                    }
                }
                else if (_visited[v] == 1)
                {
                    _valid = false;
                    return;
                }
            }

            _visited[u] = 2; //搜索完
        }


        private static int[] _indeg;

        /// <summary>
        /// 广度搜索拓扑排序
        /// 在广度优先搜索的每一步中，我们取出队首的节点 u：
        /// 我们将 u 放入答案中；
        /// 我们移除 u 的所有出边，也就是将 u 的所有相邻节点的入度减少 1。如果某个相邻节点 v 的入度变为 0，那么我们就将 v 放入队列中。
        /// 在广度优先搜索的过程结束后。如果答案中包含了这 n 个节点，那么我们就找到了一种拓扑排序，否则说明图中存在环，也就不存在拓扑排序了。
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public static bool CanFinishBreadth(int numCourses, int[][] prerequisites)
        {
            _edges = new List<List<int>>();
            for (var i = 0; i < numCourses; i++)
            {
                _edges.Add(new List<int>());
            }

            _indeg = new int[numCourses];
            foreach (var info in prerequisites)
            {
                _edges[info[1]].Add(info[0]);
                ++_indeg[info[0]];
            }

            var queue = new Queue<int>();
            for (var i = 0; i < numCourses; ++i)
            {
                if (_indeg[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            var count = 0;
            while (queue.Count > 0)
            {
                ++count;
                var u = queue.Dequeue();
                foreach (var v in _edges[u])
                {
                    --_indeg[v];
                    if (_indeg[v] == 0)
                    {
                        queue.Enqueue(v);
                    }
                }
            }

            return count == numCourses;
        }
    }
}