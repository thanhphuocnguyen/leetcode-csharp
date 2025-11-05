public class Program
{
    public int CountSubIslands(int[][] grid1, int[][] grid2)
    {
        int rows = grid1.Length, cols = grid1[0].Length, ans = 0;
        bool[,] visited = new bool[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (grid2[i][j] == 1 && !visited[i, j] && IsSubIsland(grid1, grid2, visited, i, j))
                {
                    ans++;
                }
            }
        }
        return ans;
    }

    private bool IsSubIsland(int[][] grid1, int[][] grid2, bool[,] visited, int row, int col)
    {
        bool isSubIsland = true;
        visited[row, col] = true;
        Queue<int[]> q = new();
        q.Enqueue([row, col]);
        while (q.Count > 0)
        {
            int[] currentCell = q.Dequeue();
            int currRow = currentCell[0], currCol = currentCell[1];
            if (grid1[row][col] == 0)
            {
                isSubIsland = false;
            }
            foreach (int[] direction in directions)
            {
                int newRow = currRow + direction[0], newCol = currCol + direction[1];
                if (IsCellIsland(grid2, newRow, newCol) && !visited[newRow, newCol])
                {
                    visited[newRow, newCol] = true;
                    q.Enqueue([newRow, newCol]);
                }
            }
        }

        return isSubIsland;
    }

    private bool IsCellIsland(int[][] grid, int row, int col)
    {
        return row >= 0 && row < grid.Length && col >= 0 && col < grid[0].Length && grid[row][col] == 1;
    }

    private readonly int[][] directions = [[-1, 0], [1, 0], [0, -1], [0, 1]];
    public static void Main(string[] args)
    {
        int[][] grid1 = [[1, 0, 1, 0, 1], [1, 1, 1, 1, 1], [0, 0, 0, 0, 0], [1, 1, 1, 1, 1], [1, 0, 1, 0, 1]];
        int[][] grid2 = [[0, 0, 0, 0, 0], [1, 1, 1, 1, 1], [0, 1, 0, 1, 0], [0, 1, 0, 1, 0], [1, 0, 0, 0, 1]];
        Program program = new Program();
        Console.WriteLine(program.CountSubIslands(grid1, grid2));
    }

}