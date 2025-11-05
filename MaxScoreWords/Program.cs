public class Solution
{
    public int MaxScoreWords(string[] words, char[] letters, int[] score)
    {
        Dictionary<char, int> freq = new();
        foreach (char c in letters)
        {
            freq[c] = freq.GetValueOrDefault(c, 0) + 1;
        }
        int ans = 0;

        Backtrack(words, 0, freq, score, 0, ref ans);

        return ans;
    }

    public void Backtrack(string[] words, int i, Dictionary<char, int> freq, int[] scores, int score, ref int max)
    {
        if (i == words.Length)
        {
            max = Math.Max(max, score);
            return;
        }
        Dictionary<char, int> wordFreq = new();
        int currScore = 0;
        foreach (char c in words[i])
        {
            wordFreq[c] = wordFreq.GetValueOrDefault(c, 0) + 1;
        }

        foreach (var pair in wordFreq)
        {
            if (!freq.ContainsKey(pair.Key) || freq[pair.Key] < pair.Value)
            {
                // skip
                Backtrack(words, i + 1, freq, scores, score, ref max);
                return;
            }
            currScore += scores[pair.Key - 'a'] * pair.Value;
        }

        foreach (var pair in wordFreq)
        {
            freq[pair.Key] -= pair.Value;
        }

        // take
        Backtrack(words, i + 1, freq, scores, currScore + score, ref max);

        foreach (var pair in wordFreq)
        {
            freq[pair.Key] += pair.Value;
        }
        // skip
        Backtrack(words, i + 1, freq, scores, score, ref max);
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.MaxScoreWords(["leetcode"], ['l', 'e', 't', 'c', 'o', 'd'], [0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0]));
        Console.WriteLine(sln.MaxScoreWords(["dog", "cat", "dad", "good"], ['a', 'a', 'c', 'd', 'd', 'd', 'g', 'o', 'o'], [1, 0, 9, 5, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]));
    }
}