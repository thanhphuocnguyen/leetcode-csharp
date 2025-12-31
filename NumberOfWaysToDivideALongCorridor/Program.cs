public class Solution
{
    private const int MOD = 1_000_000_007;
    public int NumberOfWays(string corridor)
    {
        long[][] memo = new long[corridor.Length][];
        for (int i = 0; i < corridor.Length; i++)
        {
            memo[i] = new long[3];
            Array.Fill(memo[i], -1);
        }

        return (int)Dp(memo, corridor, 0, 0);
    }

    public long Dp(long[][] memo, string corridor, int cnt, int idx)
    {
        if (idx == corridor.Length)
        {
            if (cnt == 2)
            {
                return 1;
            }
            return 0;
        }

        if (memo[idx][cnt] != -1)
        {
            return memo[idx][cnt];
        }

        long ans;
        if (cnt % 2 == 0)
        {
            if (corridor[idx] == 'S')
            {
                ans = Dp(memo, corridor, 1, idx + 1) % MOD;
            }
            else
            {
                ans = (Dp(memo, corridor, 2, idx + 1) + Dp(memo, corridor, 0, idx + 1)) % MOD;
            }
        }
        else
        {
            // skip
            if (corridor[idx] == 'S')
            {
                ans = Dp(memo, corridor, cnt + 1, idx + 1) % MOD;
            }
            else
            {
                ans = Dp(memo, corridor, cnt, idx + 1) % MOD;
            }
        }
        memo[idx][cnt] = ans;
        return memo[idx][cnt];
    }
}

