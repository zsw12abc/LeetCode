// See https://aka.ms/new-console-template for more information

using Doubly_Linked_List.BasicClass;
using Doubly_Linked_List.Problems;

//430. 扁平化多级双向链表
var testCase430Node1 = new Node { val = 1 };
var testCase430Node2 = new Node { val = 2 };
var testCase430Node3 = new Node { val = 3 };
var testCase430Node4 = new Node { val = 4 };
var testCase430Node5 = new Node { val = 5 };
var testCase430Node6 = new Node { val = 6 };
var testCase430Node7 = new Node { val = 7 };
testCase430Node1.next = testCase430Node2;
testCase430Node2.prev = testCase430Node1;
testCase430Node2.next = testCase430Node4;
testCase430Node4.prev = testCase430Node2;
testCase430Node1.child = testCase430Node3;
testCase430Node3.next = testCase430Node5;
testCase430Node5.prev = testCase430Node3;
testCase430Node3.child = testCase430Node6;
testCase430Node6.next = testCase430Node7;
testCase430Node7.prev = testCase430Node6;

var testResult = FlattenSolution.Flatten(testCase430Node1);

//432. 全 O(1) 的数据结构
var allOne = new AllOne();
allOne.Inc("a");
allOne.Inc("b");
allOne.Inc("a");
allOne.Inc("b");
allOne.Inc("a");
allOne.Inc("c");
allOne.GetMaxKey(); // 返回 "hello"
allOne.GetMinKey(); // 返回 "leet"

//460. LFU 缓存
// [[3],[2,2],[1,1],[2],[1],[2],[3,3],[4,4],[3],[2],[1],[4]]
var lfu = new LFUCache(3);
lfu.Put(2, 2);
lfu.Put(1,1);
lfu.Get(2);
lfu.Get(1);
lfu.Get(2);
lfu.Put(3,3);
lfu.Put(4,4);
lfu.Get(3);
lfu.Get(2);
lfu.Get(1);
lfu.Get(4);