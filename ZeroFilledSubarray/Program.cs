public class Solution
{
    public long ZeroFilledSubarray(int[] nums)
    {
        int ans = 0;
        int cnt = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                cnt++;
            }
            else
            {
                ans += cnt * (cnt + 1) / 2;
                cnt = 0;
            }
        }
        ans += cnt * (cnt + 1) / 2;
        return ans;
    }

    public static void Main()
    {
        var sln = new Solution();

        Console.WriteLine(sln.ZeroFilledSubarray([0, 0, 0, 2, 0, 0]));
    }
}