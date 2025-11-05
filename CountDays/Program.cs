public class Solution
{
    public int CountDays(int days, int[][] meetings)
    {
        Array.Sort(meetings, (a, b) => a[0] - b[0]);
        int count = 0;
        int i = 0;
        int j = 0;

        while (i < meetings.Length)
        {
            if (meetings[i][0] > days)
            {
                break;
            }

            if (meetings[i][1] < days)
            {
                i++;
                continue;
            }

            if (meetings[i][0] > j)
            {
                count += meetings[i][0] - j;
            }

            j = Math.Max(j, meetings[i][1]);
            i++;
        }

        return count;

    }
}