public class Solution {
    public int MinimumDiameterAfterMerge(int[][] edges1, int[][] edges2) {
        List<List<int>> tree1 = BuildAdjacent(edges1.Length, edges1);
        List<List<int>> tree2 = BuildAdjacent(edges2.Length, edges2);
        int diameter1 = FindDiameter(tree1.Count, tree1);
        int diameter2 = FindDiameter(tree2.Count, tree2);
        int combinedDiameter = (int)Math.Ceiling(diameter1/2.0) + (int)Math.Ceiling(diameter2/2.0) + 1;
        return Math.Max(Math.Max(diameter1, diameter2), combinedDiameter);
    }

    private List<List<int>> BuildAdjacent(int size, int[][] edges) {
        List<List<int>> adj = new();
        for(int i = 0; i < size; i++) {
            adj.Add(new());
        }
        foreach(int[] edge in edges) {
            int u = edge[0], v = edge[1];
            adj[u].Add(v);
            adj[v].Add(u);
        }
        return adj;
    }

    private int FindDiameter(int n, List<List<int>> adj) {
        var initBFS = FindFarthestNode(n, adj, 0);
        var farthestNode = initBFS.fNode;
        var bfs = FindFarthestNode(n, adj, farthestNode);
        return bfs.dist;
    }

    private (int fNode, int dist) FindFarthestNode(int n, List<List<int>> adjList, int src) {
        Queue<int> q = new();
        bool[] visited = new bool[n];
        q.Enqueue(src);
        visited[src] = true;
        int dist = 0, farthestNode = src;
        while(q.Any()) {
            int size = q.Count;
            for(int i = 0; i < size; i++) {
                int curr = q.Dequeue();
                farthestNode = curr;
                foreach(int nei in adjList[curr]) {
                    if(!visited[nei]) {
                        q.Enqueue(nei);
                        visited[nei] = true;
                    }
                }
            }
            if(q.Any()) {
                dist++;
            }
        }
        return (farthestNode, dist);
    }
}