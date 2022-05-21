﻿using System.Collections.Generic;
using Graph.Problems;

namespace Graph
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //207. 课程表
            var testCase207NumCourses = 4;
            var testCase207Preprequisities = new[] { new[] { 1, 0 }, new[] { 2, 1 }, new[] { 3, 1 }, new[] { 3, 2 } };
            var result207 = CanFinishSolution.CanFinish(testCase207NumCourses, testCase207Preprequisities);
            result207 = CanFinishSolution.CanFinishBreadth(testCase207NumCourses, testCase207Preprequisities);

            // 210. 课程表 II
            var testCase210NumCourses = 2;
            var testCase210Preprequisities = new[] { new[] { 1, 0 } };
            var result210 = FindOrderSolution.FindOrder(testCase210NumCourses, testCase210Preprequisities);
            result210 = FindOrderSolution.FindOrderDfs(testCase210NumCourses, testCase210Preprequisities);

            // 310. 最小高度树
            var testCase310N = 6;
            var testCase310Edges = new[] { new[] { 3, 0 }, new[] { 3, 1 }, new[] { 3, 2 }, new[] { 3, 4 }, new[] { 5, 4 } };
            var result310 = FindMinHeightTreesSolution.FindMinHeightTrees(testCase310N, testCase310Edges);
            result310 = FindMinHeightTreesSolution.FindMinHeightTreesDFS(testCase310N, testCase310Edges);
            result310 = FindMinHeightTreesSolution.FindMinHeightTreesTopological(testCase310N, testCase310Edges);

            //329. 矩阵中的最长递增路径
            var testCase329 = new[] { new[] { 9, 9, 4 }, new[] { 6, 6, 8 }, new[] { 2, 1, 1 } };
            var result329 = LongestIncreasingPathSolution.LongestIncreasingPath(testCase329);

            // 332. 重新安排行程
            IList<IList<string>> testCase332 = new IList<string>[]{ new[] { "JFK", "SFO" }, new[] { "JFK", "ATL" }, new[] { "SFO", "ATL" }, new[] { "ATL", "JFK" }, new[] { "ATL", "SFO" } };
            var result332 = FindItinerarySolution.FindItinerary(testCase332);
        }
    }
}