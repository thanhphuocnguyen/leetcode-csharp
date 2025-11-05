public class Solution
{
    public IList<int> FindKDistantIndices(int[] nums, int key, int k)
    {
        IList<int> ans = new List<int>();
        int right = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == key)
            {
                int left = Math.Max(right, i - k);
                right = Math.Min(nums.Length - 1, i + k) + 1;
                for (int j = left; j < right; j++)
                {
                    ans.Add(j);
                }
            }
        }

        return ans;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] nums = { 3, 4, 9, 1, 3, 9, 5 };
        int key = 9;
        int k = 1;
        IList<int> result = solution.FindKDistantIndices([2, 2, 2, 2, 2], 2, 2);
        Console.WriteLine(string.Join(", ", result)); // Output: 2, 3, 4, 5
    }
}