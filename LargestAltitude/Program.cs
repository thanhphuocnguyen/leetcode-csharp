int LargestAltitude(int[] gain)
{
    int prefixSum = 0;
    int ans = -100;
    foreach (int net in gain)
    {
        prefixSum += net;
        ans = Math.Max(ans, prefixSum);
    }
    return ans;
}

Console.WriteLine(LargestAltitude([-4, -3, -2, -1, 4, 3, 2]));