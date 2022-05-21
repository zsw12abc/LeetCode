using Graph.Problems;

namespace Graph
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //207. 课程表
            var testCase207_numCourses = 4;
            var testCase207_preprequisities = new[] { new[] { 1, 0 }, new[] { 2, 1 }, new[] { 3, 1 }, new[] { 3, 2 } };
            var result207 = CanFinishSolution.CanFinish(testCase207_numCourses, testCase207_preprequisities);
            result207 = CanFinishSolution.CanFinishBreadth(testCase207_numCourses, testCase207_preprequisities);

            // 210. 课程表 II
            var testCase210_numCourses = 2;
            var testCase210_preprequisities = new[] { new[] { 1, 0 } };
            var result210 = FindOrderSolution.FindOrder(testCase210_numCourses, testCase210_preprequisities);
            result210 = FindOrderSolution.FindOrderDfs(testCase210_numCourses, testCase210_preprequisities);

            // 310. 最小高度树
            var testCase310_n = 6;
            var testCase310_edges = new[] { new[] { 3, 0 }, new[] { 3, 1 }, new[] { 3, 2 }, new[] { 3, 4 }, new[] { 5, 4 } };
            var result310 = FindMinHeightTreesSolution.FindMinHeightTrees(testCase310_n, testCase310_edges);
        }
    }
}