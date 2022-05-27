// See https://aka.ms/new-console-template for more information

//23. 合并K个升序链表

using Heap.BasicClass;
using Heap.Problems;

var testCase23 = new ListNode[] { new ListNode(new List<int>() { 1, 4, 5 }), new ListNode(new List<int>() { 1, 3, 4 }), new ListNode(new List<int>() { 2, 6 }) };
var result23 = new MergeKListsSolution().MergeKLists(testCase23);
result23.DisplayListNode();

//215. 数组中的第K个最大元素
var testCase215Nums = new int[] { 3, 2, 1, 5, 6, 4 };
var testCase215K = 2;
var result215 = FindKthLargestSolution.FindKthLargest(testCase215Nums, testCase215K);

//218. 天际线问题
var testCase218 = new int[][] { new[] { 0, 3, 2 }, new[] { 1, 4, 3, }, new[] { 3, 5, 4 }, new[] { 5, 7, 3 } };
var result218 = GetSkylineSolution.GetSkyline(testCase218);

//264. 丑数 II
var testCase264 = 19;
var result264 = NthUglyNumberSolution.NthUglyNumber(testCase264);

//295. 数据流的中位数
var MedianFinder = new MedianFinder();
MedianFinder.AddNum(1);
MedianFinder.AddNum(2);
Console.WriteLine(MedianFinder.FindMedian());
MedianFinder.AddNum(3);
Console.WriteLine(MedianFinder.FindMedian());

//347. 前 K 个高频元素
var testCase347Nums = new int[] { 1, 1, 1, 2, 2, 3 };
var testCaseK = 2;
var result347 = TopKFrequentSolution.TopKFrequent(testCase347Nums, testCaseK);

//355. 设计推特
var twitter = new Twitter();
twitter.PostTweet(1, 5);
twitter.PostTweet(1, 3);
twitter.PostTweet(1, 101);
twitter.PostTweet(1, 13);
twitter.PostTweet(1, 10);
twitter.PostTweet(1, 2);
twitter.PostTweet(1, 94);
twitter.PostTweet(1, 505);
twitter.PostTweet(1, 333);
twitter.PostTweet(1, 11);
twitter.GetNewsFeed(1);

//378. 有序矩阵中第 K 小的元素
var testCase378Matrixx = new int[][] { new[] { 1,2 }, new[] { 1, 3 }};
var testCase378K = 2;
var ressult378 = KthSmallestSolution.KthSmallest(testCase378Matrixx, testCase378K);