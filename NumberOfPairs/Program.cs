public class Solution
{
    public int NumberOfPairs(int[][] points)
    {
        Array.Sort(points, (int[] a, int[] b) => a[0] != b[0] ? a[0] - b[0] : b[1] - a[1]);
        int ans = 0;
        for (int i = 0; i < points.Length; i++)
        {
            // upperLeft
            int x1 = points[i][0], y1 = points[i][1];
            for (int j = i + 1; j < points.Length; j++)
            {
                // lowerRight
                int x2 = points[j][0], y2 = points[j][1];
                // if point at j is not lower point at i
                if (y1 < y2)
                {
                    continue;
                }

                bool hasPointInRect = false;
                for (int k = i + 1; k < j; k++)
                {
                    // between upper left and lower right
                    int x = points[k][0], y = points[k][1];
                    if (x >= x1 && x <= x2 && y >= y2 && y <= y1)
                    {
                        hasPointInRect = true;
                        break;
                    }
                }
                if (!hasPointInRect)
                {
                    ans += 1;
                }
            }
        }
        return ans;
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.NumberOfPairs([[0, 1], [0, 2], [0, 4]]));
        Console.WriteLine(sln.NumberOfPairs([[0, 0], [0, 3]]));
        Console.WriteLine(sln.NumberOfPairs([[3, 1], [1, 3], [1, 1]]));
        Console.WriteLine(sln.NumberOfPairs([[6, 2], [4, 4], [2, 6]]));
        Console.WriteLine(sln.NumberOfPairs([[1, 1], [2, 2], [3, 3]]));
    }
}