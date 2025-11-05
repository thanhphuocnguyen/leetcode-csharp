using System.Text;

namespace RemoveOccurrences;

class Program
{
    static void Main(string[] args)
    {
        var sln = new Solution();

        Console.WriteLine(sln.RemoveOccurrences("daabcbaabcbc", "abc"));
    }
}

public class Solution
{
    public string RemoveOccurrences(string s, string part)
    {
        StringBuilder sb = new();
        Stack<char> st = new();
        foreach (char c in s)
        {
            st.Push(c);
            if (st.Count >= part.Length && CheckMatch(st, part))
            {
                for (int i = 0; i < part.Length; i++)
                {
                    st.Pop();
                }
            }
        }

        foreach (var c in st.Reverse())
        {
            sb.Append(c);
        }

        return sb.ToString();
    }

    private static bool CheckMatch(Stack<char> st, string part)
    {
        char[] stClone = st.ToArray();
        for (int i = 0; i < part.Length; i++)
        {
            if (stClone[i] != part[part.Length - 1 - i])
            {
                return false;
            }
        }

        return true;
    }
}