public class Solution
{
    public string FindLexSmallestString(string s, int a, int b)
    {
        int n = s.Length;
        HashSet<string> seen = new();
        string smallest = s;
        Queue<string> q = new();
        q.Enqueue(smallest.Substring(n - b) + smallest.Substring(0, n - b));
        while (q.Count > 0)
        {
            string candidate = q.Dequeue();
            if (smallest.CompareTo(candidate) > 0)
            {
                smallest = candidate;
            }
            char[] chars = candidate.ToCharArray();
            // add a to odd positions
            for (int i = 1; i < n; i += 2)
            {
                chars[i] = (char)((chars[i] - '0' + a) % 10 + '0');
            }
            string transformed = new string(chars);
            if (!seen.Contains(transformed))
            {
                seen.Add(transformed);
                q.Enqueue(transformed);
            }
            // rotate b
            string rotated = candidate.Substring(n - b) + candidate.Substring(0, n - b);
            if (!seen.Contains(rotated))
            {
                seen.Add(rotated);
                q.Enqueue(rotated);
            }
        }
        return smallest;
    }

    public static void Main()
    {
        var solution = new Solution();
        Console.WriteLine(solution.FindLexSmallestString("5525", 9, 2));
    }
}