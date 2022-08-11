namespace Sort.Problems;

public class QuickSort
{
    public int[] Sort(int[] arr)
    {
        return Quick(arr, 0, arr.Length - 1);
    }

    private int[] Quick(int[] arr, int left, int right)
    {
        if (left < right)
        {
            var pivot = Partition(arr, left, right);
            Quick(arr, left, pivot - 1);
            Quick(arr, pivot + 1, right);
        }

        return arr;
    }

    private int Partition(int[] arr, int left, int right)
    {
        var pivot = left;
        var index = pivot + 1;
        for (var i = index; i <= right; i++)
        {
            if (arr[i] < arr[pivot])
            {
                Swap(arr, i, index);
                index++;
            }
        }

        Swap(arr, pivot, index - 1);
        return index - 1;
    }

    private void Swap(int[] arr, int i, int j)
    {
        (arr[i], arr[j]) = (arr[j], arr[i]);
    }
}