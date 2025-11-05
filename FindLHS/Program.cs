public class Solution
{
    public int FindLHS(int[] nums)
    {
        Dictionary<int, int> subSeqCnt = new();
        int ans = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            subSeqCnt[nums[i]] = subSeqCnt.GetValueOrDefault(nums[i], 0) + 1;
            if (subSeqCnt.ContainsKey(nums[i] - 1))
            {
                ans = Math.Max(subSeqCnt[nums[i]] + subSeqCnt[nums[i] - 1], ans);
            }
            if (subSeqCnt.ContainsKey(nums[i] + 1))
            {
                ans = Math.Max(subSeqCnt[nums[i]] + subSeqCnt[nums[i] + 1], ans);
            }
        }
        return ans;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int result = solution.FindLHS([1, 3, 2, 2, 5, 2, 3, 7]);
        Console.WriteLine(result); // Output: 7
        result = solution.FindLHS([1, 2, 3, 4]);
        Console.WriteLine(result); // Output: 2
        result = solution.FindLHS([1, 1, 1, 1]);
        Console.WriteLine(result); // Output: 0
    }
}