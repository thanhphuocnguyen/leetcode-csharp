public class Solution
{
    public int CountCollisions(string directions)
    {
        int n = directions.Length;
        int i = 0, j = n - 1;
        while (i < n && directions[i] == 'L')
        {
            i++;
        }
        while (j >= i && directions[j] == 'R')
        {
            j--;
        }
        Stack<char> st = new();
        int ans = 0;
        while (i <= j)
        {
            if (directions[i] == 'L' || directions[i] == 'S')
            {
                while (st.Count > 0 && st.Peek() == 'R')
                {
                    ans++;
                    st.Pop();
                }
                if (directions[i] == 'L')
                {
                    ans++;
                }
            }
            else
            {
                st.Push(directions[i]);
            }
            i++;
        }
        return ans;
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.CountCollisions("RLRSLL"));
        Console.WriteLine(sln.CountCollisions("SSRSSRLLRSLLRSRSSRLRRRRLLRRLSSRR"));
    }
}