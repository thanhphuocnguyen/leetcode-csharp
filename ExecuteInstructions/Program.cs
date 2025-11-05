int[] ExecuteInstructions(int n, int[] startPos, string s)
{
    int m = s.Length;
    int startRow = startPos[0], startCol = startPos[1];
    int lMost = startCol + 1, rMost = n - startCol, uMost = startRow + 1, dMost = n - startRow;
    for (int i = n - 1; i >= 0; i--)
    {
        int maxReach = m - 1;
    }
}