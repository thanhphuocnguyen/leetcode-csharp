public class Solution
{
    public char RepeatedCharacter(string s)
    {
        int mask = 0;
        foreach (char c in s)
        {
            int ord = 1 << (c - 'a');
            if ((ord & mask) != 0)
            {
                return c;
            }
            mask |= ord;
        }
        return 'a';
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.RepeatedCharacter("abccbaacz"));
    }
}