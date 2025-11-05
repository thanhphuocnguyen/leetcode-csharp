int SumOddLengthSubarrays(int[] arr)
{
    int n = arr.Length; ;
    int[] prefixSum = new int[n + 1];
    for (int i = 1; i <= n; i++)
    {
        prefixSum[i] = prefixSum[i - 1] + arr[i - 1];
    }
    int ans = 0;
    for (int i = 0; i < n; i++)
    {
        for (int j = i + 1; j <= n; j++)
        {
            if ((j - i) % 2 != 0)
            {
                ans += prefixSum[j] - prefixSum[i];
            }
        }
    }
    return ans;
}
Console.WriteLine(SumOddLengthSubarrays([1,2]));
Console.WriteLine(SumOddLengthSubarrays([10, 11, 12]));
Console.WriteLine(SumOddLengthSubarrays([1, 4, 2, 5, 3]));