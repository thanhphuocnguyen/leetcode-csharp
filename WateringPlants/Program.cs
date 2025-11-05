public class Solution
{
    public int WateringPlants(int[] plants, int capacity)
    {
        int currCap = capacity;
        int stepFromRiver = 0;
        int steps = 0;
        for (int i = 0; i < plants.Length; i++)
        {
            if (currCap >= plants[i])
            {
                steps += 1;
                stepFromRiver++;
                currCap -= plants[i];
            }
            else
            {
                steps += stepFromRiver * 2 + 1;
                stepFromRiver++;
                currCap = capacity - plants[i];
            }
        }
        return steps;
    }

    public static void Main()
    {
        var sln = new Solution();
        sln.WateringPlants([2, 2, 3, 3], 5);
    }
}