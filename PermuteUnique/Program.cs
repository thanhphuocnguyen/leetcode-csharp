public class Solution
{
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        Array.Sort(nums);
        bool[] visited = new bool[nums.Length];
        IList<IList<int>> ans = new List<IList<int>>();
        Backtrack(nums, visited, new List<int>(), ans, 0);
        return ans;
    }

    private void Backtrack(int[] nums, bool[] visited, List<int> temp, IList<IList<int>> ans, int idx)
    {
        if (idx == nums.Length)
        {
            ans.Add(temp);
            return;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1] && visited[i - 1]) continue;
            if (!visited[i])
            {
                visited[i] = true;
                temp.Add(nums[i]);
                Backtrack(nums, visited, temp, ans, idx + 1);
                temp.RemoveAt(temp.Count - 1);
                visited[i] = false;
            }
        }
    }
}