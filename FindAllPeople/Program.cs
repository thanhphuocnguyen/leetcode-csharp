using System.Runtime.InteropServices;

public class Solution
{
    public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson)
    {
        IList<int> ans = new List<int>();
        //TODO: Using Dijkstra algo to solve this
        // Build graph by meetings and group them by
        // First Node is 0, then connect it with firstPerson with weight 0
        // Add Adjacent by each meeting with weight is time of meeting
        // Traverse by Dijkstra algorithms
        // Loop through distances array to find value that not take infinity time to reach out.
        // Append each node into answer array
        List<int[]>[] graph = new List<int[]>[n];
        foreach (int[] meeting in meetings)
        {
            int u = meeting[0], v = meeting[1], w = meeting[2];
            if (graph[u] == null)
            {
                graph[u] = new List<int[]>();
            }
            if (graph[v] == null)
            {
                graph[v] = new List<int[]>();
            }
            graph[u].Add([v, w]);
            graph[v].Add([u, w]);
        }

        Queue<int[]> q = new();
        int[] earliest = new int[n];
        Array.Fill(earliest, int.MaxValue);
        earliest[0] = 0;
        earliest[firstPerson] = 0;
        q.Enqueue([0, 0]);
        q.Enqueue([firstPerson, 0]);
        while (q.TryDequeue(out int[] pair))
        {
            int u = pair[0], currTime = pair[1];
            if (graph[u] == null)
            {
                continue;
            }
            foreach (var nei in graph[u])
            {
                int v = nei[0];
                int nextTime = nei[1];

                // check next meeting must be after the current meeting
                // and the earliest time meeting of v must be next time it will be valid 
                if (nextTime >= currTime && earliest[v] > nextTime)
                {
                    earliest[v] = nextTime;
                    q.Enqueue([v, nextTime]);
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (earliest[i] != int.MaxValue)
            {
                ans.Add(i);
            }
        }
        return ans;
    }

    public static void Main()
    {
        var sln = new Solution();
        var ans1 = sln.FindAllPeople(4, [[3, 1, 3], [1, 2, 2], [0, 3, 3]], 3);
        var ans2 = sln.FindAllPeople(6, [[1, 2, 5], [2, 3, 8], [1, 5, 10]], 1);
        Console.WriteLine(ans1);
        Console.WriteLine(ans2);
    }
}