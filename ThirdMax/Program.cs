public class Solution
{
    public int ThirdMax(int[] nums)
    {
        long max1 = long.MinValue, max2 = long.MinValue, max3 = long.MinValue;
        foreach (int num in nums)
        {
            if (num > max1)
            {
                max3 = max2;
                max2 = max1;
                max1 = num;
            }
            else if (max1 > num && num > max2)
            {
                max3 = max2;
                max2 = num;
            }
            else if (max2 > num && num > max3)
            {
                max3 = num;
            }
        }
        return (int)(max3 == long.MinValue ? max1 : max3);
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.ThirdMax([2, 2, 3, 1]));
        Console.WriteLine(sln.ThirdMax([1, 2, -2147483648]));
        Console.WriteLine(sln.ThirdMax([5, 2, 2]));
        Console.WriteLine(sln.ThirdMax([2, 2, 2, 1]));
    }
}