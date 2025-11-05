public class Solution
{
    public long NumberOfPowerfulInt(long start, long finish, int limit, string s)
    {
        string lo = start.ToString();
        string hi = finish.ToString();
        int n = hi.Length;
        lo = lo.PadLeft(n, '0');
        int preLen = n - s.Length;
        long[] memo = new long[n];
        Array.Fill(memo, -1);
        return DFS(0, true, true, lo, hi, limit, s, preLen, memo);
    }

    private long DFS(int i, bool limitLow, bool limitHi, string lowStr, string hiStr, int limit, string s, int preLen, long[] memo)
    {
        if (i == lowStr.Length)
        {
            return 1;
        }
        if (!limitLow && !limitHi && memo[i] != -1)
        {
            return memo[i];
        }
        int lo = limitLow ? lowStr[i] - '0' : 0;
        int hi = limitHi ? hiStr[i] - '0' : 9;
        long res = 0;
        if (i < preLen)
        {
            for (int digit = lo; digit <= Math.Min(hi, limit); digit++)
            {
                res += DFS(i + 1, limitLow && lo == digit, limitHi && digit == hi, lowStr, hiStr, limit, s, preLen, memo);
            }
        }
        else
        {
            int x = s[i - preLen] - '0';
            if (lo <= x && x <= Math.Min(hi, limit))
            {
                res = DFS(i + 1, limitLow && x == lo, limitHi && x == hi, lowStr, hiStr, limit, s, preLen, memo);
            }
        }

        if (!limitLow && !limitHi)
        {
            memo[i] = res;
        }
        return res;
    }

    public static void Main(string[] args)
    {
        var sln = new Solution();
        Console.WriteLine(sln.NumberOfPowerfulInt(1, 6000, 4, "124")); // Example usage
    }
}