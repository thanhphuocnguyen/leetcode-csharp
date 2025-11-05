public class Solution
{
    public int MinOperations(int[] nums)
    {
        int i = 0;
        while (i < nums.Length && nums[i] == 1)
        {
            i++;
        }
        if (i == nums.Length)
        {
            return 0;
        }
        int ans = 0;
        while (i <= nums.Length - 3)
        {
            if (nums[i] == 0)
            {
                FlipBit(nums, i);
                ans++;
            }
            i++;
        }
        while (i < nums.Length)
        {
            if (nums[i] == 0)
            {
                return -1;
            }
            i++;
        }
        return ans;
    }

    private void FlipBit(int[] nums, int start)
    {
        for (int i = start; i < start + 3; i++)
        {
            nums[i] = nums[i] == 1 ? 0 : 1;
        }
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.MinOperations([1, 1, 1]));
    }
}