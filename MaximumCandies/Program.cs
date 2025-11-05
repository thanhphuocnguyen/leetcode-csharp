public class Solution
{
    public int MaximumCandies(int[] candies, long k)
    {
        int left = 0, right = candies[0];
        int min = candies[0];
        foreach (int pile in candies)
        {
            min = Math.Min(min, pile);
            right = Math.Max(right, pile);
        }
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (mid > k)
            {
                
            }
            else
            {
                left = mid + 1;
            }
        }
        return left;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.MaximumCandies([5, 8, 6], 3));
        Console.WriteLine(solution.MaximumCandies([2, 5], 11));
    }
}