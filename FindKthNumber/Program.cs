public class Solution
{
    public int FindKthNumber(int n, int k)
    {
        // first order is always 1;
        int ans = 1;
        k--;
        while (k > 0)
        {
            int steps = CountStep(n, ans);
            if (steps <= k)
            {
                k -= steps;
                ans++;
            }
            else
            {
                ans *= 10;
                k--;
            }
        }
        return ans;
    }

    private int CountStep(int n, int prefix)
    {
        int steps = 0;
        int nextPrefix = prefix + 1;
        while (prefix <= n)
        {
            steps += Math.Min(n + 1, nextPrefix) - prefix;
            prefix *= 10;
            nextPrefix *= 10;
        }
        return steps;
    }

    public static void Main(string[] args)
    {
        Solution s = new Solution();
        Console.WriteLine(s.FindKthNumber(422, 111));
    }
}

