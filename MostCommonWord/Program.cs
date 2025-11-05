using System.Text;

public class Solution
{
    public string MostCommonWord(string paragraph, string[] banned)
    {
        char[] excludedChars = ['!', '?', '\'', ',', ';', ' ', '.'];
        var sb = new StringBuilder();
        Dictionary<string, int> freq = new();
        foreach (char c in paragraph)
        {
            if (excludedChars.Contains(c) && sb.Length > 0)
            {
                string word = sb.ToString();
                if (!banned.Contains(word))
                {
                    freq[word] = freq.GetValueOrDefault(word, 0) + 1;
                }
                sb.Clear();
            }
            else
            {
                sb.Append(char.ToLower(c));
            }
        }
        string w = sb.ToString();
        freq[w] = freq.GetValueOrDefault(w, 0) + 1;
        int currMax = 0;
        string candidate = "";
        foreach (var pair in freq)
        {
            if (pair.Value > currMax)
            {
                candidate = pair.Key;
                currMax = pair.Value;
            }
        }
        return candidate;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        string paragraph = "Bob.hIt, baLl";
        string[] banned = ["bob", "hit"];
        string result = solution.MostCommonWord(paragraph, banned);
        Console.WriteLine(result); // Output: "ball"
        result = solution.MostCommonWord("a.", []);
        Console.WriteLine(result); // Output: "ball"
    }
}