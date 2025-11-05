Console.WriteLine("Hello, World!");
long MaxPoints(int[][] points) {
    int rows = points.Length, cols = points[0].Length;
    long[,] dp = new long[rows, cols];
    for (int i = 0; i < cols; i++) {
        dp[0, i] = points[0][i];
    }

    for (int i = 1; i < rows; i++) {
        long[] left = new long[cols];
        long[] right = new long[cols];
        left[0] = dp[i - 1, 0];
        for (int j = 1; j < cols; j++) {
            left[j] = Math.Max(left[j - 1] - 1, dp[i - 1, j]);
        }

        right[cols - 1] = dp[i - 1, cols - 1];
        for (int j = cols - 2; j >= 0; j--) {
            right[j] = Math.Max(right[j + 1] - 1, dp[i - 1, j]);
        }

        for (int j = 0; j < cols; j++) {
            dp[i, j] = Math.Max(left[j], right[j]) + points[i][j];
        }
    }

    long max = 0;
    for (int i = 0; i < cols; i++) {
        max = Math.Max(max, dp[rows - 1, i]);
    }
    return max;
}

int[][] points = new int[][] {
    new int[] {1, 2, 3},
    new int[] {1, 5, 1},
    new int[] {3, 1, 1}
};

Console.WriteLine(MaxPoints(points));