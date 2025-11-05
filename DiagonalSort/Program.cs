int[][] DiagonalSort(int[][] mat)
{
    int m = mat.Length, n = mat[0].Length;
    for (int i = 0; i < m; i++)
    {
        List<int> temp = new();
        for (int j = 0; j + i < m && j < n; j++)
        {
            temp.Add(mat[i + j][j]);
        }
        temp.Sort();
        for (int j = 0; j + i < m; j++)
        {
            mat[i + j][j] = temp[j];
        }
    }

    for (int j = 1; j < n; j++)
    {
        List<int> temp = new();
        for (int i = 0; j + i < n && j < m; i++)
        {
            temp.Add(mat[i][i + j]);
        }
        temp.Sort();
        for (int i = 0; j + i < n; i++)
        {
            mat[i][i + j] = temp[i];
        }

    }
    return mat;
}
DiagonalSort([[37, 98, 82, 45, 42]]);
