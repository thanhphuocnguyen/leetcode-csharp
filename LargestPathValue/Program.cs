public class Solution
{
    public int LargestPathValue(string colors, int[][] edges)
    {
        int n = colors.Length;
        var adjacent = new List<int>[n];
        int[] inDegree = new int[n];
        foreach (int[] edge in edges)
        {
            int u = edge[0], v = edge[1];
            if (adjacent[u] == null)
            {
                adjacent[u] = new();
            }
            inDegree[v]++;
            adjacent[u].Add(v);
        }

        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[26];
            for (int j = 0; j < 26; j++)
            {
                if (colors[i] - 'a' == j)
                {
                    dp[i][j] = 1;
                }
            }
        }
        Queue<int> q = new();
        for (int i = 0; i < inDegree.Length; i++)
        {
            if (inDegree[i] == 0)
            {
                q.Enqueue(i);
            }
        }
        int ans = 0;
        int visitedCnt = 0;
        while (q.Count > 0)
        {
            int node = q.Dequeue();
            visitedCnt++;
            foreach (int nei in adjacent[node])
            {
                for (int i = 0; i < 26; i++)
                {
                    if (colors[nei] - 'a' == colors[node] - 'a')
                    {
                        dp[nei][i]++;
                        ans = Math.Max(ans, dp[nei][i]);
                    }
                }
                inDegree[nei]--;
                if (inDegree[nei] == 0)
                {
                    q.Enqueue(nei);
                }
            }
        }
        if (visitedCnt != n)
        {
            return -1;
        }
        return ans;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        string colors = "abaca";
        int[][] edges = [[0, 1], [0, 2], [2, 3], [3, 4]];
        int result = solution.LargestPathValue(colors, edges);
        Console.WriteLine(result); // Output: 3
    }
}