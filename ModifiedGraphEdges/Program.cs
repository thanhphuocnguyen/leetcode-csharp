int INF = (int)2e9;
int[][] ModifiedGraphEdges(int n, int[][] edges, int source, int destination, int target)
{
    // edge = [u, v, w]
    List<int[]>[] adj = new List<int[]>[n];
    for (int i = 0; i < n; i++)
    {
        adj[i] = new List<int[]>();
    }

    foreach (int[] edge in edges)
    {
        int u = edge[0], v = edge[1], w = edge[2];
        if (w == -1) continue;
        adj[u].Add([v, w]);
        adj[v].Add([u, w]);
    }

    int shortestPath = Dijkstra(adj, n, source, destination);
    if (shortestPath < target) return [];

    bool isMatchTarget = shortestPath == target;

    foreach (int[] edge in edges)
    {
        if (edge[2] != -1) continue;

        edge[2] = isMatchTarget ? INF : 1;

        int u = edge[0], v = edge[1];

        if (!isMatchTarget)
        {
            adj[u].Add([v, edge[2]]);
            adj[v].Add([u, edge[2]]);
            int recalculateDist = Dijkstra(adj, n, source, destination);
            if (recalculateDist <= target)
            {
                isMatchTarget = true;
                edge[2] += target - recalculateDist;
            }
        }
    }

    return isMatchTarget ? edges : [];
}

int Dijkstra(List<int[]>[] adj, int n, int source, int destination)
{
    int[] dist = new int[n];
    Array.Fill(dist, INF);
    PriorityQueue<int[], int> pq = new PriorityQueue<int[], int>();
    pq.Enqueue([source, 0], 0);

    while (pq.Count > 0)
    {
        var currentNode = pq.Dequeue();
        int u = currentNode[0], d = currentNode[1];
        if (u == destination) break;
        if (d > dist[u]) continue;

        foreach (int[] nei in adj[u])
        {
            int v = nei[0], w = nei[1];
            if (d + w < dist[v])
            {
                dist[v] = d + w;
                pq.Enqueue([v, dist[v]], dist[v]);
            }
        }
    }

    return dist[destination];
}
var result = ModifiedGraphEdges(5, [[4, 1, -1], [2, 0, -1], [0, 3, -1], [4, 3, -1]], 0, 1, 5);

foreach (var item in result)
{
    Console.WriteLine(string.Join(" ", item));
}