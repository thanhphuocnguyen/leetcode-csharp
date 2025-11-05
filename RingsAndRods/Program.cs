public class Solution
{
    public int CountPoints(string rings)
    {
        int n = rings.Length;
        Dictionary<char, HashSet<char>> dict = new();
        for (int i = 0; i + 1 < n; i += 2)
        {
            if (!dict.ContainsKey(rings[i + 1]))
            {
                dict[rings[i + 1]] = new();
            }
            dict[rings[i + 1]].Add(rings[i]);
        }

        int ans = 0;
        foreach (var pair in dict)
        {
            if (pair.Value.Count == 3)
            {
                ans++;
            }
        }
        return ans;
    }
}