public class Solution
{
    public int CountCompleteComponents(int n, int[][] edges)
    {
        var uf = new UnionFind(n);
        Dictionary<int, int> edgesCnt = new();
        foreach (var edge in edges)
        {
            uf.Union(edge[0], edge[1]);
        }
        foreach (var edge in edges)
        {
            int root = uf.Find(edge[0]);
            edgesCnt[root] = edgesCnt.GetValueOrDefault(root, 0) + 1;
        }

        int ans = 0;
        for (int vtx = 0; vtx < n; vtx++)
        {
            int root = uf.Find(vtx);
            if (vtx == root)
            {
                int rootSz = uf.Size(root);
                int expectedEdges = rootSz * (rootSz - 1);
                if (expectedEdges == edgesCnt.GetValueOrDefault(vtx, 0) * 2)
                {
                    ans++;
                }
            }
        }
        return ans;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.CountCompleteComponents(5, [[1, 2], [3, 4], [1, 4], [2, 3], [1, 3], [2, 4]]));
    }
}

public class UnionFind
{
    private int[] parent { get; set; }
    private int[] size { get; set; }

    public UnionFind(int n)
    {
        parent = new int[n];
        size = new int[n];
        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
            size[i] = 1;
        }
    }

    public int Find(int x)
    {
        int root = parent[x];
        if (parent[root] != root)
        {
            return parent[x] = Find(root);
        }
        return root;
    }

    public void Union(int node1, int node2)
    {
        int root1 = Find(node1);
        int root2 = Find(node2);

        if (root1 == root2)
        {
            return;
        }

        // Merge smaller component into larger one
        if (size[root1] > size[root2])
        {
            parent[root2] = root1;
            size[root1] += size[root2];
        }
        else
        {
            parent[root1] = root2;
            size[root2] += size[root1];
        }
    }

    public int Size(int root)
    {
        return size[root];
    }
}