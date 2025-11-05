public class Solution
{
    private const int MOD = 1000000007;

    public int NumTilings(int n)
    {
        long[] memo = new long[n + 1];
        return (int)DP(n, memo);
    }

    private static long DP(int n, long[] memo)
    {
        if (n <= 1)
        {
            return 1;
        }
        if (n == 2)
        {
            return 2;
        }

        if (memo[n] != 0)
        {
            return memo[n];
        }

        memo[n] = ((DP(n - 1, memo) * 2) + DP(n - 3, memo)) % MOD;
        return memo[n];
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int n = 30; // Example input
        int result = solution.NumTilings(n);
        Console.WriteLine(result); // Output the result
    }
}