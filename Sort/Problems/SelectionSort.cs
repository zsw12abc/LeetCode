namespace Sort.Problems;

public class SelectionSort
{
    public int[] Sort(int[] arr)
    {
        var length = arr.Length;
        for (var i = 0; i < length; i++)
        {
            var min = i;
            for (var j = i + 1; j < length; j++)
            {
                if (arr[j] < arr[min])
                {
                    min = j;
                }
            }
            (arr[i], arr[min]) = (arr[min], arr[i]);
        }

        return arr;
    }
}