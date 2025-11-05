public class Solution
{
    public int MinMaxDifference(int num)
    {
        int n = 0;
        int cp = num;
        while (cp > 0)
        {
            n++;
            cp /= 10;
        }

        int j = n - 1;
        int[] digits = new int[n];
        cp = num;
        while (cp > 0)
        {
            digits[j] = cp % 10;
            cp /= 10;
            j--;
        }
        int toSwap = 0;
        int toRemove = 0;
        int maxSum = 0;
        int minSum = 0;
        for (int i = 0; i < n; i++)
        {
            if (digits[i] != 9)
            {
                toSwap = digits[i];
                break;
            }

        }
        for (int i = 0; i < n; i++)
        {
            if (toRemove == 0)
            {
                toRemove = digits[i];
                break;
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (digits[i] == toSwap)
            {
                maxSum = maxSum * 10 + 9;
            }
            else
            {
                maxSum = maxSum * 10 + digits[i];
            }
        }
        for (int i = 0; i < n; i++)
        {
            if (digits[i] == toRemove)
            {
                minSum = minSum * 10;
            }
            else
            {
                minSum = minSum * 10 + digits[i];
            }
        }

        return maxSum - minSum;
    }
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int result = solution.MinMaxDifference(11891);
        Console.WriteLine(result); // Example usage
        result = solution.MinMaxDifference(90);
        Console.WriteLine(result); // Example usage
        result = solution.MinMaxDifference(90693669);
        Console.WriteLine(result); // Example usage
    }
}