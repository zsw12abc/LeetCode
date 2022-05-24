using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Heap.Problems
{
    /// <summary>
    /// 218. 天际线问题
    /// 城市的 天际线 是从远处观看该城市中所有建筑物形成的轮廓的外部轮廓。给你所有建筑物的位置和高度，请返回 由这些建筑物形成的 天际线 。
    /// 每个建筑物的几何信息由数组 buildings 表示，其中三元组 buildings[i] = [lefti, righti, heighti] 表示：
    ///     lefti 是第 i 座建筑物左边缘的 x 坐标。
    ///     righti 是第 i 座建筑物右边缘的 x 坐标。
    ///     heighti 是第 i 座建筑物的高度。
    /// 你可以假设所有的建筑都是完美的长方形，在高度为 0的绝对平坦的表面上。
    /// 天际线 应该表示为由 “关键点” 组成的列表，格式 [[x1,y1],[x2,y2],...] ，并按 x 坐标 进行 排序 。关键点是水平线段的左端点。列表中最后一个点是最右侧建筑物的终点，y 坐标始终为 0 ，仅用于标记天际线的终点。此外，任何两个相邻建筑物之间的地面都应被视为天际线轮廓的一部分。
    /// 注意：输出天际线中不得有连续的相同高度的水平线。例如 [...[2 3], [4 5], [7 5], [11 5], [12 7]...] 是不正确的答案；三条高度为 5 的线应该在最终输出中合并为一个：[...[2 3], [4 5], [12 7], ...]
    /// </summary>
    public static class GetSkylineSolution
    {
        public static IList<IList<int>> GetSkyline(int[][] buildings)
        {
            var ans = new List<IList<int>>(); //返回列表
            var all = new List<int[]>(); //总排序列表
            var high = new SortedSet<int>(); //高度红黑树
            var highDic = new Dictionary<int, int>(); //记录高度次数
            foreach (var item in buildings)
            {
                all.Add(new int[2] { item[0], -item[2] }); //高度取负表示是开始
                all.Add(new int[2] { item[1], item[2] }); //高度取正表示是结束
            }

            all.Sort((x, y) => x[0] == y[0] ? x[1] - y[1] : x[0] - y[0]); //排序，注意先加入后删除
            foreach (var item in all)
            {
                int o = high.Max, h = item[1];
                if (h < 0) //加入标记
                {
                    if (!highDic.ContainsKey(-h)) highDic[-h] = 0;
                    highDic[-h]++;
                    high.Add(-h);
                }
                else //删除标记
                {
                    highDic[h]--;
                    if (highDic[h] <= 0) high.Remove(h);
                }

                int c = high.Max;
                if (o != c) ans.Add(new List<int> { item[0], c }); //最大高度发生改变时进行记录
            }

            return ans;
        }
    }
}