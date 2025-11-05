public class Solution
{
    public int[] FindingUsersActiveMinutes(int[][] logs, int k)
    {
        Dictionary<int, HashSet<int>> userActive = new();

        foreach (int[] log in logs)
        {

            if (!userActive.ContainsKey(log[0]))
            {
                userActive[log[0]] = new();
            }
            userActive[log[0]].Add(log[1]);
        }
        int[] ans = new int[k];
        foreach (var pair in userActive)
        {
            ans[pair.Value.Count - 1]++;
        }
        return ans;
    }

    public static void Main()
    {
        var sln = new Solution();
        sln.FindingUsersActiveMinutes([[0, 5], [1, 2], [0, 2], [0, 5], [1, 3]], 5);
        sln.FindingUsersActiveMinutes([[1, 1], [2, 2], [2, 3]], 4);
    }
}