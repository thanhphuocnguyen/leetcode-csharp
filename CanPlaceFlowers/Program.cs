public class Solution
{
    public bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        if (n == 0)
        {
            return true;
        }
        int i = 0;
        while (i < flowerbed.Length)
        {
            if (flowerbed[i] == 1 || (i + 1 < flowerbed.Length && flowerbed[i + 1] == 1) || (i > 0 && flowerbed[i - 1] == 1))
            {
                i += 1;
            }
            else
            {
                n--;
                if (n == 0)
                {
                    return true;
                }
                flowerbed[i] = 1;
                i += 2;
            }
        }
        return n == 0;
    }
    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.CanPlaceFlowers([0, 1, 0, 1, 0, 1, 0, 0], 1)); //true
        Console.WriteLine(sln.CanPlaceFlowers([0, 1, 0], 1)); //true
        Console.WriteLine(sln.CanPlaceFlowers([0, 1, 0], 1)); //true
        Console.WriteLine(sln.CanPlaceFlowers([1, 0, 0, 0, 0, 1], 2)); //true
        Console.WriteLine(sln.CanPlaceFlowers([1, 0, 0, 0, 1], 1)); // true
        Console.WriteLine(sln.CanPlaceFlowers([1, 0, 0, 0, 1], 2)); // false
        Console.WriteLine(sln.CanPlaceFlowers([0, 0, 1, 0, 0], 1)); //true
        Console.WriteLine(sln.CanPlaceFlowers([0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0], 4)); // true
        Console.WriteLine(sln.CanPlaceFlowers([1, 0, 0, 0, 0, 0, 1], 2)); //true
        Console.WriteLine(sln.CanPlaceFlowers([0], 1)); //true
    }
}