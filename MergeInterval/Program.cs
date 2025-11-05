public class Solution
{
    public int[][] Merge(int[][] intervals)
    {
        // line sweep algo
        SortedDictionary<int, int> lines = new();
        foreach (int[] interval in intervals)
        {
            lines[interval[0]] = lines.GetValueOrDefault(interval[0], 0) + 1;
            lines[interval[1]] = lines.GetValueOrDefault(interval[1], 0) - 1;
        }

        int cnt = 0;
        List<int[]> ans = new();
        int start = 0;
        foreach (var pair in lines)
        {
            if (cnt == 0)
            {
                start = pair.Key;
            }
            cnt += pair.Value;
            if (cnt == 0)
            {
                ans.Add([start, pair.Key]);
            }
        }
        return ans.ToArray();
    }

    public static void Main(string[] args)
    {
        Solution solution = new();

        int[][] ans = solution.Merge([[1, 3], [2, 6], [8, 10], [15, 18]]);
        foreach (int[] interval in ans)
        {
            Console.WriteLine($"[{interval[0]}, {interval[1]}]");
        }
    }
}