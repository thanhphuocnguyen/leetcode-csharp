public class Solution
{
    private readonly int[][] moves = [[-1, 0], [0, -1], [1, 0], [0, 1]];
    public int MinTimeToReach(int[][] moveTime)
    {
        int n = moveTime.Length, m = moveTime[0].Length;
        // Run Dijkstra algo to find the shortest path
        return Dijkstra(moveTime, 0, 0, n, m);
    }

    private int Dijkstra(int[][] arr, int row, int col, int n, int m)
    {
        int[,] dst = new int[n, m];
        bool[,] visited = new bool[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                dst[i, j] = int.MaxValue;
            }
        }
        dst[row, col] = arr[row][col];
        PriorityQueue<int[], int> pq = new();
        pq.Enqueue([row, col], 0);
        while (pq.TryDequeue(out int[] currNode, out int currWeight))
        {
            int currRow = currNode[0], currCol = currNode[1];
            if (visited[currRow, currCol])
            {
                continue;
            }
            visited[currRow, currCol] = true;
            for (int i = 0; i < moves.Length; i++)
            {
                int[] move = moves[i];
                int rowMoves = move[0], colMoves = move[1];
                int nextRow = currRow + rowMoves, nextCol = currCol + colMoves;
                if (!Inbound(n, m, nextRow, nextCol))
                {
                    continue;
                }

                int w = arr[nextRow][nextCol];
                if (dst[currRow, currCol] + w + 1 < dst[nextRow, nextCol])
                {
                    dst[nextRow, nextCol] = dst[currRow, currCol] + w;
                    pq.Enqueue([nextRow, nextCol], dst[nextRow, nextCol]);
                }
            }
        }
        return -1;
    }

    private bool Inbound(int n, int m, int i, int j)
    {
        return i >= 0 && j >= 0 && i < n && j < m;
    }

    public static void Main(string[] args)
    {
        Solution sol = new();
        int[][] moveTime = [[17, 56], [97, 80]];
        Console.WriteLine(sol.MinTimeToReach(moveTime)); // Output: 3
    }
}