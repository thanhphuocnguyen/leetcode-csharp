public class Solution
{
    public string ShortestPalindrome(string s)
    {
        string reversed = Reverse(s);
        string combined = s + "#" + reversed;
        int[] prefixTable = buildPrefixTable(combined);
        int longestPrefixCount = prefixTable[combined.Length - 1];
        return reversed.Substring(0, s.Length - longestPrefixCount) + s;
    }

    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    private int[] buildPrefixTable(string s)
    {
        int[] prefixTable = new int[s.Length];
        for (int i = 1; i < s.Length; i++)
        {
            int length = prefixTable[i - 1];
            while (length > 0 && s[i] != s[length])
            {
                length = prefixTable[length - 1];
            }
            if (s[i] == s[length])
            {
                length++;
            }
            prefixTable[i] = length;
        }
        return prefixTable;
    }

    public static void Main()
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.ShortestPalindrome("aacecaaa"));
        Console.WriteLine(solution.ShortestPalindrome("abcd"));
    }
}