using System.Text;

public class Solution
{
    public int StrangePrinter(string s)
    {
        s = RemoveDuplicates(s);
        int n = s.Length;
        int[][] memo = new int[n][];
        for (int i = 0; i < n; i++)
            memo[i] = new int[n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                memo[i][j] = -1;
            }
        }
        return MinimumTurns(0, n - 1, s, memo);
    }

    private string RemoveDuplicates(string s)
    {
        var sb = new StringBuilder();
        int i = 0;
        while (i < s.Length)
        {
            char curr = s[i];
            sb.Append(curr);
            while (i < s.Length && s[i] == curr)
            {
                i++;
            }
        }
        return sb.ToString();
    }

    private int MinimumTurns(int start, int end, string s, int[][] memo)
    {
        if (start > end)
        {
            return 0;
        }
        if (memo[start][end] != -1)
        {
            return memo[start][end];
        }
        int minTurns = 1 + MinimumTurns(start + 1, end, s, memo);
        for (int i = start + 1; i <= end; i++)
        {
            if (s[start] == s[i])
            {
                int turnsWithMatch = MinimumTurns(start, i - 1, s, memo) + MinimumTurns(i + 1, end, s, memo);
                minTurns = Math.Min(turnsWithMatch, minTurns);
            }
        }

        return memo[start][end] = minTurns;
    }

    public static void Main()
    {
        var sol = new Solution();
        Console.WriteLine(sol.StrangePrinter("abcda"));
    }

}