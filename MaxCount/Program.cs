public class Solution
{
    public int MaxCount(int[] banned, int n, int maxSum)
    {
        HashSet<int> numSet = new();
        foreach (int num in banned)
        {
            if (num <= n)
            {
                numSet.Add(num);
            }
        }
        int sum = 0;
        int cnt = 0;
        for (int i = 1; i <= n; i++)
        {
            if (numSet.Contains(i))
            {
                continue;
            }
            else
            {
                sum += i;
                if (sum <= maxSum)
                {
                    cnt++;
                }
                else
                {
                    break;
                }
            }
        }
        return cnt;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] banned = [11];
        Console.WriteLine(solution.MaxCount(banned, 7, 50));

    }
}