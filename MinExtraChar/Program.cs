public class Solution
{
    int[] memo;
    HashSet<string> dictionarySet;
    public int MinExtraChar(string s, string[] dictionary)
    {
        int n = s.Length;
        memo = new int[n];
        Array.Fill(memo, -1);
        dictionarySet = new HashSet<string>(dictionary);
        return DP(0, n, s);
    }

    private int DP(int start, int n, string s)
    {
        if (start == n)
        {
            return 0;
        }
        if (memo[start] != -1)
        {
            return memo[start];
        }
        int ans = DP(start + 1, n, s) + 1;
        for (int end = start; end < n; end++)
        {
            string curr = s.Substring(start, end + 1 - start);
            if (dictionarySet.Contains(curr))
            {
                ans = Math.Min(ans, DP(end + 1, n, s));
            }
        }

        return memo[start] = ans;
    }

    public static void Main(string[] args)
    {
        Solution sol = new Solution();
        string s = "sayhelloworld";
        string[] dictionary = ["hello", "world"];
        Console.WriteLine(sol.MinExtraChar(s, dictionary));
    }
}