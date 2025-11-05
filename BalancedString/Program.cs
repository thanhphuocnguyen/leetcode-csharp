public class Solution
{
    public int BalancedString(string s)
    {
        var n = s.Length;
        var k = n / 4;
        var dict = new Dictionary<char, int>();
        dict['Q'] = 0;
        dict['W'] = 0;
        dict['E'] = 0;
        dict['R'] = 0;
        foreach (var c in s)
        {
            dict[c]++;
        }
        var res = n;
        var left = 0;
        for (var right = 0; right < n; ++right)
        {
            dict[s[right]]--;
            while (left < n && dict['Q'] <= k && dict['W'] <= k && dict['E'] <= k && dict['R'] <= k)
            {
                res = Math.Min(res, right - left + 1);
                dict[s[left]]++;
                left++;
            }
        }
        return res;
    }

    public static void Main()
    {
        var s = new Solution();
        Console.WriteLine(s.BalancedString("QWER")); // 0
        Console.WriteLine(s.BalancedString("QQWE")); // 1
        Console.WriteLine(s.BalancedString("QQQW")); // 2
        Console.WriteLine(s.BalancedString("QQQQ")); // 3
        Console.WriteLine(s.BalancedString("WWEQERQWQWWRWWERQWEQ")); // 4
    }
}