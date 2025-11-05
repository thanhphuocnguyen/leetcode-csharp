double MaxProbability(int n, int[][] edges, double[] succProb, int start_node, int end_node)
{
    var adj = new List<Tuple<int, double>>[n];
    for (int i = 0; i < edges.Length; i++)
    {

        int u = edges[i][0], v = edges[i][1];
        if (adj[u] == null) adj[u] = new List<Tuple<int, double>>();
        if (adj[v] == null) adj[v] = new List<Tuple<int, double>>();
        double weight = succProb[i];
        adj[u].Add(Tuple.Create(v, weight));
        adj[v].Add(Tuple.Create(u, weight));
    }
    return Dijkstra(n, adj, start_node, end_node);
}

double Dijkstra(int n, List<Tuple<int, double>>[] adj, int start, int end)
{
    var pq = new PriorityQueue<Tuple<int, double>, double>(Comparer<double>.Create((a, b) => b.CompareTo(a)));
    double[] dist = new double[n];
    pq.Enqueue(Tuple.Create(start, 0.0), 0.0);
    while (pq.Count > 0)
    {
        var currNode = pq.Dequeue().Item1;
        if (adj[currNode] != null)
            foreach (var (nextNode, weight) in adj[currNode])
            {
                double newDist = dist[currNode] > 0 ? dist[currNode] * weight : weight;
                if (newDist > dist[nextNode])
                {
                    dist[nextNode] = newDist;
                    pq.Enqueue(Tuple.Create(nextNode, newDist), newDist);
                }
            }
    }

    return dist[end];
}

// Console.WriteLine(MaxProbability(3, [[0, 1], [1, 2], [0, 2]], [0.5, 0.5, 0.2], 0, 2));
// Console.WriteLine(MaxProbability(3, [[0, 1]], [0.5], 0, 2));
Console.WriteLine(MaxProbability(500, [[193, 229], [133, 212], [224, 465]], [0.91, 0.78, 0.64], 4, 364));