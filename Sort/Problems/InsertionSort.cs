namespace Sort.Problems;

public class InsertionSort
{
    public int[] Sort(int[] arr)
    {
        var len = arr.Length;
        int preIndex, current;
        for (var i = 1; i < len; i++)
        {
            preIndex = i - 1;
            current = arr[i];
            while (preIndex >= 0 && arr[preIndex] > current)
            {
                arr[preIndex + 1] = arr[preIndex];
                preIndex--;
            }

            arr[preIndex + 1] = current;
        }

        return arr;
    }
}