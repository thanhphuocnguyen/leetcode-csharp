public class Solution
{
    // top, bottom, right, left;
    public int IslandPerimeter(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (grid[i][j] == 0)
                {
                    continue;
                }
                int perimeter = 4;
                // top
                if (!EmptyAdj(grid, i - 1, j))
                {
                    perimeter--;
                }
                // bottom
                if (!EmptyAdj(grid, i + 1, j))
                {
                    perimeter--;
                }
                // left
                if (!EmptyAdj(grid, i, j - 1))
                {
                    perimeter--;
                }
                //right
                if (!EmptyAdj(grid, i, j + 1))
                {
                    perimeter--;
                }
                ans += perimeter;
            }
        }
        return ans;
    }

    private bool EmptyAdj(int[][] grid, int adjRow, int adjCol)
    {
        if (adjRow < 0 || adjCol < 0 || adjRow > grid.Length - 1 || adjCol > grid[0].Length - 1 || grid[adjRow][adjCol] == 0)
        {
            return true;
        }
        return false;
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.IslandPerimeter([[0, 1, 0, 0], [1, 1, 1, 0], [0, 1, 0, 0], [1, 1, 0, 0]]));
    }
}