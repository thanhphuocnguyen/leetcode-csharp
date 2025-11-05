public class Solution
{
    public int[] SmallerNumbersThanCurrent(int[] nums)
    {
        int[] numsSorted = new int[nums.Length];

        Dictionary<int, int> numIdx = new();
        for (int i = 0; i < nums.Length; i++)
        {
            numsSorted[i] = nums[i];
        }
        Array.Sort(numsSorted);
        for (int i = 0; i < nums.Length; i++)
        {
            if (!numIdx.ContainsKey(numsSorted[i]))
            {
                numIdx[numsSorted[i]] = i;
            }
        }
        int[] ans = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            ans[i] = numIdx[nums[i]];
        }
        return ans;
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.SmallerNumbersThanCurrent([8, 1, 2, 2, 3]));
    }
}