namespace Sort.Problems;

public class MergeSort
{
    public int[] Sort(int[] arr)
    {
        var length = arr.Length;
        if (length < 2)
        {
            return arr;
        }

        int mid = (int)Math.Floor((decimal)(length / 2));
        int[] left = arr[0..mid];
        int[] right = arr[mid..length];
        return Merge(Sort(left), Sort(right));
    }

    private int[] Merge(int[] left, int[] right)
    {
        var result = new int[left.Length + right.Length];
        int i = 0;
        while (left.Length > 0 && right.Length > 0)
        {
            if (left[0] <= right[0])
            {
                result[i++] = left[0];
                left = left[1..left.Length];
            }
            else
            {
                result[i++] = right[0];
                right = right[1..right.Length];
            }
        }

        while (left.Length > 0)
        {
            result[i++] = left[0];
            left = left[1..left.Length];
        }

        while (right.Length > 0)
        {
            result[i++] = right[0];
            right = right[1..right.Length];
        }

        return result;
    }
}