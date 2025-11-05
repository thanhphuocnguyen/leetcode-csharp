public class Solution
{
    public int FindContentChildren(int[] g, int[] s)
    {
        Array.Sort(g);
        Array.Sort(s);
        int i = 0, j = 0;
        int ans = 0;
        while (i < g.Length && j < s.Length)
        {
            if (g[i] <= s[j])
            {
                i++;
                j++;
                ans++;
            }
            else
            {
                j++;
            }
        }
        return ans;
    }
    public static void Main(string[] args)
    {
        var sln = new Solution();
        Console.WriteLine(sln.FindContentChildren([1, 2, 3], [1, 1]));
        Console.WriteLine(sln.FindContentChildren([1, 2], [1, 2, 3]));
    }
}