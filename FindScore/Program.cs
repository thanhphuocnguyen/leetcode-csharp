public class Solution
{
    public long FindScore(int[] nums)
    {
        PriorityQueue<int[], int[]> pq = new(Comparer<int[]>.Create((a, b) => a[0] == b[0] ? a[1].CompareTo(b[1]) : a[0].CompareTo(b[0])));
        for (int i = 0; i < nums.Length; i++)
        {
            if (pq.Count > 0 && nums[i] == pq.Peek()[0])
            {
                continue;
            }
            pq.Enqueue([nums[i], i], [nums[i], i]);
        }

        long ans = 0;
        while (pq.Count > 0)
        {
            int[] pair = pq.Dequeue();
            int num = pair[0], idx = pair[1];
            if (nums[idx] == -1)
            {
                continue;
            }

            ans += num;
            nums[idx] = -1;
            if (idx - 1 >= 0)
            {
                nums[idx - 1] = -1;
            }
            if (idx + 1 < nums.Length)
            {
                nums[idx + 1] = -1;
            }
        }
        return ans;
    }

    public static void Main(string[] args)
    {
        Solution sol = new();
        Console.WriteLine(sol.FindScore([4, 4, 6, 6, 2, 2, 9]));
    }
}