public class Solution
{
    public int PunishmentNumber(int n)
    {
        int ans = 0;
        for (int i = 1; i <= n; i++)
        {
            int square = i * i;
            ans += CanPartition(square.ToString(), i) ? square : 0;
        }
        return ans;
    }
    private static bool CanPartition(string num, int target)
    {
        if (num.Length == 0 && target == 0)
        {
            return true;
        }
        if (target < 0)
        {
            return false;
        }
        for (int i = 0; i < num.Length; i++)
        {
            int left = int.Parse(num.Substring(0, i + 1));
            string right = num.Substring(i + 1);
            if (CanPartition(right, target - left))
            {
                return true;
            }
        }
        return false;
    }
}

public class Program
{
    public static void Main()
    {
        Solution s = new Solution();
        Console.WriteLine(s.PunishmentNumber(10));
    }
}