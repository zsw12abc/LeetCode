using System.Collections.Generic;
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
            IList<IList<string>> testCase332 = new IList<string>[] { new[] { "JFK", "SFO" }, new[] { "JFK", "ATL" }, new[] { "SFO", "ATL" }, new[] { "ATL", "JFK" }, new[] { "ATL", "SFO" } };
            var result332 = FindItinerarySolution.FindItinerary(testCase332);

            // 399. 除法求值
            IList<IList<string>> testCase399Equations = new IList<string>[] { new[] { "a", "b" }, new[] { "b", "c" } };
            var testCase399Values = new[] { 2.0, 3.0 };
            IList<IList<string>> testCase399Queries = new IList<string>[] { new[] { "a", "c" }, new[] { "b", "a" }, new[] { "a", "e" }, new[] { "a", "a" }, new[] { "x", "x" } };
            var result339 = CalcEquationSolution.CalcEquation(testCase399Equations, testCase399Values, testCase399Queries);

            //547. 省份数量
            var testCase547 = new[] { new[] { 1, 1, 1 }, new[] { 1, 1, 1 }, new[] { 1, 1, 1 } };
            var result547 = FindCircleNumSolution.FindCircleNum(testCase547);
            result547 = FindCircleNumSolution.FindCircleNumBreath(testCase547);

            //684. 冗余连接
            var testCase684 = new[] { new[] { 1, 2 }, new[] { 2, 3 }, new[] { 3, 4 }, new[] { 1, 4 }, new[] { 1, 5 } };
            var result684 = FindRedundantConnectionSolution.FindRedundantConnection(testCase684);

            //685. 冗余连接 II
            var testCase685 = new[] { new[] { 2, 1 }, new[] { 3, 1 }, new[] { 4, 2 }, new[] { 1, 4 } };
            var result685 = FindRedundantDirectedConnectionSolution.FindRedundantDirectedConnection(testCase685);
        }
    }
}