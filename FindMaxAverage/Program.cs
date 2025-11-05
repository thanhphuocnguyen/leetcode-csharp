public class Solution
{
    public double FindMaxAverage(int[] nums, int k)
    {
        int sum = 0;
        for (int i = 0; i < k; i++)
        {
            sum += nums[i];
        }
        int ans = sum;
        for (int i = k; i < nums.Length; i++)
        {
            sum = sum + nums[i] - nums[i - k];
            ans = Math.Max(ans, sum);
        }
        return (double)ans / k;
    }
    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.FindMaxAverage([4, 2, 1, 3, 3], 2));
    }
}