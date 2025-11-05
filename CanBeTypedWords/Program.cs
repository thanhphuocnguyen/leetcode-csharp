public class Solution
{
    public int CanBeTypedWords(string text, string brokenLetters)
    {
        int[] freq = new int[26];
        foreach (char c in brokenLetters)
        {
            freq[c - 'a']++;
        }
        int ans = 0;
        bool hasBrokenLetter = false;
        foreach (char c in text)
        {
            if (c == ' ')
            {
                if (!hasBrokenLetter)
                {
                    ans++;
                }
                hasBrokenLetter = false;
                continue;
            }
            else if (freq[c - 'a'] > 0)
            {
                hasBrokenLetter = true;
                continue;
            }

        }
        if (!hasBrokenLetter)
        {
            return ans + 1;
        }
        return ans;
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.CanBeTypedWords("leet code", "e"));
        Console.WriteLine(sln.CanBeTypedWords("hello world", "ad"));
    }
}