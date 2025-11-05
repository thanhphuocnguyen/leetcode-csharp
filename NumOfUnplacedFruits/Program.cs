public class Solution
{
    public int NumOfUnplacedFruits(int[] fruits, int[] baskets)
    {
        HashSet<int> idxSet = new();
        foreach (int fruit in fruits)
        {
            for (int i = 0; i < baskets.Length; i++)
            {
                int basket = baskets[i];
                if (fruit <= basket && !idxSet.Contains(i))
                {
                    idxSet.Add(i);
                    break;
                }
            }
        }
        return baskets.Length - idxSet.Count;
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.NumOfUnplacedFruits([1, 2, 1], [3, 2, 2]));
        Console.WriteLine(sln.NumOfUnplacedFruits([4, 2, 5], [3, 5, 4]));
    }
}