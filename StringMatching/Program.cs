public class Solution
{
    public IList<string> StringMatching(string[] words)
    {
        HashSet<string> ans = new HashSet<string>();
        Array.Sort(words, (a, b) => a.Length - b.Length);
        for (int i = 0; i < words.Length; i++)
        {
            int[] lps = new int[words[i].Length];
            ConstructLPS(words[i], lps);
            for (int j = i+1; j < words.Length; j++)
            {
                if (SearchStr(words[i], words[j], lps))
                {
                    ans.Add(words[i]);
                }
            }
        }
        return ans.ToList();
    }

    private bool SearchStr(string pat, string txt, int[] lps)
    {
        int n = txt.Length, m = pat.Length;
        int i = 0, j = 0;
        while (i < n)
        {
            if (txt[i] == pat[j])
            {
                i++;
                j++;
                if (j == m)
                {
                    return true;
                }
            }
            else
            {
                if (j > 0)
                {
                    j = lps[j - 1];
                }
                else
                {
                    i++;
                }
            }
        }
        return false;
    }
    private void ConstructLPS(string pattern, int[] lps)
    {
        int len = 0;
        lps[0] = 0;
        int i = 0;
        while (i < pattern.Length)
        {
            if (pattern[i] == pattern[len])
            {
                lps[i++] = ++len;
            }
            else
            {
                if (len > 0)
                {
                    len = lps[len - 1];
                }
                else
                {
                    lps[i++] = 0;
                }
            }
        }
    }
    public static void Main(string[] args)
    {
        var sln = new Solution();
        var words = new string[] { "mass", "as", "hero", "superhero" };
        var result = sln.StringMatching(words);
        Console.WriteLine(result);
    }
}