public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        int i = 2, j = 2;
        while (j < nums.Length)
        {
            if (nums[i] == nums[j])
            {
                j++;
            }
            else
            {
                nums[i++] = nums[j++];
            }
        }
        return i;
    }
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int result = solution.RemoveDuplicates([1, 1, 1, 2, 2, 3]);
        Console.WriteLine(result);
    }
}