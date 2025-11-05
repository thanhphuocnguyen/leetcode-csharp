public class Solution
{
    public string ReverseWords(string s)
    {
        char[] cArr = s.ToCharArray();
        int startIdx = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (cArr[i] != ' ')
            {
                continue;
            }
            int endIdx = i - 1;
            Swap(cArr, startIdx, endIdx);
            startIdx = i + 1;
        }
        if (startIdx < s.Length)
        {
            Swap(cArr, startIdx, s.Length - 1);
        }
        return new string(cArr);
    }

    private void Swap(char[] arr, int i, int j)
    {
        while (i < j)
        {
            char temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            j--;
            i++;
        }
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.ReverseWords("Let's take LeetCode contest"));
        Console.WriteLine(sln.ReverseWords("Mr Ding"));
    }
}