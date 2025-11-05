public class Solution
{
    public int[] AvoidFlood(int[] rains)
    {
        // use a dictionary to mark last day has rained.
        // use a List to add current day that can dry prev rained lakes.
        // create a ans array with length of rains.
        // use binary search to find bisect left of free day
        Dictionary<int, int> rainedDays = new();
        List<int> freeDays = new();
        Span<int> ans = stackalloc int[rains.Length];
        for (int day = 0; day < rains.Length; day++)
        {
            int rain = rains[day];
            if (rain == 0)
            {
                freeDays.Add(day);
            }
            else
            {
                if (rainedDays.ContainsKey(rain))
                {
                    int freeIdx = freeDays.BinarySearch(rainedDays[rain]);
                    if (freeIdx < 0)
                    {
                        return [];
                    }
                    ans[freeDays[freeIdx]] = rain;
                    freeDays.RemoveAt(freeIdx);
                }
                rainedDays[rain] = day;
            }
        }


        return ans.ToArray();
    }

    public static void Main()
    {
        var sln = new Solution();
        sln.AvoidFlood([]);
    }
}