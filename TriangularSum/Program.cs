int TriangularSum(int[] nums)
{
    int n = nums.Length;
    return Solve(nums, n);
}

int Solve(int[] nums, int n)
{
    if (n == 1)
    {
        return nums[0];
    }
    int j = 0;
    for (int i = 0; i < n - 1; i++)
    {
        nums[j++] = (nums[i] + nums[i + 1]) % 10;
    }
    return Solve(nums, n - 1);
}

Console.WriteLine(TriangularSum([1, 2, 3, 4, 5]));