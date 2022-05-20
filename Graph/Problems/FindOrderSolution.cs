using System;
using System.Collections.Generic;

namespace Graph.Problems
{
    /// <summary>
    /// 210. 课程表 II
    /// 现在你总共有 numCourses 门课需要选，记为0到numCourses - 1。给你一个数组prerequisites ，其中 prerequisites[i] = [ai, bi] ，表示在选修课程 ai 前 必须 先选修bi 。
    /// 例如，想要学习课程 0 ，你需要先完成课程1 ，我们用一个匹配来表示：[0,1] 。
    /// 返回你为了学完所有课程所安排的学习顺序。可能会有多个正确的顺序，你只要返回 任意一种 就可以了。如果不可能完成所有课程，返回 一个空数组 。
    /// </summary>
    public static class FindOrderSolution
    {
        // 存储有向图
        private static List<List<int>> _edges;

        // 存储每个节点的入度
        private static int[] _indeg;

        // 存储答案
        private static int[] _result;

        // 答案下标
        private static int _index;

        public static int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            _result = new int[numCourses];
            _edges = new List<List<int>>();
            _indeg = new int[numCourses];
            _index = 0;

            for (var i = 0; i < numCourses; i++)
            {
                _edges.Add(new List<int>());
            }

            foreach (var info in prerequisites)
            {
                _edges[info[1]].Add(info[0]);
                ++_indeg[info[0]];
            }

            var queue = new Queue<int>();
            for (var i = 0; i < numCourses; i++)
            {
                if (_indeg[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            while (queue.Count > 0)
            {
                var u = queue.Dequeue();
                _result[_index] = u;
                _index++;
                foreach (var v in _edges[u])
                {
                    --_indeg[v];
                    if (_indeg[v] == 0)
                    {
                        queue.Enqueue(v);
                    }
                }
            }

            return _index != numCourses ? new int[] { } : _result;
        }


        // public static int[] FindOrderDFS(int numCourses, int[][] prerequisites)
        // {
        //   
        // }
    }
}