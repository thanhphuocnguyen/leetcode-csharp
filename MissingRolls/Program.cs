int[] MissingRolls(int[] rolls, int mean, int n)
{
    int[] ans = new int[n];
    int rollSum = 0, m = rolls.Length;
    foreach (int roll in rolls)
    {
        rollSum += roll;
    }
    int numNeed = (mean * (m + n)) - rollSum;
    if (numNeed < n || numNeed > n * 6)
    {
        return [];
    }

    int avg = numNeed / n;
    int remainder = numNeed % n;

    for (int i = 0; i < n; i++)
    {
        ans[i] = avg;
        if (remainder > 0)
        {
            ans[i]++;
            remainder--;
        }
    }

    return ans;
}

Console.WriteLine(string.Join(',', MissingRolls([1, 5, 6], 3, 4))); // [6, 6]