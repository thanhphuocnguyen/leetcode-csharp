public class Solution
{
    public int[][] DivideArray(int[] nums, int k)
    {
        Array.Sort(nums);
        int arrCnt = nums.Length / 3;
        var ans = new int[arrCnt][];
        for (int i = 0; i < arrCnt; i++)
        {
            ans[i] = new int[3];
        }

        for (int i = 0; i < arrCnt; i++)
        {
            int currMin = nums[i * 3];
            ans[i][0] = currMin;
            for (int j = 0; j < 3; j++)
            {
                int numIdx = (i * 3) + j;
                currMin = Math.Min(currMin, nums[numIdx]);
                if (nums[numIdx] - currMin <= k)
                {
                    ans[i][j] = nums[numIdx];
                }
                else
                {
                    return [];
                }
            }
        }
        return ans;
    }

    public static void Main(string[] args)
    {
        var solution = new Solution();
        var result = solution.DivideArray([1, 3, 4, 8, 7, 9, 3, 5, 1], 2);
        foreach (var subArray in result)
        {
            Console.WriteLine(string.Join(", ", subArray));
        }
        Console.WriteLine("------");
        result = solution.DivideArray([2, 4, 2, 2, 5, 2], 2);
        foreach (var subArray in result)
        {
            Console.WriteLine(string.Join(", ", subArray));
        }
        Console.WriteLine("------");
        result = solution.DivideArray([4, 2, 9, 8, 2, 12, 7, 12, 10, 5, 8, 5, 5, 7, 9, 2, 5, 11], 14);
        foreach (var subArray in result)
        {
            Console.WriteLine(string.Join(", ", subArray));
        }
    }
}