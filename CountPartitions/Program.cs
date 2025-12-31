public class Solution
{
    public int CountPartitions(int[] nums)
    {
        int n = nums.Length;
        int[] prfSum = new int[n];
        prfSum[0] = nums[0];
        for (int i = 1; i < n; i++)
        {
            prfSum[i] = prfSum[i - 1] + nums[i];
        }

        int ans = 0;
        for (int i = 0; i < n - 1; i++)
        {
            int diff = prfSum[i] - (prfSum[n - 1] - prfSum[i]);
            if ((diff & 1) == 0)
            {
                ans++;
            }
        }
        return ans;
    }

    public static void Main()
    {
        var sln = new Solution();

        sln.CountPartitions([10, 10, 3, 7, 6]);
    }
}