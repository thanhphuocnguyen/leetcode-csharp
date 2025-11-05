public class Solution {
    public long MinimumTotalDistance(IList<int> robot, int[][] factory) {
        int n = robot.Count;
        var robots = robot.ToList();
        robots.Sort();
        Array.Sort(factory, (a,b) => a[0] - b[0]);
        List<int> flattenFactories = new();
        foreach(int[] fac in factory) {
            for(int i = 0; i < fac[1]; i++) {
                flattenFactories.Add(fac[0]);
            }
        }
        int m = flattenFactories.Count;
        long[,] memo = new long[n,m];
        for(int i = 0; i < n; i++) {
            for(int j = 0; j < m; j++) {
                memo[i,j] = -1;
            }
        }
        return DP(robots, flattenFactories, 0, 0, memo);
    }

    private long DP(List<int> robot, List<int> flattenFactories, int i, int j, long[,] memo) {
        if(robot.Count == i) {
            return 0;
        }
        if(flattenFactories.Count == j) {
            return (long)1e12;
        }
        if (memo[i,j] != -1) {
            return memo[i,j];
        }

        long assign = Math.Abs(robot[i] - flattenFactories[j])
            + DP(robot, flattenFactories, i+1, j+1, memo);

        long skip = DP(robot, flattenFactories, i, j+1, memo);

        memo[i,j] = Math.Min(assign, skip);
        return memo[i,j];
    }

    public static void Main() {
        Solution sol = new Solution();
        IList<int> robot = [0,4,6];
        int[][] factory = [[2,2],[6,2]];
        Console.WriteLine(sol.MinimumTotalDistance(robot, factory));
    }
}