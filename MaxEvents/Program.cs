public class Solution
{
    public int MaxEvents(int[][] events)
    {
        int ans = 0;
        Array.Sort(events, (a, b) => a[0] - b[0]);

        PriorityQueue<int, int> minHeap = new();
        int day = 1;
        int i = 0;
        while (i < events.Length || minHeap.Count > 0)
        {
            while (i < events.Length && events[i][0] <= day)
            {
                minHeap.Enqueue(events[i][1], events[i][1]);
                i++;
            }

            while (minHeap.Count > 0 && minHeap.Peek() < day)
            {
                minHeap.Dequeue();
            }

            if (minHeap.Count > 0)
            {
                ans++;
                minHeap.Dequeue();
            }

            day++;
        }
        return ans;
    }

    public static void Main(string[] args)
    {
        var sln = new Solution();
        Console.WriteLine(sln.MaxEvents([[1, 2], [2, 3], [3, 4], [1, 2]]));
    }
}