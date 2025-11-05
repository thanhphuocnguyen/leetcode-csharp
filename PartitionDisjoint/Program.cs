public class Solution
{
    public int PartitionDisjoint(int[] nums)
    {
        int n = nums.Length;
        int[] maxLeft = new int[n];
        int[] minRight = new int[n];
        maxLeft[0] = nums[0];
        minRight[n - 1] = nums[n - 1];
        for (int i = 1; i < n; i++)
        {
            maxLeft[i] = Math.Max(maxLeft[i - 1], nums[i]);
        }
        for (int i = n - 2; i >= 0; i--)
        {
            minRight[i] = Math.Min(minRight[i + 1], nums[i]);
        }
        for (int i = 1; i < n; i++)
        {
            if (maxLeft[i - 1] <= minRight[i])
            {
                return i;
            }
        }
        return -1;
    }

    public static void Main(string[] args)
    {
        var sln = new Solution();
        Console.WriteLine(sln.PartitionDisjoint([5, 0, 3, 8, 6]));
    }
}