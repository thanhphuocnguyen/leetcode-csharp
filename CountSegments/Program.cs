public class Solution
{
    public int CountSegments(string s)
    {
        if (s.Length == 0)
        {
            return 0;
        }

        int ans = 0;
        int i = 0;
        while (i < s.Length && s[i] == ' ')
        {
            i++;
        }
        if (i == s.Length)
        {
            return 0;
        }
        while (i < s.Length - 1)
        {
            char curr = s[i], next = s[i + 1];
            if (curr == ' ' && next != ' ')
            {
                ans++;
            }
            i++;
        }
        return ans;
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.CountSegments("                "));
    }
}