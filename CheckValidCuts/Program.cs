public class Solution
{
    public bool CheckValidCuts(int n, int[][] rectangles)
    {
        int[][] rectanglesSortByX = rectangles.Select(a => a.ToArray()).ToArray();
        int[][] rectanglesSortByY = rectangles.Select(a => a.ToArray()).ToArray();

        // sort by endY axis
        Array.Sort(rectanglesSortByY, (a, b) => a[3] - b[3]);
        // merge interval end Y prev and start Y current
        List<int[]> mergedY = new();
        foreach (int[] rec in rectanglesSortByY)
        {
            int prevIdx = mergedY.Count - 1;
            if (mergedY.Count == 0 || mergedY[prevIdx][3] <= rec[1])
            {
                mergedY.Add(rec.ToArray());
            }
            else
            {
                mergedY[prevIdx][0] = Math.Min(mergedY[prevIdx][0], rec[0]);
                mergedY[prevIdx][1] = Math.Min(mergedY[prevIdx][1], rec[1]);
                mergedY[prevIdx][2] = Math.Max(mergedY[prevIdx][2], rec[2]);
                mergedY[prevIdx][3] = Math.Max(mergedY[prevIdx][3], rec[3]);
            }
        }

        // sort by endX axis
        Array.Sort(rectanglesSortByX, (a, b) => a[0] - b[0]);
        // merge interval end X prev and start X current
        List<int[]> mergedX = new();
        foreach (int[] rec in rectanglesSortByX)
        {
            int prevIdx = mergedX.Count - 1;
            if (mergedX.Count == 0 || mergedX[prevIdx][2] <= rec[0])
            {
                mergedX.Add(rec.ToArray());
            }
            else
            {
                mergedX[prevIdx][0] = Math.Min(mergedX[prevIdx][0], rec[0]);
                mergedX[prevIdx][1] = Math.Min(mergedX[prevIdx][1], rec[1]);
                mergedX[prevIdx][2] = Math.Max(mergedX[prevIdx][2], rec[2]);
                mergedX[prevIdx][3] = Math.Max(mergedX[prevIdx][3], rec[3]);
            }
        }

        return mergedX.Count == 3 || mergedY.Count == 3;
    }

    public static void Main(string[] args)
    {
        var sln = new Solution();
        Console.WriteLine(sln.CheckValidCuts(3, [[0, 0, 1, 3], [1, 0, 2, 2], [2, 0, 3, 2], [1, 2, 3, 3]]));
    }
}