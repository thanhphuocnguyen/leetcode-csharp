public class Solution
{
    public int MaxAdjacentDistance(int[] nums)
    {
        int ans = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (i == nums.Length - 1)
            {
                ans = Math.Max(Math.Abs(nums[i] - nums[0]), ans);
            }
            else
            {
                ans = Math.Max(ans, Math.Abs(nums[i] - nums[i - 1]));
            }
        }
        return ans;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int result = solution.MaxAdjacentDistance([-2, 1, -5]);
        Console.WriteLine(result); // Output: 5
    }
}