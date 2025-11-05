public class Solution
{
    private const int MOD = 1_000_000_007;
    public int LengthAfterTransformations(string s, int t)
    {
        int[] freq = new int[26];
        foreach (var c in s)
        {
            freq[c - 'a']++;
        }
        while (t >= 0)
        {
            int[] next = new int[26];
            next[0] = freq[25];
            next[1] = freq[25] + freq[0];
            for (int i = 2; i < 26; i++)
            {
                next[i] = freq[i - 1];
            }
            freq = next;
            t--;
        }

        int ans = 0;
        foreach (int f in freq)
        {
            ans = (ans + f) % MOD;
        }
        return ans;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        string s = "abcyy";
        int t = 2;
        int result = solution.LengthAfterTransformations(s, t);
        Console.WriteLine(result); // Output: 10
    }
}