public class Solution
{
    public bool PyramidTransition(string bottom, IList<string> allowed)
    {
        Dictionary<string, List<char>> patternMap = new();
        foreach (string pat in allowed)
        {
            char top = pat[pat.Length - 1];
            string pattern = pat.Substring(0, 2);
            if (!patternMap.ContainsKey(pattern))
            {
                patternMap[pattern] = new();
            }
            patternMap[pattern].Add(top);
        }
        return Backtrack(0, patternMap, bottom, new());
    }

    private bool Backtrack(int blockIdx, Dictionary<string, List<char>> patternMap, string bottom, List<char> buildingBlocks)
    {
        if (bottom.Length == 1)
        {
            return true;
        }
        if (buildingBlocks.Count == bottom.Length - 1)
        {
            return Backtrack(0, patternMap, new string(buildingBlocks.ToArray()), new());
        }
        string str = bottom.Substring(blockIdx, 2);
        foreach (var c in patternMap.GetValueOrDefault(str, []))
        {
            buildingBlocks.Add(c);
            if (Backtrack(blockIdx + 1, patternMap, bottom, buildingBlocks))
            {
                return true;
            }
            buildingBlocks.RemoveAt(buildingBlocks.Count - 1);

        }

        return false;
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.PyramidTransition("AAAA", ["AAB", "AAC", "BCD", "BBE", "DEF"]));
        Console.WriteLine(sln.PyramidTransition("BCD", ["BCC", "CDE", "CEA", "FFF"]));
    }
}