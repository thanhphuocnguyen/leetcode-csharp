int FindMinDifference(IList<string> timePoints)
{
    int[] timePointToNumbers = new int[timePoints.Count];
    for (int i = 0; i < timePoints.Count; i++)
    {
        string[] timeSplit = timePoints[i].Split(':');
        string hour = timeSplit[0], minutes = timeSplit[1];
        int totalMinutes = ((hour[0] - '0') * 10 + (hour[1] - '0')) * 60 + ((minutes[0] - '0') * 10 + (minutes[1] - '0'));
        timePointToNumbers[i] = totalMinutes;
    }

    int ans = int.MaxValue;
    for (int i = 1; i < timePointToNumbers.Length; i++)
    {
        ans = Math.Min(ans, timePointToNumbers[i] - timePointToNumbers[i - 1]);
    }

    return Math.Min(ans, 1440 - timePointToNumbers[^1] + timePointToNumbers[0]);
}

Console.WriteLine(FindMinDifference(["12:12", "12:13"]));