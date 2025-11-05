public class Solution
{
    public int[] SmallestSubarrays(int[] nums)
    {
        int[] ans = new int[nums.Length];
        Array.Fill(ans, 1);
        for (int i = 0; i < nums.Length; i++)
        {
            int x = nums[i];
            for (int j = i - 1; j >= 0 && (nums[j] | x) != nums[j]; j--)
            {
                ans[j] = i - j + 1;
                nums[j] |= x;
            }
        }
        return ans;
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.SmallestSubarrays([1, 0, 2, 1, 3]));
    }
}