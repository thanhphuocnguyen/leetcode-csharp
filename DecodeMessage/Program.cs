using System.Text;

public class Solution
{
    public string DecodeMessage(string key, string message)
    {
        Dictionary<char, char> decodeMp = new();
        decodeMp[' '] = ' ';
        char nextChar = 'a';
        foreach (char c in key)
        {
            if (!decodeMp.ContainsKey(c))
            {
                decodeMp[c] = nextChar;
                nextChar = (char)(nextChar + 1);
            }
        }

        var sb = new StringBuilder();
        foreach (char c in message)
        {
            sb.Append(decodeMp[c]);
        }
        return sb.ToString();
    }

    public static void Main(string[] args)
    {
        var solution = new Solution();
        string decodedMessage = solution.DecodeMessage("the quick brown fox jumps over the lazy dog", "vkbs bs t suepuv");
        Console.WriteLine(decodedMessage); // Output: "this is a secret"
        decodedMessage = solution.DecodeMessage("eljuxhpwnyrdgtqkviszcfmabo", "zwx hnfx lqantp mnoeius ycgk vcnjrdb");
        Console.WriteLine(decodedMessage); // Output: "this is a secret"
    }
}