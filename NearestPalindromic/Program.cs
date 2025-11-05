string NearestPalindromic(string n)
{
    int firstHalf = Int32.Parse(n.Substring(0, (n.Length + 1) / 2));
    bool isEven = n.Length % 2 == 0;
    long[] possibilities = [
        HalfToPalindrome(firstHalf, isEven),
        HalfToPalindrome(firstHalf + 1, isEven),
        HalfToPalindrome(firstHalf -1, isEven),
        (long)Math.Pow(10.0, n.Length) - 1,
        (long)Math.Pow(10.0, n.Length) + 1
    ];
    long diff = Int64.MaxValue, res = 0, num = Int64.Parse(n);
    foreach (long possibility in possibilities)
    {
        if (possibility == num) continue;
        long tempDiff = Math.Abs(possibility - num);
        if (tempDiff < diff || tempDiff == diff && possibility < res)
        {
            diff = tempDiff;
            res = possibility;
        }
    }
    return res.ToString();
}

int HalfToPalindrome(int left, bool even)
{
    // 123
    int res = left;
    // 12
    if (!even) left /= 10;
    while (left > 0)
    {
        // 120 + 3 -> 1230 + 2 --> 12320 + 1;
        res = res * 10 + left % 10;
        left /= 10;
    }
    return res;
}

NearestPalindromic("10"); // "121"