public class Solution
{
    public int[] Shuffle(int[] nums, int n)
    {
        int[] ans = new int[2 * n];
        int left = 0, right = n;
        for (int i = 0, j = 1; left < n; i += 2, j += 2)
        {
            ans[i] = nums[left++];
            ans[j] = nums[right++];
        }
        return ans;
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.Shuffle([2, 5, 1, 3, 4, 7], 3));
    }
}