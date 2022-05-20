using Graph.Problems;

namespace Graph
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //207. 课程表
            var testCase207_numCourses = 2;
            var testCase207_preprequisities = new[] { new[] { 1, 0 }, new[] { 0, 1 } };
            var result207 = CanFinishSolution.CanFinish(testCase207_numCourses, testCase207_preprequisities);
            result207 = CanFinishSolution.CanFinishBreadth(testCase207_numCourses, testCase207_preprequisities);
        }
    }
}