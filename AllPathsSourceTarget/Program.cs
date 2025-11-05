public class Solution
{
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        int n = graph.Length;
        IList<IList<int>> ans = new List<IList<int>>();
        bool[] visited = new bool[n];
        visited[0] = true;
        Dfs(graph, visited, new List<int>(), ans, 0, n - 1);
        return ans;
    }

    private void Dfs(int[][] graph, bool[] visited, List<int> path, IList<IList<int>> allPaths, int src, int dest)
    {
        path.Add(src);
        if (src == dest)
        {
            allPaths.Add([.. path]);
            path.RemoveAt(path.Count - 1);
            return;
        }
        foreach (int nei in graph[src])
        {
            if (!visited[nei])
            {
                visited[nei] = true;
                Dfs(graph, visited, path, allPaths, nei, dest);
                visited[nei] = false;
            }
        }
        path.RemoveAt(path.Count - 1);
    }

    public static void Main()
    {
        var sln = new Solution();
        sln.AllPathsSourceTarget([[4, 3, 1], [3, 2, 4], [3], [4], []]);
    }
}