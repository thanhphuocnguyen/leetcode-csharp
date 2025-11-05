public class Solution
{
    private int[][] directions = [[1, 0], [-1, 0], [0, 1], [0, -1]];
    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        int m = heights.Length, n = heights[0].Length;
        IList<IList<int>> ans = new List<IList<int>>();
        bool[,] visitedPac = new bool[m, n];
        bool[,] visitedAtl = new bool[m, n];
        for (int i = 0; i < m; i++)
        {
            if (!visitedPac[i, 0])
            {
                DFS(heights, visitedPac, m, n, i, 0);
            }

            if (!visitedAtl[i, n - 1])
            {
                DFS(heights, visitedAtl, m, n, i, n - 1);
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (!visitedPac[0, i])
            {
                DFS(heights, visitedPac, m, n, 0, i);
            }

            if (!visitedAtl[m - 1, i])
            {
                DFS(heights, visitedAtl, m, n, m - 1, i);
            }
        }
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (visitedPac[i, j] && visitedAtl[i, j])
                {
                    ans.Add([i, j]);
                }
            }
        }
        return ans;
    }

    private void DFS(int[][] heights, bool[,] visited, int m, int n, int r, int c)
    {
        visited[r, c] = true;
        foreach (int[] dir in directions)
        {
            int nextR = r + dir[0], nextC = c + dir[1];
            if (IsValid(nextR, nextC, m, n) && !visited[nextR, nextC] && heights[nextR][nextC] >= heights[r][c])
            {
                DFS(heights, visited, m, n, nextR, nextC);
            }
        }
    }

    private bool IsValid(int r, int c, int m, int n)
    {
        return r >= 0 && c >= 0 && r < m && c < n;
    }

    private static void Main()
    {
        var sln = new Solution();
        sln.PacificAtlantic([[1, 2, 2, 3, 5], [3, 2, 3, 4, 4], [2, 4, 5, 3, 1], [6, 7, 1, 4, 5], [5, 1, 1, 2, 4]]);
    }
}