public class Solution
{
    public bool RotateString(string s, string goal)
    {
        if (s.Length != goal.Length) return false;
        string dbS = s + s;
        for (int i = 0; i < dbS.Length; i++)
        {
            int matchCnt = 0;
            int j = 0;
            if (dbS[i] != goal[j])
            {
                continue;
            }
            while (j < goal.Length && i + j < dbS.Length)
            {
                if (dbS[j + i] != goal[j])
                {
                    break;
                }
                matchCnt++;
                j++;
            }
            if(matchCnt == goal.Length) {
                return true;
            }
        }

        return false;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        string s = "abcde";
        string goal = "cdeab";
        bool result = solution.RotateString(s, goal);
        Console.WriteLine(result);
    }
}