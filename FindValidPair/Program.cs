public class Solution
{
    public string FindValidPair(string s)
    {
        int[] freq = new int[10];
        foreach (char c in s)
        {
            freq[c - '0']++;
        }
        for (int i = 0; i < s.Length - 1; i++)
        {
            int first = s[i] - '0';
            int second = s[i + 1] - '0';
            if (first == freq[first] && second == freq[second])
            {
                return s.Substring(i,2);
            }
        }
        return "";
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        string input = "2523533";
        string result = solution.FindValidPair(input);
        Console.WriteLine(result); // Output: "ab" or "bc" or "ca" depending on the input
    }
}