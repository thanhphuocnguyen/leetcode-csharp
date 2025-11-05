public class Solution
{
    public void DuplicateZeros(int[] arr)
    {
        int n = arr.Length, shift = 0;
        foreach (int e in arr)
        {
            if (e == 0)
            {
                shift++;
            }
        }
        for (int i = n - 1; i >= 0; i--)
        {
            if (shift + i < n)
            {
                arr[shift + i] = arr[i];
            }
            if (arr[i] == 0)
            {
                shift--;
                if (shift + i < n)
                {
                    arr[i + shift] = 0;
                }
            }
        }
    }

    public static void Main()
    {
        var sln = new Solution();
        int[] arr = [1, 0, 2, 3, 0, 4, 5, 0];
        sln.DuplicateZeros(arr);
    }
}