public class Solution
{
    public int MinimumBoxes(int[] apple, int[] capacity)
    {
        int apples = 0;
        foreach (int cnt in apple)
        {
            apples += cnt;
        }
        Array.Sort(capacity, (a, b) => b - a);
        int ans = 0;
        foreach (int cap in capacity)
        {
            if (apples - cap >= 0)
            {
                apples -= cap;
                ans++;
            }
            else
            {
                break;
            }
        }
        if (apples > 0)
        {
            ans++;
        }
        return ans;
    }

    public static void Main()
    {
        var sln = new Solution();
        sln.MinimumBoxes([1, 3, 2], [4, 3, 1, 5, 2]);
        sln.MinimumBoxes([5, 5, 5], [2, 4, 2, 7]);
    }
}