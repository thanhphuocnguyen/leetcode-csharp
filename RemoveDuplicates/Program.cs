public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        int l = 0, r = 0;
        while (r < nums.Length)
        {
            if(nums[r] == nums[l]) {
                r++;
            }else {
                l++;
                nums[l] = nums[r];
            }
        }
        return l+1;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] nums = new int[] { 1, 1, 2 };
        Console.WriteLine(solution.RemoveDuplicates(nums));
    }
}