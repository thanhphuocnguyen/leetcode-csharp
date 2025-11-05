public class Solution
{
    public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
    {
        List<int>[] adj = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            adj[i] = new();
        }
        foreach (var edge in edges)
        {
            int u = edge[0], v = edge[1];
            adj[u].Add(v);
        }
        int[] indegree = new int[n];
        for (int i = 0; i < n; i++)
        {
            foreach (var nei in adj[i])
            {
                indegree[nei]++;
            }
        }
        IList<int> ans = new List<int>();
        for (int i = 0; i < n; i++)
        {
            if (indegree[i] == 0)
            {
                ans.Add(i);
            }
        }
        return ans;
    }
}