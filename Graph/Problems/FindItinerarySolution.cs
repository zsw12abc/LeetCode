using System.Collections.Generic;
using System.Collections.Specialized;

namespace Graph.Problems
{
    /// <summary>
    /// 332. 重新安排行程
    /// 给你一份航线列表 tickets ，其中 tickets[i] = [fromi, toi] 表示飞机出发和降落的机场地点。请你对该行程进行重新规划排序。
    /// 所有这些机票都属于一个从 JFK（肯尼迪国际机场）出发的先生，所以该行程必须从 JFK 开始。如果存在多种有效的行程，请你按字典排序返回最小的行程组合。
    /// 例如，行程 ["JFK", "LGA"] 与 ["JFK", "LGB"] 相比就更小，排序更靠前。
    /// 假定所有机票至少存在一种合理的行程。且所有的机票 必须都用一次 且 只能用一次。
    /// </summary>
    public static class FindItinerarySolution
    {
        private static Dictionary<string, List<string>> _map = new Dictionary<string, List<string>>();
        private static List<string> _itinerary = new List<string>();

        /// <summary>
        /// Hierholzer 算法
        /// 1. 从起点出发，进行深度优先搜索。
        /// 2. 每次沿着某条边从某个顶点移动到另外一个顶点的时候，都需要删除这条边。
        /// 3. 如果没有可移动的路径，则将所在节点加入到栈中，并返回。
        /// </summary>
        /// <param name="tickets"></param>
        /// <returns></returns>
        public static IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            foreach (var t in tickets)
            {
                if (!_map.ContainsKey(t[0]))
                    _map[t[0]] = new List<string>();
                _map[t[0]].Add(t[1]);
            }

            foreach (var s in _map.Keys)
                _map[s].Sort();
            Dfs("JFK");
            return _itinerary;
        }

        private static void Dfs(string curr)
        {
            //用while语句比foreach/for更容易处理边界问题
            while (_map.ContainsKey(curr) && _map[curr].Count != 0)
            {
                var s = _map[curr][0];
                _map[curr].RemoveAt(0);
                Dfs(s);
            }

            //逆序
            _itinerary.Insert(0, curr);
        }
    }
}