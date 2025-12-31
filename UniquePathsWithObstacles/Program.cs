int UniquePathsWithObstacles(int[][] obstacleGrid)
{
    int m = obstacleGrid.Length, n = obstacleGrid[0].Length;
    int[,] dp = new int[m, n];
    dp[0, 0] = 1;
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if ((i == 0 && j == 0) || obstacleGrid[i][j] == 1)
            {
                continue;
            }
            if (i > 0)
            {
                dp[i, j] += dp[i - 1, j];
            }
            if (j > 0)
            {
                dp[i, j] += dp[i, j - 1];
            }
        }
    }
    return dp[m - 1, n - 1];
}

Console.WriteLine(UniquePathsWithObstacles([[0, 0, 0], [0, 1, 0], [0, 0, 0]]));