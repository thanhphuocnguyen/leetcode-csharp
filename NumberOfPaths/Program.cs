public class Solution
{
    public int NumberOfPaths(int[][] grid, int k)
    {
        const int MOD = 1_000_000_007;
        int m = grid.Length, n = grid[0].Length;
        int[,,] memo = new int[m, n, k];
        memo[0, 0, grid[0][0] % k] = 1;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == 0 && j == 0)
                {
                    continue;
                }
                for (int l = 0; l < k; l++)
                {
                    int sumMod = (l + grid[i][j]) % k;
                    if (i > 0)
                    {
                        memo[i, j, sumMod] = (memo[i - 1, j, l] + memo[i, j, sumMod]) % MOD;
                    }
                    if (j > 0)
                    {
                        memo[i, j, sumMod] = (memo[i, j - 1, l] + memo[i, j, sumMod]) % MOD;
                    }
                }
            }
        }

        return memo[m - 1, n - 1, 0];
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.NumberOfPaths([[5, 2, 4], [3, 0, 5], [0, 7, 2]], 3));
    }
}