public class Solution
{
    public int CountNegatives(int[][] grid)
    {
        int ans = 0;
        foreach (int[] nums in grid)
        {
            ans += nums.Length - BinarySearch(nums, -1);
        }
        return ans;
    }

    private int BinarySearch(int[] nums, int target)
    {
        int lo = 0, hi = nums.Length;
        while (lo < hi)
        {
            int mid = (lo + hi) / 2;
            if (nums[mid] > target)
            {
                lo = mid + 1;
            }
            else
            {
                hi = mid;
            }
        }
        return lo;
    }

    public static void Main(string[] args)
    {
        var sln = new Solution();
        Console.WriteLine(sln.CountNegatives([[3, 2], [1, 0]]));
        Console.WriteLine(sln.CountNegatives([[4, 3, 2, -1], [3, 2, 1, -1], [1, 1, -1, -2], [-1, -1, -2, -3]]));
    }
}