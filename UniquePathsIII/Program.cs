public class Solution
{
    private int[][] directions = [[1, 0], [-1, 0], [0, 1], [0, -1]];

    public int UniquePathsIII(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        bool[,] visited = new bool[m, n];
        int startRow = -1, startCol = -1, cntNeed = 2;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 0)
                {
                    cntNeed++;
                }
                if (grid[i][j] == 1)
                {
                    startRow = i;
                    startCol = j;
                }
            }
        }
        return Backtrack(grid, visited, m, n, startRow, startCol, 1, cntNeed);
    }

    private int Backtrack(int[][] grid, bool[,] visited, int m, int n, int i, int j, int cnt, int cntNeed)
    {
        if (grid[i][j] == 2)
        {
            if (cnt == cntNeed)
            {
                return 1;
            }
            return 0;
        }

        if (visited[i, j])
        {
            return 0;
        }

        int ans = 0;
        visited[i, j] = true;
        foreach (int[] dir in directions)
        {
            int nextRow = i + dir[0], nextCol = j + dir[1];
            if (IsValid(nextRow, nextCol, m, n) && grid[nextRow][nextCol] != -1)
            {
                ans += Backtrack(grid, visited, m, n, nextRow, nextCol, cnt + 1, cntNeed);
            }

        }
        visited[i, j] = false;

        return ans;
    }

    private bool IsValid(int i, int j, int m, int n)
    {
        return i >= 0 && j >= 0 && i < m && j < n;
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.UniquePathsIII([[1, 0, 0, 0], [0, 0, 0, 0], [0, 0, 2, -1]]));
    }
}