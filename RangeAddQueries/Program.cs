public class Solution
{
    public int[][] RangeAddQueries(int n, int[][] queries)
    {
        int[][] res = new int[n][];
        for(int i = 0; i < n; i++)
        {
            res[i] = new int[n];
        }

        // apply difference array technique on 2d arr
        foreach (int[] query in queries)
        {
            int row1 = query[0], row2 = query[2];
            int col1 = query[1], col2 = query[3];
            res[row1][col1]++;
            if (row2 + 1 < n)
            {
                res[row2 + 1][col1]--;
            }
            if (col2 + 1 < n)
            {
                res[row1][col2 + 1]--;
            }
            if (row2 + 1 < n && col2 + 1 < n)
            {
                res[row2 + 1][col2 + 1]++;
            }
        }
        // prefixSum on rows
        for (int j = 0; j < n; j++)
        {
            for (int i = 1; i < n; i++)
            {
                res[i][j] += res[i - 1][j];
            }
        }
        // prefixSum on cols
        for (int i = 0; i < n; i++)
        {
            for (int j = 1; j < n; j++)
            {
                res[i][j] += res[i][j - 1];
            }
        }
        return res;
    }

    public static void Main()
    {
        var sln = new Solution();
        sln.RangeAddQueries(3, [[1, 1, 2, 2], [0, 0, 1, 1]]);
    }
}