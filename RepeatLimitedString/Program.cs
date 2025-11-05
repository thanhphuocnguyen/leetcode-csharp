using System.Text;

public class Solution
{
    public string RepeatLimitedString(string s, int repeatLimit)
    {
        Dictionary<char, int> freq = new();
        foreach (char c in s)
        {
            freq[c] = freq.GetValueOrDefault(c, 0) + 1;
        }
        PriorityQueue<char, int> pq = new(Comparer<int>.Create((a, b) => b.CompareTo(a)));

        foreach (char c in freq.Keys)
        {
            pq.Enqueue(c, c - 'a');
        }
        StringBuilder sb = new();
        bool isReachedLimit = false;
        while (pq.Count > 0)
        {
            if (isReachedLimit)
            {
                char c = pq.Dequeue();
                if(pq.Count == 0) {
                    break;
                }
                sb.Append(pq.Peek());
                freq[pq.Peek()]--;
                if (freq[pq.Peek()] == 0)
                {
                    freq.Remove(pq.Dequeue());
                }
                else
                {
                    isReachedLimit = true;
                }
                pq.Enqueue(c, c - 'a');
                isReachedLimit = false;
                continue;
            }
            else
            {
                int numCanAdd = Math.Min(repeatLimit, freq[pq.Peek()]);
                for (int i = 0; i < numCanAdd; i++)
                {
                    sb.Append(pq.Peek());
                    freq[pq.Peek()]--;
                }
                if (freq[pq.Peek()] == 0)
                {
                    freq.Remove(pq.Dequeue());
                }
                else
                {
                    isReachedLimit = true;
                }
            }
        }
        return sb.ToString();
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("");
        var s = new Solution();
        Console.WriteLine(s.RepeatLimitedString("aababab", 2));
    }
}