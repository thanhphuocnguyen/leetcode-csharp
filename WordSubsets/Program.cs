namespace WordSubsets;
public class Solution {
    public IList<string> WordSubsets(string[] words1, string[] words2) {
        int[] maxFreqW2 = new int[26];
        foreach(string word in words2) {
            int[] freq = new int[26];
            foreach(char c in word)
            {
                int i = c - 'a';
                freq[i]++;
                maxFreqW2[i] = Math.Max(maxFreqW2[i], freq[i]);
            }
        }

        IList<string> ans = new List<string>();

        foreach(string word in words1) {
            bool isUniversal = true;
            int[] freq = new int[26];
            foreach(char c in word) {
                freq[c-'a']++;
            }
            for(int i = 0; i < 26; i++) {
                if(freq[i] < maxFreqW2[i]) {
                    isUniversal = false;
                    break;
                }
            }
            if(isUniversal) {
                ans.Add(word);
            }
        }

        return ans;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        string[] words1 = ["amazon", "apple", "facebook", "google", "leetcode"];
        string[] words2 = ["e", "o"];
       Console.WriteLine(string.Join(",",solution.WordSubsets(words1, words2)));
    }
}