public class Solution
{
    public int[] LeftRightDifference(int[] nums)
    {
        int n = nums.Length;
        int[] leftSum = new int[n];
        int[] rightSum = new int[n];
        for (int i = 1; i < n; i++)
        {
            leftSum[i] = leftSum[i - 1] + nums[i - 1];
            rightSum[n - 1 - i] = rightSum[n - i] + nums[n - i];
        }
        int[] ans = new int[n];
        for (int i = 0; i < n; i++)
        {
            ans[i] = Math.Abs(leftSum[i] - rightSum[i]);
        }
        return ans;
    }

    public static void Main()
    {
        var sln = new Solution();

        Console.WriteLine(sln.LeftRightDifference([10, 4, 8, 3]));
    }
}