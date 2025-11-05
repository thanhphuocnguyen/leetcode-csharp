int StoneGameII(int[] piles)
{
    int n = piles.Length;
    int[] suffixSum = new int[n];
    suffixSum[n - 1] = piles[n - 1];
    for (int i = n - 2; i >= 0; i--)
    {
        suffixSum[i] = piles[i] + suffixSum[i + 1];
    }

    return MaxStones(suffixSum, 1, 0, new int[n, n]);
}

int MaxStones(int[] suffixSum, int maxTillNow, int currentIdx, int[,] memo)
{
    int n = suffixSum.Length;
    if (currentIdx + 2 * maxTillNow >= n)
    {
        return suffixSum[currentIdx];
    }
    if (memo[currentIdx, maxTillNow] > 0)
    {
        return memo[currentIdx, maxTillNow];
    }

    int res = int.MaxValue;
    for (int i = 1; i <= 2 * maxTillNow; i++)
    {
        res = Math.Min(MaxStones(suffixSum, Math.Max(maxTillNow, i), currentIdx + i, memo), res);
    }
    memo[currentIdx, maxTillNow] = suffixSum[currentIdx] - res;
    return memo[currentIdx, maxTillNow];
}

StoneGameII([2, 7, 9, 4, 4]);