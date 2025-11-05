public class Solution
{
    public long ContinuousSubarrays(int[] nums)
    {
        int left = 0, right = 0, n = nums.Length;
        SortedDictionary<int, int> freq = new();
        int ans = 0;
        while (right < n)
        {
            freq[nums[right]] = freq.GetValueOrDefault(nums[right], 0) + 1;
            while (freq.Keys.First() - freq.Keys.Last() > 2)
            {
                freq[nums[left]]--;
                if (freq[nums[left]] == 0)
                {
                    freq.Remove(nums[left]);
                }
                left++;
            }
            ans += right - left + 1;
            right++;
        }
        return ans;
    }
}