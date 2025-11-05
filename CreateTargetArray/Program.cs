public class Solution
{
    public int[] CreateTargetArray(int[] nums, int[] index)
    {
        int n = nums.Length;
        int[] ans = new int[n];
        for (int i = 0; i < n; i++)
        {
            int insertIdx = index[i];

            for (int j = n - 1; j > insertIdx; j--)
            {
                ans[j] = ans[j - 1];
            }
            ans[insertIdx] = nums[i];
        }
        return ans;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] result = solution.CreateTargetArray([0, 1, 2, 3, 4], [0, 1, 2, 2, 1]);
        Console.WriteLine(string.Join(", ", result)); // Output: 0, 4, 1, 3, 2
        result = solution.CreateTargetArray([1, 2, 3, 4, 0], [0, 1, 2, 3, 0]);
        Console.WriteLine(string.Join(", ", result)); // Output: 0, 4, 1, 3, 2
    }
}