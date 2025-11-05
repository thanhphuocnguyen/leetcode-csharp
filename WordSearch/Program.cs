public class Solution
{
    int[][] directions = [[1, 0], [-1, 0], [0, 1], [0, -1]];
    public bool Exist(char[][] board, string word)
    {
        int m = board.Length, n = board[0].Length;
        bool[,] visited = new bool[m, n];
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                if (board[i][j] == word[0] && Backtrack(board, visited, word, i, j, 0))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool Backtrack(char[][] board, bool[,] visited, string word, int row, int col, int cIdx)
    {
        if (cIdx == word.Length)
        {
            return true;
        }
        if (!IsValid(row, col, board.Length, board[0].Length) || visited[row, col] || board[row][col] != word[cIdx])
        {
            return false;
        }

        visited[row, col] = true;
        foreach (int[] dir in directions)
        {
            int nextRow = dir[0] + row, nextCol = col + dir[1];

            // search for next word
            if (Backtrack(board, visited, word, nextRow, nextCol, cIdx + 1))
            {
                return true;
            }
        }
        visited[row, col] = false;
        return false;
    }

    private bool IsValid(int row, int col, int m, int n)
    {
        return row >= 0 && row < m && col >= 0 && col < n;
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.Exist([['a']], "a"));
        Console.WriteLine(sln.Exist([['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']], "ABCCED"));
    }
}