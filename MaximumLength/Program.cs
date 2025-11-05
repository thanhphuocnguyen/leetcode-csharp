public class Solution
{
    public int MaximumLength(string s)
    {
        int n = s.Length;
        Dictionary<string, int> substrs = new();
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                if (s[i] != s[j])
                {
                    break;
                }
                string substr = s.Substring(i, j - i + 1);
                substrs[substr] = substrs.GetValueOrDefault(substr, 0) + 1;
            }
        }
        int ans = -1;
        foreach (var pair in substrs)
        {
            if (pair.Value >= 3)
            {
                ans = Math.Max(pair.Key.Length, ans);
            }
        }
        return ans;
    }
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.MaximumLength("abcaba"));

    }
}