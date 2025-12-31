using System.Text;

public class Solution
{
    // Bucket Sort
    public string FrequencySort(string s)
    {
        Dictionary<char, int> freq = new();
        foreach (char c in s)
        {
            freq[c] = freq.GetValueOrDefault(c, 0) + 1;
        }
        List<char>[] buckets = new List<char>[s.Length + 1];
        foreach (var pair in freq)
        {
            if (buckets[pair.Value] == null)
            {
                buckets[pair.Value] = new List<char>();
            }
            buckets[pair.Value].Add(pair.Key);
        }
        char[] chars = new char[s.Length];
        int idx = 0;
        for (int i = s.Length; i >= 0; i--)
        {
            if (buckets[i] != null)
            {
                foreach (char c in buckets[i])
                {
                    for (int j = 0; j < i; j++)
                    {
                        chars[idx++] = c;
                    }
                }
            }
        }
        return new string(chars);
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.FrequencySort("tree"));
    }
}