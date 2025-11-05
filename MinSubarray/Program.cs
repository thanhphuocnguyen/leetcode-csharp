public class Solution
{
    public int MinSubarray(int[] nums, int p)
    {
        long total = 0;
        foreach(int num in nums) {
            total += num;
        }
        if (total % p == 0) return 0;
        // Find target for sub-array (if sub-array modulus p == 0 => total - sub-array sum % p == 0)
        long target = total % p;

        Dictionary<long, int> remainders = new();
        int currentSum = 0;
        remainders[0] = -1;
        int cnt = nums.Length;
        for (int i = 0; i < nums.Length; i++)
        {
            currentSum = (currentSum + nums[i]) % p;
            long needed = (currentSum - target + p) % p;
            if (remainders.ContainsKey(needed))
            {
                cnt = Math.Min(cnt, i - remainders[needed]);
            }
            remainders[currentSum] = i;
        }

        return cnt == nums.Length ? -1 : cnt;
    }

    public static void Main()
    {
        Solution solution = new();
        int[] nums = [1000000000, 1000000000, 1000000000];
        int p = 6;
        Console.WriteLine(solution.MinSubarray(nums, p)); // 1
    }
}