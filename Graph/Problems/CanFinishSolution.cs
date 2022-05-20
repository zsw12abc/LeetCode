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
        private List<List<int>> _edges;
        private int[] _visited;
        private bool _valid = true;

        /// <summary>
        /// 深度优先的拓扑排序
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public bool CanFinish(int numCourses, int[][] prerequisites)
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

        private void Dfs(int u)
        {
            _visited[u] = 1;
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

            _visited[u] = 2;
        }

        /// <summary>
        /// 广度搜索拓扑排序
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public bool CanFinishBreadth(int numCourses, int[][] prerequisites)
        {
            _edges = new List<List<int>>();
            for (var i = 0; i < numCourses; i++)
            {
                _edges.Add(new List<int>());
            }

            _visited = new int[numCourses];
            foreach (var info in prerequisites)
            {
                _edges[info[1]].Add(info[0]);
                ++_visited[info[0]];
            }

            var queue = new Queue<int>();
            for (var i = 0; i < numCourses; ++i)
            {
                if (_visited[i] == 0)
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
                    --_visited[v];
                    if (_visited[v] == 0)
                    {
                        queue.Enqueue(v);
                    }
                }
            }

            return count == numCourses;
        }
    }
}