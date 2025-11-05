public class Solution
{
    public static int[] LexicographicallySmallestArray(int[] nums, int limit)
    {
        int[] numsSorted = new int[nums.Length];
        Array.Copy(nums, numsSorted, nums.Length);
        Array.Sort(numsSorted);
        int currGroup = 0;
        Dictionary<int, int> numToGroup = new();
        Dictionary<int, Queue<int>> groupToList = new();
        groupToList[currGroup] = new();
        groupToList[currGroup].Enqueue(numsSorted[0]);
        for (int i = 1; i < numsSorted.Length; i++)
        {
            int diff = Math.Abs(numsSorted[i] - numsSorted[i - 1]);
            if (diff > limit)
            {
                currGroup++;
            }

            numToGroup[numsSorted[i]] = currGroup;
            if (!groupToList.ContainsKey(currGroup))
            {
                groupToList[currGroup] = new();
            }

            groupToList[currGroup].Enqueue(numsSorted[i]);
        }

        for (int i = 0; i < nums.Length; i++)
        {
            int group = numToGroup[nums[i]];
            nums[i] = groupToList[group].Dequeue();
        }

        return nums;
    }

    public static void Main(string[] args)
    {
        int[] result = LexicographicallySmallestArray([1,5,3,9,8], 2);
    }
}