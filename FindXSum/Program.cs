public class Solution
{
    public int[] FindXSum(int[] nums, int k, int x)
    {
        int[][] freq = new int[51][];
        for (int i = 0; i < 51; i++)
        {
            freq[i] = [i, 0];
        }
        int arrIdx = 0;

        int[] ans = new int[nums.Length - k + 1];
        for (int i = 0, j = 0; j < nums.Length; j++)
        {
            freq[nums[j]][1]++;
            if (j - i + 1 == k)
            {
                ans[arrIdx++] = FindSum(freq, x);
                freq[nums[i]][1]--;
                i++;
            }
        }

        return ans;
    }

    private int FindSum(int[][] freq, int x)
    {
        int[][] dest = new int[freq.Length][];
        Array.Copy(freq, dest, freq.Length);
        Array.Sort(dest, (a, b) => a[1] == b[1] ? b[0].CompareTo(a[0]) : b[1].CompareTo(a[1]));
        int sum = 0;
        for (int i = 0; i < x; i++)
        {
            sum += dest[i][0] * dest[i][1];
        }
        return sum;
    }

    public static void Main()
    {
        var sln = new Solution();
        sln.FindXSum([1, 1, 2, 2, 3, 4, 2, 3], 6, 2);
    }
}