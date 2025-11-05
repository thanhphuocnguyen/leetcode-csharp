public class Solution
{
    private static int[] dRow = [-1, 0, 1, 0];
    private static int[] dCol = [0, 1, 0, -1];

    public int[] MaxPoints(int[][] grid, int[] queries)
    {
        int n = grid.Length, m = grid[0].Length, qLen = queries.Length;
        bool[][] visited = new bool[n][];
        int[][] queriesIndex = new int[queries.Length][];
        for (int i = 0; i < qLen; i++)
        {
            queriesIndex[i] = [queries[i], i];
        }
        Array.Sort(queriesIndex, (a, b) => a[0] - b[0]);
        int[] ans = new int[qLen];
        for (int i = 0; i < n; i++)
        {
            visited[i] = new bool[m];
        }
        // DO BFS on grid
        PriorityQueue<int[], int> pq = new();
        int point = 0;
        pq.Enqueue([0, 0], grid[0][0]);
        visited[0][0] = true;
        foreach (int[] qi in queriesIndex)
        {
            int q = qi[0];
            int index = qi[1];
            while (pq.TryPeek(out int[] val, out int peek) && peek < q)
            {
                pq.Dequeue();
                int row = val[0], col = val[1];
                point++;
                for (int i = 0; i < 4; i++)
                {
                    int nextRow = row + dRow[i];
                    int nextCol = col + dCol[i];
                    if (IsValidCell(visited, nextRow, nextCol))
                    {
                        visited[nextRow][nextCol] = true;
                        pq.Enqueue([nextRow, nextCol], grid[nextRow][nextCol]);
                    }
                }
            }
            ans[index] = point;
        }
        return ans;
    }

    private bool IsValidCell(bool[][] visited, int row, int col)
    {
        return row >= 0 && col >= 0 && row < visited.Length && col < visited[0].Length && !visited[row][col];
    }

    public static void Main(string[] args)
    {
        var sln = new Solution();
        var result = sln.MaxPoints([[1, 2, 3], [2, 5, 7], [3, 5, 1]], [5, 6, 2]);
        foreach (var p in result)
        {
            Console.WriteLine("" + p);
        }
    }
}