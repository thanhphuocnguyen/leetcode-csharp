public class Solution
{
    public int[] VowelStrings(string[] words, int[][] queries)
    {
        int[] prefixSum = new int[words.Length + 1];
        HashSet<char> vowels = ['a', 'e', 'i', 'o', 'u'];
        for (int i = 1; i < words.Length + 1; i++)
        {
            string word = words[i - 1];
            prefixSum[i] += prefixSum[i - 1] + (vowels.Contains(word[0]) && vowels.Contains(word[word.Length - 1]) ? 1 : 0);
        }

        int[] ans = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            int l = queries[i][0], r = queries[i][1];
            ans[i] = prefixSum[r + 1] - prefixSum[l];
        }
        return ans;
    }
    public static void Main(string[] args)
    {
        Solution s = new Solution();
        string[] words = ["aba", "bcb", "ece", "aa", "e"];
        int[][] queries = [[0, 2], [1, 4], [1, 1]];
        int[] ans = s.VowelStrings(words, queries);
        foreach (int a in ans)
        {
            Console.WriteLine(a);
        }
    }
}
