int[] NumberGame(int[] nums)
{
    Array.Sort(nums);
    int[] ans = new int[nums.Length];
    for (int i = 0, j = 1; j < nums.Length; j += 2, i += 2)
    {
        ans[i] = nums[j];
        ans[j] = nums[i];
    }
    return ans;
}

NumberGame([5, 4, 2, 3]);
NumberGame([2, 5]);