public class Solution
{
    public IList<string> BuildArray(int[] target, int n)
    {
        IList<string> ans = new List<string>();
        int i = 1, j = 0;
        while (i <= n && j < target.Length)
        {
            if (i == target[j])
            {
                ans.Add("Push");
                j++;
            }
            else
            {
                ans.Add("Push");
                ans.Add("Pop");
            }
            i++;
        }
        return ans;
    }

    public static void Main()
    {
        var sln = new Solution();
        sln.BuildArray([1, 2, 3], 3);
        sln.BuildArray([1,2], 4);
        sln.BuildArray([1, 3], 3);
    }
}