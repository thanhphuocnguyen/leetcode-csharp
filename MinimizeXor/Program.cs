using System.Numerics;

public class Solution
{
    public int MinimizeXor(int num1, int num2)
    {
        var bitOneCnt1 = BitOperations.PopCount((uint)num1);
        var bitOneCnt2 = BitOperations.PopCount((uint)num2);
        if (bitOneCnt1 == bitOneCnt2) return num1;
        return bitOneCnt1 > bitOneCnt2 ? RemoveBitSets(num1, bitOneCnt1 - bitOneCnt2) : AddBitSets(num1, bitOneCnt2 - bitOneCnt1);
    }

    private int RemoveBitSets(int num, int cnt)
    {
        for (int i = 0; i < cnt; i++)
        {
            num &= num - 1;
        }

        return num;
    }

    private int AddBitSets(int num, int cnt)
    {
        int currPos = 0;
        for (int i = 0; i < cnt; i++)
        {
            while (((num >> currPos) & 1) == 1)
            {
                currPos++;
            }

            num = num | (1 << currPos);
        }

        return num;
    }
}