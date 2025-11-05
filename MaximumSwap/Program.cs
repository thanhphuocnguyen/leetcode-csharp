public class Solution
{
    public int MaximumSwap(int num)
    {
        // int[] indexes = new int[9];
        // for (int i = 0; i < indexes.Length; i++)
        // {
        //     indexes[i] = -1;
        // }
        // int tempNum = num;
        // int maxDigit = int.MinValue;
        // int n = -1;
        // for (int i = 8; i >= 0; i--)
        // {
        //     if (tempNum < Math.Pow(10, i))
        //     {
        //         continue;
        //     }
        //     int lastDigit = tempNum % 10;
        //     if (n == -1)
        //     {
        //         n = i;
        //     }
        //     indexes[i] = lastDigit;
        //     maxDigit = Math.Max(maxDigit, lastDigit);

        //     tempNum /= 10;
        // }

        // for (int i = 0; i < n; i++)
        // {
        //     for (int j = n - 1; j >= 0; j++)
        //     {
        //         if (indexes[i] < indexes[j])
        //         {
        //             int temp = indexes[i];
        //             indexes[i] = indexes[j];
        //             indexes[j] = temp;
        //         }
        //     }
        // }

        // int ans = 0;
        // for (int i = 0; i < n; i++)
        // {
        //     ans = ans * 10 + indexes[i];
        // }

        // return ans;

        char[] numArr = num.ToString().ToCharArray();
        int[] lastOcc = new int[10];
        Array.Fill(lastOcc, -1);
        for (int i = 0; i < numArr.Length; i++)
        {
            lastOcc[numArr[i] - '0'] = i;
        }

        for (int i = 0; i < numArr.Length; i++)
        {
            // <= 9
            for (int digit = 9; digit > numArr[i] - '0'; digit--)
            {
                if (lastOcc[digit] != -1 && lastOcc[digit] > i)
                {
                    char temp = numArr[i];
                    numArr[i] = numArr[lastOcc[digit]];
                    numArr[lastOcc[digit]] = temp;
                    int ans = 0;
                    foreach (char c in numArr)
                    {
                        ans = ans * 10 + c - '0';
                    }
                    return ans;
                }
            }
        }
        return num;
    }

    public static void Main(string[] args)
    {
        Solution s = new Solution();
        Console.WriteLine(s.MaximumSwap(625909898));
    }
}