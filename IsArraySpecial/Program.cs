public class Solution
{
    public bool[] IsArraySpecial(int[] nums, int[][] queries)
    {
        int n = nums.Length;
        bool[] ans = new bool[queries.Length];
        List<int> violatingIndices = new();
        for (int i = 1; i < n; i++)
        {
            if (nums[i] % 2 == nums[i - 1] % 2)
            {
                violatingIndices.Add(i);
            }
        }

        for (int i = 0; i < queries.Length; i++)
        {
            int[] query = queries[i];
            int start = query[0], end = query[1];
            bool foundViolationIdx = BinarySearch(start + 1, end, violatingIndices);
            ans[i] = foundViolationIdx ? false : true;
        }
        return ans;
    }

    private bool BinarySearch(int start, int end, List<int> violatingIndices)
    {
        int left = 0, right = violatingIndices.Count - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int violatingIdx = violatingIndices[mid];
            if (violatingIdx < start)
            {
                left = mid + 1;
            }
            else if (violatingIdx > end)
            {
                right = mid - 1;
            }
            else
            {
                return true;
            }
        }
        return false;
    }
    public static void Main(string[] args)
    {
        var solution = new Solution();
        int[] nums = [2, 8, 3, 8, 10];
        int[][] queries = [[0, 3]];
        Console.WriteLine(solution.IsArraySpecial(nums, queries));
    }
}