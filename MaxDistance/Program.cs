// See https://aka.ms/new-console-template for more information
int MaxDistance(int[][] arrays)
{
    int max = arrays[0][arrays[0].Length - 1];
    int min = arrays[0][0];
    int result = 0;
    for (int i = 1; i < arrays.Length; i++)
    {
        // The maximum distance between two arrays is the maximum of the following:
        // 1. The difference between the last element of the current array and the first element of the previous array
        // 2. The difference between the last element of the previous array and the first element of the current array
        // 3. The maximum distance between the previous arrays
        result = Math.Max(
            result,
            Math.Max(
                Math.Abs(arrays[i][0] - max),
                Math.Abs(min - arrays[i][arrays[i].Length - 1])));

        max = Math.Max(max, arrays[i][arrays[i].Length - 1]);
        min = Math.Min(min, arrays[i][0]);
    }
    return result;
}

int[][] arrays = new int[3][];

arrays[0] = new int[] { 1, 2, 3 };

arrays[1] = new int[] { 4, 5 };

arrays[2] = new int[] { 1, 2, 3 };

Console.WriteLine(MaxDistance(arrays));