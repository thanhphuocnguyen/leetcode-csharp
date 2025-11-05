public class Solution
{
    public int MincostTickets(int[] days, int[] costs)
    {
        HashSet<int> travelDay = [.. days];
        int maxDay = days[days.Length - 1];
        int[] dp = new int[maxDay + 1];
        for (int day = 1; day <= maxDay; day++)
        {
            if (!travelDay.Contains(day))
            {
                dp[day] = dp[day - 1];
            }
            else
            {
                dp[day] = costs[0] + dp[day - 1];

                dp[day] = Math.Min(dp[day], dp[Math.Max(0, day - 7)] + costs[1]);

                dp[day] = Math.Min(dp[day], dp[Math.Max(0, day - 30)] + costs[2]);
            }
        }
        return dp[maxDay];
    }

    public static void Main(string[] args)
    {
        int[] days = [1, 4, 6, 7, 8, 20];
        int[] costs = [7, 2, 15];
        Solution sol = new Solution();
        Console.WriteLine(sol.MincostTickets(days, costs));
    }
}