public class Solution
{
    public bool CheckZeroOnes(string s)
    {
        int oneCurrLen = s[0] == '1' ? 1 : 0;
        int zeroCurrLen = s[0] == '0' ? 1 : 0;
        int oneMaxLen = oneCurrLen;
        int zeroMaxLen = zeroCurrLen;
        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == s[i - 1])
            {
                if (s[i] == '1')
                {
                    oneCurrLen++;
                    oneMaxLen = Math.Max(oneMaxLen, oneCurrLen);
                }
                else
                {
                    zeroCurrLen++;
                    zeroMaxLen = Math.Max(zeroMaxLen, zeroCurrLen);
                }
            }
            else
            {
                oneCurrLen = s[i] == '1' ? 1 : 0;
                zeroCurrLen = s[i] == '0' ? 1 : 0;
                oneMaxLen = oneCurrLen;
                zeroMaxLen = zeroCurrLen;
            }
        }
        return oneMaxLen > zeroMaxLen;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.CheckZeroOnes("10")); // Output: true
        // Console.WriteLine(solution.CheckZeroOnes("111000")); // Output: false
        // Console.WriteLine(solution.CheckZeroOnes("110100010")); // Output: false
    }
}