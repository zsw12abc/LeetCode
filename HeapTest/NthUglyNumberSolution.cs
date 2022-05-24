namespace HeapTest;

public class NthUglyNumberSolution
{
    public int NthUglyNumber(int n) {
        var factors = new[] { 2, 3, 5 };
        var seen = new HashSet<int>();
        var heap = new PriorityQueue<int>();
        seen.Add(1);
        heap.Enqueue(1);
        var ugly = 0;
        for (var i = 0; i < n; i++)
        {
            var curr = heap.Dequeue();
            ugly = curr;
            foreach (var factor in factors)
            {
                var next = curr * factor;
                if (seen.Add(next))
                {
                    heap.Enqueue(next);
                }
            }
        }
            

        return ugly;
    }
}