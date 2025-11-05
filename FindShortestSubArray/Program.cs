public class Solution
{
    public int FindShortestSubArray(int[] nums)
    {
        Dictionary<int, int[]> mp = new();
        int ans = nums.Length, max = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];
            if (!mp.ContainsKey(num))
            {
                mp[num] = [i, i, 1];
            }
            else
            {
                mp[num][1] = i;
                int freq = ++mp[num][2];
                int startIdx = mp[num][0];
                if (freq > max)
                {
                    ans = i - startIdx + 1;
                    max = freq;
                }
                else if (freq == max)
                {
                    ans = Math.Min(ans, i - startIdx + 1);
                }
            }
        }

        return ans;
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.FindShortestSubArray([1, 2, 2, 3, 1]));
    }
}