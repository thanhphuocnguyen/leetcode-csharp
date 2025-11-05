public class Solution
{
    public int[][] SortMatrix(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        for (int i = 0; i < m; i++)
        {
            List<int> temp = new();
            for (int j = 0; j + i < n; j++)
            {
                temp.Add(grid[i + j][j]);
            }
            temp.Sort((a, b) => b.CompareTo(a));
            for (int j = 0; j + i < n; j++)
            {
                grid[i + j][j] = temp[j];
            }
        }

        for (int j = 1; j < n; j++)
        {
            List<int> temp = new();
            for (int i = 0; i + j < n; i++)
            {
                temp.Add(grid[i][i + j]);
            }
            temp.Sort();
            for (int i = 0; i + j < n; i++)
            {
                grid[i][i + j] = temp[i];
            }
        }

        return grid;
    }

    public static void Main()
    {
        var sln = new Solution();
        sln.SortMatrix([[1, 7, 3], [9, 8, 2], [4, 5, 6]]);
    }
}