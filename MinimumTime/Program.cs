public class Solution
{
    private int[][] directions = [[0, 1], [0, -1], [1, 0], [-1, 0]];
    public int MinimumTime(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        int[][] times = new int[n][];
        for (int i = 0; i < n; i++)
        {
            times[i] = new int[m];
            Array.Fill(times[i], int.MaxValue);
        }
        times[0][0] = 0;
        PriorityQueue<int[], int> pq = new(Comparer<int>.Create((a, b) => a - b));
        pq.Enqueue([0, 0, 0], 0);
        while (pq.Count > 0)
        {
            int[] can = pq.Dequeue();
            int currConsume = can[0], r = can[1], c = can[2];
            if (r == n - 1 && c == m - 1)
            {
                return currConsume;
            }

            foreach (int[] dir in directions)
            {
                int nextR = r + dir[0], nextC = c + dir[1];
                if (IsValid(n, m, nextR, nextC))
                {
                    int nextConsume = grid[nextR][nextC];
                    if (currConsume >= grid[nextR][nextC])
                    {
                        nextConsume = currConsume + 1;
                    }
                    else
                    {
                        int neededMoves = grid[nextR][nextC] - currConsume;
                        if (neededMoves % 2 == 0)
                        {
                            nextConsume += 1;
                        }
                    }
                    if (nextConsume < times[nextR][nextC])
                    {
                        times[nextR][nextC] = nextConsume;
                        pq.Enqueue([nextConsume, nextR, nextC], nextConsume);
                    }
                }
            }
        }
        return -1;
    }

    private bool IsValid(int n, int m, int i, int j)
    {
        if (i >= 0 && i < n && j >= 0 && j < m)
        {
            return true;
        }
        return false;
    }

    public static void Main(string[] args)
    {
        int[][] grid = [[0, 1, 3, 2], [5, 1, 2, 5], [4, 3, 8, 6]];
        Solution sol = new Solution();
        Console.WriteLine(sol.MinimumTime(grid));

    }
}