public class Solution
{
    public int ClosestMeetingNode(int[] edges, int node1, int node2)
    {
        int n = edges.Length;
        int[] dst1 = new int[n];
        int[] dst2 = new int[n];
        Array.Fill(dst1, -1);
        Array.Fill(dst2, -1);
        DFS(edges, dst1, node1, 0);
        DFS(edges, dst2, node2, 0);
        int ans = -1;
        int currMaxDist = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            if (dst1[i] >= 0 && dst2[i] >= 0)
            {
                int maxDist = Math.Max(dst1[i], dst2[i]);
                if (maxDist < currMaxDist)
                {
                    ans = i;
                    currMaxDist = maxDist;
                }
            }
        }
        return ans;
    }

    private static void DFS(int[] edges, int[] dst, int src, int dist)
    {
        // 
        while (src != -1 && edges[src] != -1)
        {
            dst[src] = dist++;
            src = edges[src];
        }
    }

    public static void Main(string[] args)
    {
        var sln = new Solution();
        Console.WriteLine(sln.ClosestMeetingNode([1, 2, -1], 0, 2));

    }

    // private static int[] Dijkstra(List<int>[] adj, int V, int src) {
    //     int[] dst = new int[V];
    //     Array.Fill(dst, int.MaxValue);
    //     bool[] visited = new bool[V];
    //     dst[src] = 0;
    //     PriorityQueue<int,int> pq = new();
    //     // val: pos - priority: dist
    //     pq.Enqueue(0,0);
    //     while(pq.TryDequeue(out int u, out int dist)) {
    //         if(visited[u]) {
    //             continue;
    //         }
    //         visited[u] = true;
    //         foreach(int v in adj[u]) {
    //             if(!visited[v] && dst[u]+1 < dst[v]) {
    //                 dst[v] = dst[u]+1;
    //                 pq.Enqueue(v, dst[v]);
    //             }
    //         }
    //     }
    //     return dst;
    // }
}