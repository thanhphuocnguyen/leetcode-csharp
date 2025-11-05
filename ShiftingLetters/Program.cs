using System.Text;

public class Solution
{
    public string ShiftingLetters(string s, int[][] shifts)
    {
        int n = s.Length;
        int[] prefixSum = new int[n + 1];
        foreach (int[] shift in shifts)
        {
            int left = shift[0], right = shift[1], direction = shift[2] == 1 ? 1 : -1;
            prefixSum[left] += direction;
            if (right + 1 < n)
            {
                prefixSum[right + 1] -= direction;
            }
        }
        int currentShift = 0;
        for (int i = 0; i < n; i++)
        {
            currentShift += prefixSum[i];
            prefixSum[i] = currentShift;
        }
        StringBuilder sb = new();
        for (int i = 0; i < n; i++)
        {
            int afterShift = (s[i] - 'a' + prefixSum[i] % 26 + 26) % 26;
            char charToAppend = (char)('a' + afterShift);
            sb.Append(charToAppend);
        }
        return sb.ToString();
    }

    public static void Main(string[] args)
    {
        Solution sol = new Solution();
        string s = "abc";
        int[][] shifts = [[0, 1, 0], [1, 2, 1], [0, 2, 1]];
        Console.WriteLine(sol.ShiftingLetters(s, shifts));
    }
}