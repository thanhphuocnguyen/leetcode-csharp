int CountValidSelections(int[] nums)
{
    int prefixSum = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        prefixSum += nums[i];
    }
    int ans = 0;
    int suffixSum = 0;
    for (int i = nums.Length - 1; i >= 0; i--)
    {
        prefixSum -= nums[i];
        suffixSum += nums[i];
        if (nums[i] == 0)
        {
            if (suffixSum == prefixSum)
            {
                ans += 2;
            }
            else if (Math.Abs(suffixSum - prefixSum) == 1)
            {
                ans += 1;
            }
        }
    }
    return ans;
}

Console.WriteLine(CountValidSelections([1, 0, 2, 0, 3]));