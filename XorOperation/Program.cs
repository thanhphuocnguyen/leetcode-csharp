public class Solution
{
    public int XorOperation(int n, int start)
    {
        int ans = start;
        for (int i = 1; i < n; i++)
        {
            ans ^= start + (2 * i);

        }
        return ans;
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.XorOperation(5, 0));
    }
}