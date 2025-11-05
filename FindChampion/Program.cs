public class Solution
{
    public int FindChampion(int n, int[][] edges)
    {
        List<int>[] adj = new List<int>[n];
        foreach (int[] edge in edges)
        {
            int from = edge[0], to = edge[1];
            if (adj[from] == null)
            {
                adj[from] = new List<int>();
            }
            adj[from].Add(to);
        }
        int[] inDegree = new int[n];
        foreach (List<int> list in adj)
        {
            if (list == null) { continue; }
            foreach (int el in list)
            {
                inDegree[el]++;

            }
        }
        int cnt = 0;
        int res = 0;
        for (int i = 0; i < n; i++)
        {
            if (inDegree[i] == 0)
            {
                res = i;
                cnt++;
            }
        }
        return cnt > 1 ? -1 : res;
    }
    public static void Main()
    {
        Solution sol = new Solution();
        int n = 3;
        int[][] edges = [[0, 1], [1, 2]];
        Console.WriteLine(sol.FindChampion(n, edges));
    }
}