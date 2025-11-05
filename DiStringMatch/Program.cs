public class Solution
{
    public int[] DiStringMatch(string s)
    {
        int n = s.Length;
        int[] ans = new int[n + 1];
        int min = 0, max = n;
        int i = 0;
        foreach (char c in s)
        {
            if (c == 'I')
            {
                ans[i] = min;
                min++;
            }
            else
            {
                ans[i] = max;
                max--;
            }
            i++;
        }
        ans[i] = min;
        return ans;
    }

    public static void Main()
    {
        var sln = new Solution();
        sln.DiStringMatch("DDI");
        sln.DiStringMatch("III");
        sln.DiStringMatch("IDID");
    }
}