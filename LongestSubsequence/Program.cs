public class Solution
{
    public int LongestSubsequence(string s, int k)
    {
        int val = 0;
        int cnt = 0;
        int bits = (int)Math.Log(k, 2) + 1;
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[s.Length - 1 - i];
            if (c == '1')
            {
                if (i < bits && val + (1 << i) <= k)
                {
                    val += 1 << i;
                    cnt++;
                }
            }
            else
            {
                cnt++;
            }
        }
        return cnt;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        string s = "1001010";
        int k = 5;
        int result = solution.LongestSubsequence(s, k);
        Console.WriteLine(result); // Output: 4
    }
}