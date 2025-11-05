public class Solution
{
    public int MinGroups(int[][] intervals)
    {
        SortedDictionary<int, int> lines = new();
        foreach (int[] time in intervals)
        {
            int start = time[0], end = time[1] + 1;
            if (lines.ContainsKey(start))
            {
                lines[start]++;
            }
            else
            {
                lines[start] = 1;
            }
            if (lines.ContainsKey(end))
            {
                lines[end]--;
            }
            else
            {
                lines[end] = -1;
            }
        }

        int ans = 0, cnt = 0;
        foreach (KeyValuePair<int, int> pair in lines)
        {
            cnt += pair.Value;
            ans = Math.Max(ans, cnt);
        }

        return ans;
    }

    public static void Main(string[] args)
    {
        Solution sol = new();
        Console.WriteLine(sol.MinGroups([[1, 3], [1, 4], [4, 7], [2, 5], [5, 6]]));
    }
}