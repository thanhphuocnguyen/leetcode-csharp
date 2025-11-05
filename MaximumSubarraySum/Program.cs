public class Solution
{
    public long MaximumSubarraySum(int[] nums, int k)
    {
        long ans = 0;
        Dictionary<int, int> numMap = new();
        int sum = 0;
        for (int i = 0; i < k; i++)
        {
            if (numMap.ContainsKey(nums[i]))
            {
                numMap[nums[i]]++;
            }
            else
            {
                numMap[nums[i]] = 1;
            }
            sum += nums[i];
        }
        if (numMap.Count == k)
        {
            ans = sum;
        }
        for (int i = k; i < nums.Length; i++)
        {
            sum -= nums[i - k];
            numMap[nums[i - k]]--;
            if (numMap[nums[i - k]] == 0)
            {
                numMap.Remove(nums[i - k]);
            }
            if (numMap.ContainsKey(nums[i]))
            {
                numMap[nums[i]]++;
            }
            else
            {
                numMap[nums[i]] = 1;
            }
            sum += nums[i];
            if (numMap.Count == k)
            {
                ans = Math.Max(ans, sum);
            }
        }
        return ans;
    }

    public static void Main(string[] args)
    {
        Solution sol = new Solution();
        Console.WriteLine(sol.MaximumSubarraySum(new int[] { 7, 10, 14, 12, 15, 19 }, 1));
    }
}