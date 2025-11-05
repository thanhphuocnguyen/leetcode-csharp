public class Solution
{
    public int[] CorpFlightBookings(int[][] bookings, int n)
    {
        int[] ans = new int[n];
        int[] diffArr = new int[n + 1];
        foreach (int[] booking in bookings)
        {
            int l = booking[0] - 1, r = booking[1] - 1, v = booking[2];
            Update(diffArr, l, r, v);
        }
        ans[0] = diffArr[0];
        for (int i = 1; i < n; i++)
        {
            ans[i] = diffArr[i] + ans[i - 1];
        }
        return ans;
    }

    private void Update(int[] arr, int l, int r, int v)
    {
        arr[l] += v;
        arr[r + 1] -= v;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[][] bookings = [
            [1, 2, 10],
            [2, 3, 20],
            [2, 5, 25]
        ];
        int n = 5;
        int[] result = solution.CorpFlightBookings(bookings, n);
        Console.WriteLine(string.Join(", ", result)); // Output: [10, 55, 45, 25, 25]
    }
}