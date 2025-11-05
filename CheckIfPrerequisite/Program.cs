namespace CheckIfPrerequisite;

class Program
{
    static void Main(string[] args)
    {
        var sln = new Solution();
        sln.CheckIfPrerequisite(2, [[1, 0]], [[0, 1], [1, 0]]);
    }
}

public class Solution
{
    public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries)
    {
        List<List<int>> adj = new();
        for (int i = 0; i < numCourses; i++)
        {
            adj.Add()new();
        }

        for (int i = 0; i < prerequisites.Length; i++)
        {
            adj[prerequisites[i][0]].Add(prerequisites[i][1]);
        }

        bool[,] isReachable = new bool[numCourses, numCourses];
        for (int i = 0; i < numCourses; i++)
        {
            Queue<int> q = new();
            q.Enqueue(i);
            while (q.Count > 0)
            {
                int currCourse = q.Dequeue();
                foreach (int nei in adj[currCourse])
                {
                    if (!isReachable[currCourse, nei])
                    {
                        isReachable[currCourse, nei] = true;
                        q.Enqueue(nei);
                    }
                }
            }
        }

        IList<bool> ans = new List<bool>();
        foreach (int[] query in queries)
        {
            ans.Add(isReachable[query[0], query[1]]);
        }

        return ans;
    }
}