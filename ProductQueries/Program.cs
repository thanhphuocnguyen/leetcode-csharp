public class Solution
{
    public int[] ProductQueries(int n, int[][] queries)
    {
        int MOD = 1000000007;
        List<int> powers = new();
        int currBit = 1;
        while (n > 0)
        {
            if ((n & 1) != 0)
            {
                powers.Add(currBit);
            }
            currBit <<= 1;
            n >>= 1;
        }
        int[,] precomputed = new int[powers.Count, powers.Count];
        for (int i = 0; i < powers.Count; i++)
        {
            long curr = 1;
            for (int j = i; j < powers.Count; j++)
            {
                curr = curr * powers[j] % MOD;
                precomputed[i, j] = (int)curr;
            }
        }
        int[] ans = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            int start = queries[i][0], end = queries[i][1];
            ans[i] = precomputed[start, end];
        }
        return ans;
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.ProductQueries(919, [[5, 5], [4, 4], [0, 1], [1, 5], [4, 6], [6, 6], [5, 6], [0, 3], [5, 5], [5, 6], [1, 2], [3, 5], [3, 6], [5, 5], [4, 4], [1, 1], [2, 4], [4, 5], [4, 4], [5, 6], [0, 4], [3, 3], [0, 4], [0, 5], [4, 4], [5, 5], [4, 6], [4, 5], [0, 4], [6, 6], [6, 6], [6, 6], [2, 2], [0, 5], [1, 4], [0, 3], [2, 4], [5, 5], [6, 6], [2, 2], [2, 3], [5, 5], [0, 6], [3, 3], [6, 6], [4, 4], [0, 0], [0, 2], [6, 6], [6, 6], [3, 6], [0, 4], [6, 6], [2, 2], [4, 6]]));
    }
}