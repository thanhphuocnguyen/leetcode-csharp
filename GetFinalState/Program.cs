public class Solution
{
    public int[] GetFinalState(int[] nums, int k, int multiplier)
    {
        PriorityQueue<int[], int[]> pq = new(Comparer<int[]>.Create((a, b) => a[0] == b[0] ? a[1].CompareTo(b[1]) : a[0].CompareTo(b[0])));
        for (int i = 0; i < nums.Length; i++)
        {
            int[] candidate = [nums[i], i];
            pq.Enqueue(candidate, candidate);
        }
        while (k-- > 0)
        {
            int[] candidate = pq.Peek();
            int[] newCandidate = [candidate[0] * multiplier, candidate[1]];
            pq.DequeueEnqueue(newCandidate, newCandidate);
        }
        return nums;
    }
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        var result = solution.GetFinalState([2, 1, 3, 5, 6], 5, 2);
        foreach (int nums in result)
        {
            Console.WriteLine(nums);
        }
    }
}