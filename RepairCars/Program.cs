public class Solution
{
    public long RepairCars(int[] ranks, int cars)
    {
        long min = 1, max = (long)ranks.Min() * cars * cars;
        bool CanRepairInTime(long time)
        {
            int cnt = 0;
            foreach (int rank in ranks)
            {
                cnt += (int)Math.Sqrt(time / (double)rank);
                if (cnt >= cars)
                {
                    return true;
                }
            }
            return false;
        }

        while (min <= max)
        {
            long mid = min + (max - min) / 2;
            if (CanRepairInTime(mid))
            {
                max = mid - 1;
            }
            else
            {
                min = mid + 1;
            }
        }
        return min;
    }
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] ranks = [1, 2, 3, 4, 5];
        int cars = 5;
        Console.WriteLine(solution.RepairCars(ranks, cars));
    }
}