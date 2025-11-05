public class Solution
{
    public int FindSmallestInteger(int[] nums, int value)
    {
        Span<int> freq = stackalloc int[value];


        foreach (int num in nums)
        {
            int mod = ((num % value) + num) % value;
            freq[mod]++;
        }

        int ans = 0;
        while (freq[ans % value] > 0)
        {
            freq[ans % value]--;
            ans++;
        }
        return ans;
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.FindSmallestInteger([3, 0, 3, 2, 4, 2, 1, 1, 0, 4], 5));
        Console.WriteLine(sln.FindSmallestInteger([1, -10, 7, 13, 6, 8], 5));
    }
}