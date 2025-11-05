using System.Security.Principal;

public class Solution
{
    public int MostProfitablePath(int[][] edges, int bob, int[] amount)
    {
        int n = amount.Length;
        List<int>[] adj = new List<int>[n];
        int[] bobTimestamps = new int[n];
        Array.Fill(bobTimestamps, -1);
        for (int i = 0; i < n; i++)
        {
            adj[i] = new List<int>();
        }
        foreach (int[] edge in edges)
        {
            int u = edge[0], v = edge[1];
            adj[u].Add(v);
            adj[v].Add(u);
        }
        var bobPath = new List<int>(bob);
        GetBobTimeStamps(adj, bobPath, bob, -1);

        for (int i = 0; i < bobPath.Count; i++)
        {
            bobTimestamps[bobPath[i]] = i;
        }

        return Dfs(adj, amount, bobTimestamps, 0, -1, 0, 0);
    }

    private int Dfs(List<int>[] adj, int[] amount, int[] bobTimestamps, int node, int parentNode, int timeStamp, int currProfit)
    {
        int currAmount = amount[node];
        if (timeStamp == bobTimestamps[node])
        {
            currAmount = currAmount / 2;
        }
        else if (bobTimestamps[node] != -1 && timeStamp > bobTimestamps[node])
        {
            currAmount = 0;
        }
        currProfit += currAmount;
        if (adj[node].Count == 1 && node != 0)
        {
            return currProfit;
        }
        int maxProfit = int.MinValue;
        foreach (int nei in adj[node])
        {
            if (nei != parentNode)
            {
                maxProfit = Math.Max(maxProfit, Dfs(adj, amount, bobTimestamps, nei, node, timeStamp + 1, currProfit));
            }
        }
        return maxProfit;
    }

    private bool GetBobTimeStamps(List<int>[] adj, List<int> bobPath, int node, int parentNode)
    {
        if (node == 0)
        {
            return true;
        }
        foreach (int nei in adj[node])
        {
            // Only traverse back to the smaller node
            if (nei != parentNode)
            {
                bobPath.Add(node);
                if (GetBobTimeStamps(adj, bobPath, nei, node))
                {
                    return true;
                }
                bobPath.RemoveAt(bobPath.Count - 1);
            }

        }
        return false;
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        int[][] edges = [[0, 1], [1, 2], [1, 3], [3, 4]];
        int bob = 3;
        int[] amount = [-2, 4, 2, -4, 6];
        var sln = new Solution();
        Console.WriteLine(sln.MostProfitablePath(edges, bob, amount));
    }
}