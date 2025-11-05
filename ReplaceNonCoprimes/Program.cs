public class Solution
{
    public IList<int> ReplaceNonCoprimes(int[] nums)
    {
        IList<int> ans = new List<int>();
        foreach (int num in nums)
        {
            int cp = num;
            while (ans.Count > 0)
            {
                int prev = ans[ans.Count - 1];
                int gcd = GCD(prev, cp);
                if (gcd == 1)
                {
                    break;
                }
                ans.RemoveAt(ans.Count - 1);
                cp = prev / gcd * cp;
            }
            ans.Add(cp);
        }
        return ans;
    }


    private int GCD(int a, int b)
    {
        if (a == 0)
        {
            return b;
        }
        return GCD(b % a, a);
    }

    private int LCM(int a, int b, int gcd)
    {
        return a / gcd * b;
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.ReplaceNonCoprimes([287, 41, 49, 287, 899, 23, 23, 20677, 5, 825]));
        Console.WriteLine(sln.ReplaceNonCoprimes([6, 4, 3, 2, 7, 6, 2]));
    }
}