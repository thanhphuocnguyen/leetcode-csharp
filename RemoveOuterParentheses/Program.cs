using System.Text;

public class Solution
{
    public string RemoveOuterParentheses(string s)
    {
        int cnt = 0;
        StringBuilder sb = new();
        foreach (char c in s)
        {
            if (c == '(')
            {
                if (cnt > 0)
                {
                    sb.Append(c);
                }
                cnt++;
            }
            else
            {
                if (cnt > 1)
                {
                    sb.Append(c);
                }
                cnt--;
            }
        }

        return sb.ToString();
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.RemoveOuterParentheses("(()())(())(()(()))"));
        Console.WriteLine(sln.RemoveOuterParentheses("((()())(()()))"));
        Console.WriteLine(sln.RemoveOuterParentheses("(()())(())"));
        Console.WriteLine(sln.RemoveOuterParentheses("()()"));
    }
}