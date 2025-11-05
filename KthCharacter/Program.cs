using System.Text;

public class Solution
{
    public char KthCharacter(int k)
    {
        StringBuilder sb = new();
        sb.Append('a');
        while (sb.Length < k)
        {
            int size = sb.Length;
            for (int i = 0; i < size; i++)
            {
                sb.Append((char)(sb[i] + 1));
            }
        }
        return sb[k - 1];
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int k = 5; // Example input
        char result = solution.KthCharacter(k);
        Console.WriteLine($"The {k}th character is: {result}");
    }
}