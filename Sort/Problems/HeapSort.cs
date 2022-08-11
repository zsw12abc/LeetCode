namespace Sort.Problems;

public class HeapSort
{
    public int[] Sort(int[] arr)
    {
        BuildMaxHeap(arr, arr.Length);
        return arr;
    }

    private void BuildMaxHeap(int[] arr, int n)
    {
        int lastNode = n - 1;
        int parent = (lastNode - 1) / 2;
        for (int i = parent; i >= 0; i--)
        {
            MinHeapify(arr, n, i);
        }
    }

    private void MaxHeapify(int[] arr, int n, int i)
    {
        if (i >= n)
        {
            return;
        }

        var c1 = 2 * i + 1;
        var c2 = 2 * i + 2;
        var max = i;
        if (c1 < n && arr[c1] > arr[max])
        {
            max = c1;
        }

        if (c2 < n && arr[c2] > arr[max])
        {
            max = c2;
        }

        if (max != i)
        {
            Swap(arr, i, max);
            MaxHeapify(arr, n, max);
        }
    }

    private void MinHeapify(int[] arr, int n, int i)
    {
        if (i >= n)
        {
            return;
        }

        var c1 = 2 * i + 1;
        var c2 = 2 * i + 2;
        var min = i;
        if (c1 < n && arr[c1] < arr[min])
        {
            min = c1;
        }

        if (c2 < n && arr[c2] < arr[min])
        {
            min = c2;
        }

        if (min != i)
        {
            Swap(arr, i, min);
            MinHeapify(arr, n, min);
        }
    }

    private void Swap(int[] arr, int i, int j)
    {
        (arr[i], arr[j]) = (arr[j], arr[i]);
    }
}