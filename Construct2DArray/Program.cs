// See https://aka.ms/new-console-template for more information
int[][] Construct2DArray(int[] original, int m, int n)
{
    if (m * n != original.Length) return [];
    int[][] ans = new int[m][];
    for (int i = 0; i < m; i++)
    {
        if (ans[i] == null)
        {
            ans[i] = new int[n];
        }
        for (int j = 0; j < n; j++)
        {
            ans[i][j] = original[i * n + j];
        }
    }

    return ans;
}

int[] original = { 1, 2, 3, 4 };

int[][] ans = Construct2DArray(original, 2, 2);

foreach (var item in ans)
{
    foreach (var i in item)
    {
        Console.Write(i + " ");
    }
    Console.WriteLine();
}