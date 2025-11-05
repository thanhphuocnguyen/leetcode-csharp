public class Solution
{
    public int[][] LargestLocal(int[][] grid)
    {
        int n = grid.Length;
        int[][] ans = new int[n - 2][];
        for (int i = 0; i < n - 2; i++)
        {
            ans[i] = new int[n - 2];
        }
        for (int i = 0; i < n - 2; i++)
        {
            for (int j = 0; j < n - 2; j++)
            {
                ans[i][j] = FindMaxInLocalMatrix(grid, i, j);
            }
        }
        return ans;
    }
    private int FindMaxInLocalMatrix(int[][] grid, int row, int col)
    {
        int max = grid[row][col];
        for (int i = row; i < row + 3; i++)
        {
            for (int j = col; j < col + 3; j++)
            {
                max = Math.Max(grid[i][j], max);
            }
        }
        return max;
    }

    public static void Main()
    {
        Solution s = new Solution();
        int[][] grid = [[9, 9, 8, 1], [5, 6, 2, 6], [8, 2, 6, 4], [6, 2, 2, 2]];
        int[][] ans = s.LargestLocal(grid);
        foreach (int[] row in ans)
        {
            foreach (int col in row)
            {
                Console.Write(col + " ");
            }
            Console.WriteLine();
        }
    }
}