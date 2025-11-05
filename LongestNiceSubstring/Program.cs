using System.Text;

public class Solution
{
    public string LongestNiceSubstring(string s)
    {
        int left = 0, right = 0;
        bool hasLower = false;
        bool hasUpper = false;

        string ans = "";
        StringBuilder sb = new();
        while (right < s.Length)
        {
            char cr = s[right];
            char cl = s[left];
            if (ToLower(cr) != ToLower(cl))
            {

                sb.Clear();
                hasUpper = false;
                hasLower = false;
                left = right;
            }

            if (IsUpper(cr))
            {
                hasUpper = true;
            }

            if (IsLower(cr))
            {
                hasLower = true;
            }
            sb.Append(cr);

            if (hasUpper && hasLower)
            {
                if (sb.Length > ans.Length)
                {
                    ans = sb.ToString();
                }
            }

            right++;
        }

        return ans;
    }
    private char ToLower(char c)
    {
        if (c >= 'A' && c <= 'Z')
        {
            return (char)(c + 'a' - 'A');
        }
        return c;
    }

    private bool IsUpper(char c)
    {
        return (c >= 'A' && c <= 'Z');
    }

    private bool IsLower(char c)
    {
        return (c >= 'a' && c <= 'z');
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.LongestNiceSubstring("jcJ"));
    }
}