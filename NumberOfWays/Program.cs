public class Solution
{
    public int NumberOfWays(int n, int x)
    {
        int MOD = 1000000007;
        int[] dp = new int[n + 1];
        dp[0] = 1;
        int[] precomputed = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            precomputed[i] = (int)Math.Pow(i, x);
        }

        for (int i = 1; i < precomputed.Length; i++)
        {
            int diff = precomputed[i];
            for (int j = n - diff; j >= 0; j--)
            {
                dp[j + diff] = (dp[j + diff] + dp[j]) % MOD;
            }
        }

        return dp[n];
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.NumberOfWays(4, 1));
    }
}