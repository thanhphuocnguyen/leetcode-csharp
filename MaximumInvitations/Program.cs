namespace MaximumInvitations;

class Program
{
    static void Main(string[] args)
    {
        var sln = new Solution();
        Console.WriteLine(sln.MaximumInvitations([2, 2, 1, 2]));
    }
}

public class Solution
{
    public int MaximumInvitations(int[] favorite)
    {
        int n = favorite.Length;
        List<List<int>> reversedGraph = new List<List<int>>(n);
        for (int i = 0; i < n; i++)
        {
            reversedGraph.Add(new List<int>());
        }
        for (int person = 0; person < n; person++)
        {
            reversedGraph[favorite[person]].Add(person);
        }

        int longestCycle = 0;
        int twoCycleInvitations = 0;
        bool[] visited = new bool[n];
        for (int person = 0; person < n; person++)
        {
            if (visited[person]) continue;
            Dictionary<int, int> visitedPersons = new();
            int dist = 0, currentPerson = person;
            while (true)
            {
                if (visited[currentPerson])
                {
                    break;
                }

                visited[currentPerson] = true;
                visitedPersons[currentPerson] = dist++;
                int nextPerson = favorite[currentPerson];
                if (visitedPersons.ContainsKey(nextPerson))
                {
                    int cycleLength = dist - visitedPersons[nextPerson];
                    longestCycle = Math.Max(longestCycle, cycleLength);

                    if (cycleLength == 2)
                    {
                        HashSet<int> visitedNodes = new();
                        visitedNodes.Add(currentPerson);
                        visitedNodes.Add(nextPerson);
                        twoCycleInvitations += 2 + BFS(reversedGraph, nextPerson, visitedNodes) +
                                               BFS(reversedGraph, currentPerson, visitedNodes);
                    }

                    break;
                }

                currentPerson = nextPerson;
            }
        }

        return Math.Max(longestCycle, twoCycleInvitations);
    }

    private static int BFS(List<List<int>> graph, int startNode, HashSet<int> visitedNodes)
    {
        Queue<(int node, int dist)> nodes = new();
        nodes.Enqueue((startNode, 0));
        int maxDist = 0;
        while (nodes.Count > 0)
        {
            var pair = nodes.Dequeue();
            foreach (int nei in graph[pair.node])
            {
                if (visitedNodes.Contains(nei))
                {
                    continue;
                }

                visitedNodes.Add(nei);
                nodes.Enqueue((nei, pair.dist + 1));
                maxDist = Math.Max(maxDist, pair.dist + 1);
            }
        }

        return maxDist;
    }
}