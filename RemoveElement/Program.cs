public class Solution
{
    public int RemoveElement(int[] nums, int val)
    {
        int l = 0, r = nums.Length - 1;
        while (l <= r)
        {
            if (nums[l] != val)
            {
                l++;
            }
            else
            {
                if (nums[r] != val)
                {
                    nums[l] = nums[r];
                    l++;
                }
                r--;
            }
        }
        return r + 1;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] nums = new int[] { 3, 2, 2, 3 };
        int val = 3;
        Console.WriteLine(solution.RemoveElement(nums, val));
    }
}