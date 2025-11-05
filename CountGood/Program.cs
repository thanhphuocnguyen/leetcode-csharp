public class Solution
{
    public long CountGood(int[] nums, int k)
    {
        int n = nums.Length;
        long ans = 0;
        long cnt = 0;
        int i = 0, j = 0;
        Dictionary<int, int> freq = new();
        while (i < n && j < n)
        {
            int freqAtJ = freq.GetValueOrDefault(nums[j], 0);
            cnt += freqAtJ;
            freq[nums[j]] = freqAtJ + 1;
            while (cnt >= k)
            {
                ans += n - j;
                cnt -= freq[nums[i]] - 1;
                freq[nums[i]]--;
                i++;
            }
            j++;
        }

        return ans;
    }

    public static void Main(string[] args)
    {
        var sln = new Solution();
        sln.CountGood([3, 1, 4, 3, 2, 2, 4], 2);
        sln.CountGood([1, 1, 1, 1, 1], 10);
    }
}