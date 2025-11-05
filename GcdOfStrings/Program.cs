public class Solution
{
    public string GcdOfStrings(string str1, string str2)
    {
        string ans = "";
        string curr = "";
        for (int i = 0; i < Math.Min(str1.Length, str2.Length); i++)
        {
            if (str1[i] == str2[i])
            {
                curr += str1[i];
            }
            if (curr.Length > 0 && str1.Length % curr.Length == 0 && str2.Length % curr.Length == 0 && IsPrefix(str1, i + 1, curr) && IsPrefix(str2, i + 1, curr))
            {
                ans = curr;
            }
        }

        return ans;
    }

    private bool IsPrefix(string str, int from, string prx)
    {
        int n = str.Length / prx.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < prx.Length; j++)
            {
                if (str[i * prx.Length + j] != prx[j])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.GcdOfStrings("ABCDEF", "ABC"));
        Console.WriteLine(sln.GcdOfStrings("ABCABC", "ABC"));
        Console.WriteLine(sln.GcdOfStrings("TAUXXTAUXXTAUXXTAUXXTAUXX", "TAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXX"));
        Console.WriteLine(sln.GcdOfStrings("ABABAB", "ABAB"));
        Console.WriteLine(sln.GcdOfStrings("ABABABAB", "ABAB"));
        Console.WriteLine(sln.GcdOfStrings("LEET", "CODE"));
    }
}