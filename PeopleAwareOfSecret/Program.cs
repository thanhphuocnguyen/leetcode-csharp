const int MOD = 1_000_000_007;
int PeopleAwareOfSecret(int n, int delay, int forget)
{
    int[] dp = new int[n];
    dp[0] = 1;
    long shared = 0;
    for (int i = 1; i < n; i++)
    {
        if (i - delay >= 0)
        {
            shared += dp[i - delay];
        }
        if (i - forget >= 0)
        {
            shared -= dp[i - forget];
        }
        shared %= MOD;
        dp[i] = (int)shared;
    }

    int ans = 0;

    for (int i = n - forget; i < n; i++)
    {
        ans = (ans + dp[i]) % MOD;
    }
    return ans;
}


Console.WriteLine(PeopleAwareOfSecret(6, 2, 4));
