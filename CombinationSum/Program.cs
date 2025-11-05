public class Solution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        IList<IList<int>> ans = new List<IList<int>>();
        Backtrack(candidates, ans, new List<int>(), 0, target, 0);

        return ans;
    }

    private void Backtrack(int[] c, IList<IList<int>> ans, List<int> comb, int sum, int tg, int idx)
    {
        if (sum == 0)
        {
            ans.Add(comb);
        }
        if (sum < 0 || idx > c.Length - 1)
        {
            return;
        }
        comb.Add(c[idx]);
        // take
        Backtrack(c, ans, comb, sum + c[idx], tg, idx);

        // skip
        comb.RemoveAt(comb.Count - 1);
        Backtrack(c, ans, comb, sum, tg, idx + 1);
    }
}