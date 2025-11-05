namespace FirstCompleteIndex;

class Program
{
    public static int FirstCompleteIndex(int[] arr, int[][] mat)
    {
        int n = arr.Length, numRows = mat.Length, numCols = mat[0].Length;
        int[] rowIndices = new int[n+1];
        int[] colIndices = new int[n+1];
        int[] paintedRowCnt = new int[numRows];
        int[] paintedColCnt = new int[numCols];
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                int val = mat[i][j];
                rowIndices[val] = i;
                colIndices[val] = j;
            }
        }
w
        for (int i = 0; i < n; i++)
        {
            int val = arr[i];
            paintedRowCnt[rowIndices[val]]++;
            paintedColCnt[colIndices[val]]++;
            if (paintedRowCnt[rowIndices[val]] == numCols || paintedColCnt[colIndices[val]] == numRows)
            {
                return i;
            }
        }

        return -1;
    }

    private static void Main(string[] args)
    {
        FirstCompleteIndex([1, 3, 4, 2], [[1, 4], [2, 3]]);
    }
}