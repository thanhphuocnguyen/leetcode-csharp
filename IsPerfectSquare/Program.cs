public class Solution
{
    public bool IsPerfectSquare(int num)
    {
        int left = 1, right = num;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            long squared = (long)mid * mid;
            if (mid == num)
            {
                return true;
            }
            else if (squared > num)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
        return false;
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.IsPerfectSquare(2147483647));
    }
}