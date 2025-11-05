public class Program
{
    private readonly int[][] directions = [[-1, 0], [1, 0], [0, -1], [0, 1]];

    public int NumIslands(char[][] grid)
    {
        int ans = 0, rows = grid.Length, cols = grid[0].Length;
        bool[,] visited = new bool[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (!visited[row, col] && grid[row][col] == '1')
                {
                    DFS(grid, visited, row, col);
                    ans++;
                }
            }
        }

        return ans;
    }

    private void DFS(char[][] grid, bool[,] visited, int row, int col)
    {
        int n = grid.Length, m = grid[0].Length;
        visited[row, col] = true;
        foreach (int[] direction in directions)
        {
            int newRow = row + direction[0], newCol = col + direction[1];
            if (IsValidIsland(grid, newRow, newCol) && !visited[newRow, newCol])
            {
                DFS(grid, visited, newRow, newCol);
            }
        }
    }

    private bool IsValidIsland(char[][] grid, int row, int col)
    {
        return row < grid.Length && row >= 0 && col >= 0 && col < grid[0].Length && grid[row][col] == '1';
    }

    public static void Main(string[] args)
    {
        Program program = new Program();
        char[][] grid = [['1', '1', '1', '1', '0'], ['1', '1', '0', '1', '0'], ['1', '1', '0', '0', '0'], ['0', '0', '0', '0', '0']];

        Console.WriteLine(program.NumIslands(grid));
    }

}