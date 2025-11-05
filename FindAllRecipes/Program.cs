public class Solution
{
    public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies)
    {
        Dictionary<string, List<string>> graph = new();
        Dictionary<string, int> indegree = new();
        HashSet<string> suppliesSet = new(supplies);
        IList<string> ans = new List<string>();
        for (int i = 0; i < recipes.Length; i++)
        {
            indegree[recipes[i]] = ingredients[i].Count;
            foreach (string ing in ingredients[i])
            {
                if (!graph.ContainsKey(ing))
                {
                    graph[ing] = new();
                }
                graph[ing].Add(recipes[i]);
            }
        }

        Queue<string> q = new(supplies);
        while (q.Count > 0)
        {
            var ingredient = q.Dequeue();
            foreach (var r in graph[ingredient])
            {
                indegree[r] -= 1;
                if (indegree[r] == 0)
                {
                    ans.Add(r);
                    q.Enqueue(r);
                }
            }
        }
        return ans;
    }

    public static void Main(string[] args)
    {
        Solution s = new();
        IList<string> ans = s.FindAllRecipes(["bread"], [["yeast", "flour"]], ["yeast", "flour", "corn"]);
        foreach (var a in ans)
        {
            Console.WriteLine(a);
        }
    }
}