public class Solution
{
    public IList<string> SplitWordsBySeparator(IList<string> words, char separator)
    {
        IList<string> ans = new List<string>();
        foreach (string word in words)
        {
            for (int left = 0, right = 0; right < word.Length; right++)
            {
                if (word[right] == separator)
                {
                    ans.Add(word.Substring(left, right - left));
                    left = right + 1;
                }
            }
        }
        return ans;
    }

    public static void Main()
    {
        var sln = new Solution();
    }
}