public class Solution
{
    public int MinimumRecolors(string blocks, int k)
    {
        int n = blocks.Length;
        int i = 0, j = 0;
        int whiteCnt = 0;
        while (j < k)
        {
            if (blocks[j] == 'W')
            {
                whiteCnt++;
            }
            j++;
        }
        int ans = whiteCnt;
        i++;
        while (j < n)
        {
            if (blocks[j] == 'B' && blocks[i - 1] == 'W')
            {
                whiteCnt--;
            }
            if (blocks[j] == 'W' && blocks[i - 1] == 'B')
            {
                whiteCnt++;
            }
            ans = Math.Min(whiteCnt, ans);
            i++;
            j++;
        }

        return ans < 0 ? 0 : ans;
    }

    public static void Main()
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.MinimumRecolors("WBBWWBBWBW", 7));
        Console.WriteLine(solution.MinimumRecolors("WBWBBBW", 2));
        Console.WriteLine(solution.MinimumRecolors("WBWW", 2));
        Console.WriteLine(solution.MinimumRecolors("WBBWWWWBBWWBBBBWWBBWWBBBWWBBBWWWBWBWW", 15));
    }
}