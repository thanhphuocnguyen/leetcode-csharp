public class Solution
{
    public int OddCells(int m, int n, int[][] indices)
    {
        int[,] mat = new int[m, n];
        foreach (int[] coord in indices)
        {
            int row = coord[0], col = coord[1];
            mat[row, col]++;
            for (int i = 0; i < m; i++)
            {
                mat[i, col]++;
            }
            for (int j = 0; j < n; j++)
            {
                mat[row, j]++;
            }
        }
        int oddCnt = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if ((mat[i, j] & 1) != 0)
                {
                    oddCnt++;
                }
            }
        }

        return oddCnt;
    }
    public static void Main()
    {
        var sln = new Solution();
        sln.OddCells(2, 3, [[0, 1], [1, 1]]);
    }
}