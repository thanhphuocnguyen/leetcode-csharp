public class Solution
{
    public long DividePlayers(int[] skill)
    {
        int n = skill.Length;
        Array.Sort(skill);
        long target = skill[0] + skill[n - 1];
        if (n == 2)
        {
            return target;
        }
        long chemistry = skill[0] * skill[n - 1];
        int i = 1, j = n - 2;
        while (i < j)
        {
            long pairSum = skill[i] + skill[j];
            if (pairSum != target)
            {
                return -1;
            }
            chemistry += skill[i] * skill[j];
            j--;
            i++;
        }
        return chemistry;
    }

    static void Main(string[] args)
    {
        Solution s = new Solution();
        Console.WriteLine(s.DividePlayers([3, 2, 5, 1, 3, 4]));
    }
}