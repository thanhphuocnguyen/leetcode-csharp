public class Solution
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        int n = nums.Length;
        Array.Sort(nums);
        List<int[]> ans = new();
        for (int i = 0; i < n - 3; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }
            for (int j = i + 1; j < n - 2; j++)
            {
                if (j > i + 1 && nums[j - 1] == nums[j])
                {
                    continue;
                }
                int left = j + 1, right = n - 1;
                while (left < right)
                {
                    long sum = nums[i];
                    sum += nums[j];
                    sum += nums[left];
                    sum += nums[right];
                    if (sum > target)
                    {
                        right--;
                    }
                    else if (sum < target)
                    {
                        left++;
                    }
                    else
                    {
                        ans.Add([nums[i], nums[j], nums[left], nums[right]]);
                        left++;
                        right--;
                        while (left < right && nums[left] == nums[left - 1])
                        {
                            left++;
                        }
                        while (left < right && nums[right] == nums[right + 1])
                        {
                            right--;
                        }
                    }
                }
            }
        }
        return ans.ToArray();
    }
    public static void Main()
    {
        int[] nums = [1000000000, 1000000000, 1000000000, 1000000000];
        int target = -294967296;
        var solution = new Solution();

        Console.WriteLine(solution.FourSum(nums, target));
    }
}