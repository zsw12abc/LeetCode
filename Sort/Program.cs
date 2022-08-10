using Sort.Problems;

int[] arr = { 3, 38, 5, 44, 15, 36, 26, 27, 2, 49, 4, 19, 47, 50, 48 };
var bubbleSort = new BubbleSort();
var bubbleSortResult = bubbleSort.Sort(arr);
Console.Out.WriteLine(string.Join(",", bubbleSortResult));

var selectionSort = new SelectionSort();
var selectionSortResult = selectionSort.Sort(arr);
Console.Out.WriteLine(string.Join(",", selectionSortResult));


var insertionSort = new InsertionSort();
var insertionSortResult = insertionSort.Sort(arr);
Console.Out.WriteLine(string.Join(",", insertionSortResult));

var shellSort = new ShellSort();
var shellSortResult = shellSort.Sort(arr);
Console.Out.WriteLine(string.Join(",", shellSortResult));

var mergeSort = new MergeSort();
var mergeSortResult = mergeSort.Sort(arr);
Console.Out.WriteLine(string.Join(",", mergeSortResult));