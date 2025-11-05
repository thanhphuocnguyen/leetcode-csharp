public class Solution
{
    public int[] GetSneakyNumbers(int[] nums)
    {
        int[] ans = new int[2];
        int i = 0;
        foreach (int num in nums)
        {
            int idx = Math.Abs(num);
            if (nums[idx] >= 0)
            {
                nums[idx] = -nums[idx];
            }
            else
            {
                ans[i++] = idx;
            }
        }

        return ans;
    }
    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.GetSneakyNumbers([1, 0, 1, 0]));
        Console.WriteLine(sln.GetSneakyNumbers([0, 3, 2, 1, 3, 2]));
    }
}