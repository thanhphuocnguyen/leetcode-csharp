public class Solution
{
    public IList<string> RemoveAnagrams(string[] words)
    {
        IList<string> ans = new List<string>([words[0]]);
        for (int i = 1; i < words.Length; i++)
        {
            int n = ans.Count;
            string prev = ans[n - 1];
            string curr = words[i];
            if (curr.Length != prev.Length)
            {
                ans.Add(words[i]);
            }
            else
            {
                int[] freq = new int[26];
                for (int j = 0; j < curr.Length; j++)
                {
                    freq[curr[j] - 'a']++;
                    freq[prev[j] - 'a']--;
                }
                bool isValid = true;
                for (int j = 0; j < 26; j++)
                {
                    if (freq[j] != 0)
                    {
                        isValid = false;
                        break;
                    }
                }
                if (!isValid)
                {
                    ans.Add(curr);
                }
            }
        }
        return ans;
    }

    public static void Main()
    {
        var sln = new Solution();
        sln.RemoveAnagrams(["a", "b", "a"]);
    }
}