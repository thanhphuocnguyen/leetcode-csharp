public class Solution
{
    public bool IsPathCrossing(string path)
    {
        Dictionary<(int, int), bool> mp = new();
        int x = 0, y = 0;
        mp[(x, y)] = true;
        foreach (int d in path)
        {
            switch (d)
            {
                case 'N':
                    y++;
                    break;
                case 'S':
                    y--;
                    break;
                case 'E':
                    x++;
                    break;
                case 'W':
                    x--;
                    break;
            }
            if (mp.ContainsKey((x, y)))
            {
                return true;
            }
            mp[(x, y)] = true;
        }
        return false;
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.IsPathCrossing("NESWW"));
    }
}