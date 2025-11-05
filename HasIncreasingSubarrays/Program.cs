public class Solution
{
    public bool HasIncreasingSubarrays(IList<int> nums, int k)
    {
        for (int i = 0; i < nums.Count - k; i++)
        {
            bool isValid1 = true;

            for (int a = i; a < i + k - 1; a++)
            {
                if (nums[a] >= nums[a + 1])
                {
                    isValid1 = false;
                    break;
                }
            }

            if (!isValid1)
            {
                continue;
            }

            bool isValid2 = true;

            if (i + (2 * k) - 1 >= nums.Count)
            {
                return false;
            }

            for (int b = i + k; b < i + (2 * k) - 1; b++)
            {
                if (nums[b] >= nums[b + 1])
                {
                    isValid2 = false;
                    break;
                }
            }
            if (isValid2)
            {
                return true;
            }
        }

        return false;
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.HasIncreasingSubarrays([-3, -19, -8, -16], 2));
        Console.WriteLine(sln.HasIncreasingSubarrays([-15, 19], 1));
        Console.WriteLine(sln.HasIncreasingSubarrays([2, 5, 7, 8, 9, 2, 3, 4, 3, 1], 3));
        Console.WriteLine(sln.HasIncreasingSubarrays([-15, -13, 4, 7], 2));
        Console.WriteLine(sln.HasIncreasingSubarrays([1, 2, 3, 4, 4, 4, 4, 5, 6, 7], 5));
    }
}