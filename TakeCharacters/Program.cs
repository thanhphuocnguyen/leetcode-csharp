public class Solution
{
    public int TakeCharacters(string s, int k)
    {
        int[] charFreq = new int[3];
        foreach (char c in s)
        {
            charFreq[c - 'a']++;
        }
        if (charFreq[0] < k || charFreq[1] < k || charFreq[2] < k)
        {
            return -1;
        }
        int[] window = new int[3];
        int ans = 0, left = 0;
        for (int right = 0; right < s.Length; right++)
        {
            window[s[right] - 'a']++;
            while (left <= right && (
                charFreq[0] - window[0] < k || charFreq[1] - window[1] < k || charFreq[2] - window[2] < k
            ))
            {
                window[s[left] - 'a']--;
                left++;
            }
            ans = Math.Max(ans, right - left + 1);
        }
        return s.Length - ans;
    }
    public static void Main(string[] args)
    {
        Solution sol = new Solution();
        string s = "caccbbba";
        int k = 1;
        Console.WriteLine(sol.TakeCharacters(s, k));
    }
}