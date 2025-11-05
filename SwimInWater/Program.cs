public class Solution
{
    public int SwimInWater(int[][] grid)
    {
        int[][] directions = [[1, 0], [-1, 0], [0, 1], [0, -1]];
        int n = grid.Length;
        int[,] dist = new int[n, n];
        bool[,] visited = new bool[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                dist[i, j] = int.MaxValue;
            }
        }
        dist[0, 0] = 0;
        PriorityQueue<int[], int> pq = new();
        pq.Enqueue([0, 0], grid[0][0]);
        int ans = 0;
        while (pq.TryDequeue(out int[] coord, out int elv))
        {
            int i = coord[0], j = coord[1];
            ans = Math.Max(ans, elv);

            if (i == n - 1 && j == n - 1)
            {
                return ans;
            }

            visited[i, j] = true;
            foreach (int[] dir in directions)
            {
                int nextR = i + dir[0];
                int nextC = j + dir[1];
                if (IsValid(nextR, nextC, n) && !visited[nextR, nextC])
                {
                    visited[nextR, nextC] = true;
                    pq.Enqueue([nextR, nextC], grid[nextR][nextC]);
                }
            }
        }

        return ans;
    }

    private bool IsValid(int r, int c, int n)
    {
        return r >= 0 && c >= 0 && r < n && c < n;
    }

    public static void Main()
    {
        var sln = new Solution();
        sln.SwimInWater([[0, 2], [1, 3]]);
        sln.SwimInWater([[0, 1, 2, 3, 4], [24, 23, 22, 21, 5], [12, 13, 14, 15, 16], [11, 17, 18, 19, 20], [10, 9, 8, 7, 6]]);
    }
}