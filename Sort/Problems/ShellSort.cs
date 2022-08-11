namespace Sort.Problems;

public class ShellSort
{
    public int[] Sort(int[] arr)
    {
        var length = arr.Length;
        int temp;
        for (var step = length / 2; step >= 1; step /= 2)
        {
            for (var i = step; i < length; i++)
            {
                temp = arr[i];
                var j = i - step;
                while (j >= 0 && arr[j] > temp)
                {
                    arr[j + step] = arr[j];
                    j -= step;
                }

                arr[j + step] = temp;
            }
        }

        return arr;
    }
}