public class Solution
{
    public int MaxUniqueSplit(string s)
    {
        HashSet<string> substrs = new();
        int count = 0;
        Backtrack(ref s, 0, ref count, substrs);
        return count;
    }

    public void Backtrack(ref string s, int start, ref int count, HashSet<string> cache)
    {
        if (start == s.Length)
        {
            count = Math.Max(count, cache.Count);
        }

        for (int i = start; i < s.Length; i++)
        {
            string substr = s.Substring(start, i - start + 1);
            if (!cache.Contains(substr))
            {
                cache.Add(substr);
                Backtrack(ref s, i + 1, ref count, cache);
                cache.Remove(substr);
            }
        }
    }

    public static void Main()
    {
        Solution solution = new();
        Console.WriteLine(solution.MaxUniqueSplit("ababccc"));
    }
}