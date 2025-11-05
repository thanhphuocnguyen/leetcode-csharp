public class Solution
{
    private readonly char[] vowels = ['a', 'e', 'i', 'o', 'u'];
    public long CountOfSubstrings(string word, int k)
    {
        Dictionary<char, int> vowelsCnt = new();
        int vowelsInWindow = 0;
        int consonantCnt = 0;
        int right = 0, left = 0;
        long ans = 0;
        while (right < word.Length)
        {
            char ch = word[right];
            if (BinarySearch(ch))
            {
                if (vowelsCnt.ContainsKey(ch))
                {
                    vowelsCnt[ch]++;
                }
                else
                {
                    vowelsInWindow++;
                    vowelsCnt[ch] = 1;
                }
            }
            else
            {
                consonantCnt++;
            }
            if (consonantCnt == k && vowelsInWindow == vowels.Length)
            {
                ans++;
            }
            right++;

            while (consonantCnt > k)
            {
                char leftChar = word[left];
                if (!vowelsCnt.ContainsKey(leftChar))
                {
                    vowelsCnt[leftChar]--;
                    if (vowelsCnt[leftChar] == 0)
                    {
                        vowelsCnt.Remove(leftChar);
                        vowelsInWindow--;
                    }
                }
                else
                {
                    consonantCnt--;
                }
                left++;
            }
        }
        return ans;
    }

    private bool BinarySearch(char w)
    {
        int left = 0, right = vowels.Length - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (w == vowels[mid])
            {
                return true;
            }
            else if (w > vowels[mid])
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return false;
    }

    public static void Main(string[] args)
    {
        Solution s = new();
        Console.WriteLine(s.CountOfSubstrings("iqeaouqi", 2));
        Console.WriteLine(s.CountOfSubstrings("aeioqq", 1));
        Console.WriteLine(s.CountOfSubstrings("aeiou", 0));
        Console.WriteLine(s.CountOfSubstrings("ieaouqqieaouqq", 1));
    }
}