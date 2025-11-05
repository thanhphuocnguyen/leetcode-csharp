public class Solution
{
    public int ReverseDegree(string s)
    {
        int ans = 0;
        for (int i = 0; i < s.Length; i++)
        {
            int c = s[i];
            ans += ('z' - c + 1) * (i + 1);
        }
        return ans;
    }
    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.ReverseDegree("zaza"));
        Console.WriteLine(sln.ReverseDegree("abc"));
    }
}