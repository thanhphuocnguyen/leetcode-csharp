public class Solution
{
    public int LargestCombination(int[] candidates)
    {
        int maxCan = 0;
        foreach (int can in candidates)
        {
            maxCan = Math.Max(can, maxCan);
        }
        int ans = 0;
        for (int bit = 1; bit <= maxCan; bit = bit << 1)
        {
            int cnt = 0;
            foreach (int can in candidates)
            {
                int res = can & bit;
                if (res > 0)
                {
                    cnt++;
                }
            }
            ans = Math.Max(cnt, ans);
        }
        return ans;
    }
}