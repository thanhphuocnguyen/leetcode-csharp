public class Solution
{
    public int MinimumSum(int[] nums)
    {
        int n = nums.Length;
        int[] leftMin = new int[nums.Length];
        int[] rightMin = new int[nums.Length];
        leftMin[0] = nums[0];
        rightMin[n - 1] = nums[n - 1];
        for (int i = 1; i < n; i++)
        {
            leftMin[i] = Math.Min(leftMin[i - 1], nums[i]);
            rightMin[n - 1 - i] = Math.Min(rightMin[n - i], nums[n - 1 - i]);
        }
        int ans = int.MaxValue;
        for (int i = 1; i < n - 1; i++)
        {
            if (nums[i] > leftMin[i - 1] && nums[i] > rightMin[i + 1])
            {
                ans = Math.Min(ans, nums[i] + leftMin[i - 1] + rightMin[i + 1]);
            }
        }
        return ans == int.MaxValue ? -1 : ans;
    }

    public static void Main(string[] args)
    {
        var sln = new Solution();
        Console.WriteLine(sln.MinimumSum([8, 6, 1, 5, 3]));
    }
}