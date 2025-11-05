public class Solution
{
    public int FindClosestNumber(int[] nums)
    {
        int abs = Abs(nums[0]);
        int ans = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            int currAbs = Abs(nums[i]);
            if (currAbs <= abs)
            {
                if (ans > 0 && nums[i] > 0)
                {
                    ans = Math.Min(ans, nums[i]);
                }
                else if (ans <= 0 && nums[i] <= 0)
                {
                    ans = Math.Max(ans, nums[i]);
                }
                else
                {
                    ans = Math.Max(ans, nums[i]);
                }
                abs = currAbs;
            }
        }

        return ans;
    }

    private int Abs(int num)
    {
        if (num < 0)
        {
            return -num;
        }
        return num;
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.FindClosestNumber([-1, 1, 0, 0]));
        Console.WriteLine(sln.FindClosestNumber([2, 1, 1, -1, 100000]));
    }
}