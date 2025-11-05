int GetLucky(string s, int k)
{
    int sum = 0;

    foreach (char c in s)
    {
        int num = c - 'a' + 1;
        sum += num / 10 + num % 10;
    }

    while (k > 1 && sum > 9)
    {
        int numFromS = 0;

        while (sum > 0)
        {
            numFromS += sum % 10;
            sum /= 10;
        }

        sum = numFromS;
        k--;
    }

    return sum;
}

Console.WriteLine(GetLucky("leetcode", 1));