namespace LeetCode.NumMagicSquaresInside;

public class Solution
{
    public int NumMagicSquaresInside(int[][] grid)
    {
        int count = 0;
        int n = grid.Length, m = grid[0].Length;
        for (int i = 0; i <= n - 3; i++)
        {
            for (int j = 0; j <= m - 3; j++)
            {
                if (IsMagicSquare(grid, i, j))
                {
                    count++;
                }
            }
        }

        return count;
    }
    private bool IsMagicSquare(int[][] grid, int rowStart, int colStart)
    {
        int rowSum = 0;
        int colSum = 0;
        bool[] seen = new bool[10];

        int firstRowSum = grid[rowStart][colStart] + grid[rowStart][colStart + 1] + grid[rowStart][colStart + 2];

        for (int i = rowStart; i < rowStart + 3; i++)
        {
            for (int j = colStart; j < colStart + 3; j++)
            {
                if (grid[i][j] < 1 || grid[i][j] > 9 || seen[grid[i][j]])
                {
                    return false;
                }
                seen[grid[i][j]] = true;
            }
        }
        // check cols
        for (int i = colStart; i < colStart + 3; i++)
        {
            if ((grid[rowStart][i] + grid[rowStart + 1][i] + grid[rowStart + 2][i]) != firstRowSum)
            {
                return false;
            }
        }

        // check rows
        for (int i = rowStart + 1; i < rowStart + 3; i++)
        {
            if ((grid[i][colStart] + grid[i][colStart + 1] + grid[i][colStart + 2]) != firstRowSum)
            {
                return false;
            }
        }
        int sumDig1 = grid[rowStart][colStart] + grid[rowStart + 1][colStart + 1] + grid[rowStart + 2][colStart + 2];
        int sumDig2 = grid[rowStart][colStart + 2] + grid[rowStart + 1][colStart + 1] + grid[rowStart + 2][colStart];

        return sumDig1 == firstRowSum && sumDig2 == firstRowSum;
    }

    public static void Main(string[] args)
    {
        var sol = new Solution();
        int[][] grid = new int[][]
        {
            new int[] {4, 3, 8, 4},
            new int[] {9, 5, 1, 9},
            new int[] {2, 7, 6, 2}
        };
        Console.WriteLine(sol.NumMagicSquaresInside(grid));
    }
}