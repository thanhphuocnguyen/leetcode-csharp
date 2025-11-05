public class Solution
{
    public int AreaOfMaxDiagonal(int[][] dimensions)
    {
        int ans = 0;
        foreach (int[] rect in dimensions)
        {
            int len = rect[0], wid = rect[1];
            int precomputed = (len * len) + (wid * wid);
            if (precomputed > ans)
            {
                ans = len * wid;
            }
            else if (precomputed == ans)
            {
                ans = Math.Max(ans, len * wid);
            }
        }

        return ans;
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.AreaOfMaxDiagonal([[9, 3], [8, 6]]));
    }
}