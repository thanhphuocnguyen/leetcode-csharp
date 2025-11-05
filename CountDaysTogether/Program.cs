public class Solution
{
    public int CountDaysTogether(string arriveAlice, string leaveAlice, string arriveBob, string leaveBob)
    {
        int[] monthDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

        int arriveDayAlice = 0, arriveDayBob = 0, leaveDayAlice = 0, leaveDayBob = 0;
        int arriveMonthAlice = 0, arriveMonthBob = 0, leaveMonthAlice = 0, leaveMonthBob = 0;
        for (int i = 0; i < arriveAlice.Length; i++)
        {
            if (i > 2)
            {
                arriveDayAlice = arriveDayAlice * 10 + (arriveAlice[i] - '0');
                arriveDayBob = arriveDayBob * 10 + (arriveBob[i] - '0');
                leaveDayAlice = leaveDayAlice * 10 + (leaveAlice[i] - '0');
                leaveDayBob = leaveDayBob * 10 + (leaveBob[i] - '0');
            }
            if (i < 2)
            {
                arriveMonthAlice = arriveMonthAlice * 10 + (arriveAlice[i] - '0');
                arriveMonthBob = arriveMonthBob * 10 + (arriveBob[i] - '0');
                leaveMonthAlice = leaveMonthAlice * 10 + (leaveAlice[i] - '0');
                leaveMonthBob = leaveMonthBob * 10 + (leaveBob[i] - '0');
            }
        }

        int maxDayArrive = arriveDayAlice;
        int maxMonArrive = arriveMonthAlice;
        int minDayLeave = leaveDayAlice;
        int minMonLeave = leaveMonthAlice;

        if (arriveMonthBob > arriveMonthAlice || (arriveMonthBob == arriveMonthAlice && arriveDayBob >= arriveDayAlice))
        {
            maxDayArrive = arriveDayBob;
            maxMonArrive = arriveMonthBob;
        }

        if (leaveMonthBob < leaveMonthAlice || (leaveMonthBob == leaveMonthAlice && leaveDayBob < leaveDayAlice))
        {
            minDayLeave = leaveDayBob;
            minMonLeave = leaveMonthBob;
        }

        if (maxMonArrive > minMonLeave || (maxMonArrive == minMonLeave && maxDayArrive > minDayLeave))
        {
            return 0;
        }
        int daysInRange = 0;
        for (int i = maxMonArrive - 1; i < minMonLeave - 1; i++)
        {
            daysInRange += monthDays[i];
        }
        return daysInRange - maxDayArrive + minDayLeave + 1;
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.CountDaysTogether("10-20", "12-22", "06-21", "07-05"));
        Console.WriteLine(sln.CountDaysTogether("08-15", "08-18", "08-16", "08-19"));
        Console.WriteLine(sln.CountDaysTogether("10-01", "10-31", "11-01", "12-31"));
    }
}