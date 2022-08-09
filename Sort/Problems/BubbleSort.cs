namespace Sort.Problems;

public class BubbleSort
{
    public int[] Sort(int[] arr)
    {
        var len = arr.Length;
        for (var i = 0; i < len; i++)
        {
            for (var j = 0; j < len - 1 - i; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                }
            }
        }

        return arr;
    }
}