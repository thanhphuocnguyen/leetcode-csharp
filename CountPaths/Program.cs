public class Solution
{
    public int CountPaths(int n, int[][] roads)
    {
        int MOD = 1_000_000_007;
        var adj = new List<int[]>[n];
        for (int i = 0; i < n; i++)
        {
            adj[i] = new();
        }
        foreach (int[] road in roads)
        {
            int u = road[0], v = road[1], w = road[2];
            adj[u].Add([v, w]);
            adj[v].Add([u, w]);
        }
        int[] dp = new int[n];
        dp[0] = 1;
        var dist = new long[n];
        Array.Fill(dist, int.MaxValue);
        var pq = new PriorityQueue<long[], long>();
        pq.Enqueue([0, 0], 0);
        while (pq.Count > 0)
        {
            var node = pq.Dequeue();
            var src = node[0];
            var currTime = node[1];
            foreach (var nei in adj[src])
            {
                int dest = nei[0], w = nei[1];
                if (w + currTime < dist[dest])
                {
                    dist[dest] = w + currTime;
                    dp[dest] = dp[src];
                    pq.Enqueue([dest, dist[dest]], dist[dest]);
                }
                else if (w + currTime == dist[dest])
                {
                    dp[dest] = (int)(long)(dp[dest] + dp[src]) % MOD;
                }
            }
        }
        return dp[n - 1];
    }

    public static void Main(string[] args)
    {
        var sln = new Solution();
        Console.WriteLine(sln.CountPaths(7, [[0, 6, 7], [0, 1, 2], [1, 2, 3], [1, 3, 3], [2, 4, 1], [2, 5, 2], [3, 6, 5], [4, 6, 3], [5, 6, 7]]));
    }
}