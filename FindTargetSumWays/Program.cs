public class Solution
{
    public int FindTargetSumWays(int[] nums, int target)
    {
        return BackTrack(nums, target, 0, 0);
    }

    private int BackTrack(int[] nums, int target, int idx, int curSum)
    {
        if (idx >= nums.Length)
        {
            return curSum == target ? 1 : 0;
        }
        int subtract = BackTrack(nums, target, idx + 1, curSum - nums[idx]);
        int addition = BackTrack(nums, target, idx + 1, curSum + nums[idx]);
        return subtract + addition;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] nums = [1, 1, 1, 1, 1];
        int target = 3;
        int result = solution.FindTargetSumWays(nums, target);
        Console.WriteLine(result);
    }
}