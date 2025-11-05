public class Solution
{
    public int MaxWidthRamp(int[] nums)
    {
        Stack<int> monotonicSt = new();
        int n = nums.Length;
        int maxWidth = 0;
        for (int i = 0; i < n; i++)
        {
            if (monotonicSt.Count == 0 || nums[monotonicSt.Peek()] > nums[i])
            {
                monotonicSt.Push(i);
            }
        }

        for (int i = n - 1; i >= 0; i--)
        {
            while (monotonicSt.Count > 0 && nums[i] >= nums[monotonicSt.Peek()])
            {
                maxWidth = Math.Max(maxWidth, i - monotonicSt.Pop());
            }
            
        }

        return maxWidth;
    }

    public static void Main(string[] args)
    {
        Solution s = new();
        int[] nums = new int[] { 6, 0, 8, 2, 1, 5 };
        Console.WriteLine(s.MaxWidthRamp(nums));
    }
}