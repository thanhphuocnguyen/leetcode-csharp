public class Solution
{
    public int NumberOfAlternatingGroups(int[] colors, int k)
    {
        int n = colors.Length;
        int[] extended = [.. colors, .. colors[0..(k - 1)]];
        int left = 0, right = 1, ans = 0;
        while (right < n + k - 1)
        {
            if (extended[right] == extended[right - 1])
            {
                left = right;
            }
            right++;
            if (right - left == k)
            {
                ans++;
                left++;
            }
        }
        return ans;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] colors = [0, 1, 0, 1, 0];
        int k = 3;
        int result = solution.NumberOfAlternatingGroups(colors, k);
        Console.WriteLine(result);
    }
}