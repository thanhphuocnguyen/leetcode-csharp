public class Solution
{
    public int[] EvenOddBit(int n)
    {
        int evenCnt = 0;
        int oddCnt = 0;
        while (n > 0)
        {
            if ((n & 1) == 0)
            {
                evenCnt++;
            }
            else
            {
                oddCnt++;
            }
            n >>= 1;
        }
        return [evenCnt, oddCnt];
    }
    public static void Main(string[] args)
    {
        Solution s = new Solution();
        var ans = s.EvenOddBit(50);
        Console.WriteLine(ans);
    }
}