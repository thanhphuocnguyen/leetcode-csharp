int ChalkReplacer(int[] chalk, int k)
{
    // long sum = 0;
    // foreach (int c in chalk)
    // {
    //     sum += c;
    // }

    // k = (int)(k % sum);
    // for (int i = 0; i < chalk.Length; i++)
    // {
    //     if (chalk[i] > k)
    //     {
    //         return i;
    //     }

    //     k -= chalk[i];
    // }

    // return 0;

    // Binary search

    long[] prefixSum = new long[chalk.Length];
    prefixSum[0] = chalk[0];
    for (int i = 1; i < chalk.Length; i++)
    {
        prefixSum[i] = chalk[i] + prefixSum[i - 1];
    }

    long sum = prefixSum[^1];
    k = (int)(k % sum);
    int low = 0, high = chalk.Length - 1;
    while (low < high)
    {
        int mid = low + (high - low) / 2;
        if (prefixSum[mid] <= k)
        {
            low = mid + 1;
        }
        else
        {
            high = mid;
        }
    }
    return low;
}