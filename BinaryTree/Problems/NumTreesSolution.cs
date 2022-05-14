namespace BinaryTree
{
    /// <summary>
    /// 96. 不同的二叉搜索树
    /// 给你一个整数 n ，求恰由 n 个节点组成且节点值从 1 到 n 互不相同的 二叉搜索树 有多少种？
    /// 返回满足题意的二叉搜索树的种数。
    /// </summary>
    public class NumTreesSolution
    {
        public int NumTrees(int n)
        {
            var g = new int[n + 1];
            g[0] = 1;
            g[1] = 1;
            for (var i = 2; i <= n; ++i)
            {
                for (var j = 1; j <= n; ++j)
                {
                    g[i] += g[j - 1] * g[i - j];
                }
            }
            return g[n];
        }
    }
}