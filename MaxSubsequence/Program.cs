public class Solution
{
    public int[] MaxSubsequence(int[] nums, int k)
    {
        int n = nums.Length;
        int[] sortedIndexes = new int[n];
        for (int i = 0; i < n; i++)
        {
            sortedIndexes[i] = i;
        }

        Array.Sort(sortedIndexes, (int i, int j) => nums[i] - nums[j]);
        int[] ans = new int[k];
        int j = 0;
        for (int i = n - k; i < n; i++)
        {
            ans[j] = nums[sortedIndexes[i]];
            j++;
        }
        return ans;
    }

    public static void Main(string[] args)
    {
        var sln = new Solution();
        var rs = sln.MaxSubsequence([2, 1, 3, 3], 2);
        // for (int i = 0; i < rs.Length; i++)
        // {
        //     Console.Write(rs[i] + " ");
        // }
        // rs = sln.MaxSubsequence([-1, -2, 3, 4], 3);
        // for (int i = 0; i < rs.Length; i++)
        // {
        //     Console.Write(rs[i] + " ");
        // }
        // rs = sln.MaxSubsequence([3, 4, 3, 3], 2);
        // for (int i = 0; i < rs.Length; i++)
        // {
        //     Console.Write(rs[i] + " ");
        // }
        rs = sln.MaxSubsequence([50, -75], 2);
        for (int i = 0; i < rs.Length; i++)
        {
            Console.Write(rs[i] + " ");
        }
    }
}