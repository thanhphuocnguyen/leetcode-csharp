public class Solution
{
    public string SortVowels(string s)
    {
        List<char> vowels = new();
        foreach (char c in s)
        {
            if (IsVowel(c))
            {
                vowels.Add(c);
            }
        }
        vowels.Sort((char1, char2) => char1.CompareTo(char2));
        char[] chars = new char[s.Length];
        int i = 0;
        for (int j = 0; j < s.Length; j++)
        {
            if (IsVowel(s[j]))
            {
                chars[j] = vowels[i++];
            }
            else
            {
                chars[j] = s[j];
            }
        }

        return new string(chars);
    }

    private bool IsVowel(char c)
    {
        c = char.ToLower(c);
        return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.SortVowels("lEetcOde"));
    }
}