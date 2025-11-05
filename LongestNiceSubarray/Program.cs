public class Solution
{
    public int LongestNiceSubarray(int[] nums)
    {
        int[] bitset = new int[30];
        int res = 0;
        int n = nums.Length;
        int i = 0, j = 0;
        while (j < n)
        {
            while()
        }
    }

    private void OROperator(int[] bitset, int num)
    {
        int bit = 1;
        for (int i = 0; i < 30; i++)
        {
            bitset[i] = (bit & (1 << i)) > 0 ? 1 : 0
        }
    }
    private void XOROperator(int[] bitset, int num)
    {
        int bit = 1;
        for (int i = 0; i < 30; i++)
        {
            if ((bit & (1 << i)) > 0 && bitset[i] == 1)
            {
                bitset[i] = 0;
            }
        }
    }
}