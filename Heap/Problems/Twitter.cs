using System.Collections;

namespace Heap.Problems;

public class Twitter
{
    /// <summary>
    /// 355. 设计推特
    /// 设计一个简化版的推特(Twitter)，可以让用户实现发送推文，关注/取消关注其他用户，能够看见关注人（包括自己）的最近 10 条推文。
    /// 实现 Twitter 类：
    /// Twitter() 初始化简易版推特对象
    /// void postTweet(int userId, int tweetId) 根据给定的 tweetId 和 userId 创建一条新推文。每次调用此函数都会使用一个不同的 tweetId 。
    /// List<Integer> getNewsFeed(int userId) 检索当前用户新闻推送中最近  10 条推文的 ID 。新闻推送中的每一项都必须是由用户关注的人或者是用户自己发布的推文。推文必须 按照时间顺序由最近到最远排序 。
    /// void follow(int followerId, int followeeId) ID 为 followerId 的用户开始关注 ID 为 followeeId 的用户。
    /// void unfollow(int followerId, int followeeId) ID 为 followerId 的用户不再关注 ID 为 followeeId 的用户。
    /// </summary>
    private List<int> _userList;

    private Stack _twitterStack;
    private Dictionary<int, List<int>> _followDic;
    private Dictionary<int, List<int>> _userTwitterLink;

    public Twitter()
    {
        _userList = new List<int>();
        _twitterStack = new Stack();
        _followDic = new Dictionary<int, List<int>>();
        _userTwitterLink = new Dictionary<int, List<int>>();
    }

    public void PostTweet(int userId, int tweetId)
    {
        if (!_userList.Contains(userId))
        {
            _userList.Add(userId);
        }

        _twitterStack.Push(tweetId);

        if (!_userTwitterLink.ContainsKey(userId))
        {
            _userTwitterLink.Add(userId, new List<int>() { tweetId });
        }
        else
        {
            _userTwitterLink[userId].Add(tweetId);
        }
    }

    public IList<int> GetNewsFeed(int userId)
    {
        var twitterFeed = new List<int>();
        var result = new List<int>();
        if (_userTwitterLink.ContainsKey(userId))
        {
            twitterFeed = _userTwitterLink[userId];
        }

        if (_followDic.ContainsKey(userId) && _followDic[userId].Count > 0)
        {
            foreach (var followeeId in _followDic[userId])
            {
                if (_userTwitterLink.ContainsKey(followeeId))
                {
                    twitterFeed = twitterFeed.Concat(_userTwitterLink[followeeId]).ToList();
                }
            }
        }

        var copyStack = (Stack)_twitterStack.Clone();
        while (copyStack.Count > 0 && result.Count < 10)
        {
            var feed = (int)copyStack.Pop();
            if (twitterFeed.Contains(feed))
            {
                result.Add(feed);
            }
        }

        return result;
    }

    public void Follow(int followerId, int followeeId)
    {
        if (_followDic.ContainsKey(followerId))
        {
            _followDic[followerId].Add(followeeId);
        }
        else
        {
            _followDic.Add(followerId, new List<int>() { followeeId });
        }
    }

    public void Unfollow(int followerId, int followeeId)
    {
        if (_followDic.ContainsKey(followerId))
        {
            _followDic[followerId].Remove(followeeId);
        }
    }
}