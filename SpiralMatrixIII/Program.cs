namespace LeetCode.SpiralMatrixIII;
public class Solution
{
    public int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart)
    {
        int[][] dir = [[0, 1], [1, 0], [0, -1], [-1, 0]];
        int[][] traversed = new int[cols * rows][];
        int step = 1, direction = 0, idx = 0;
        // traverse until idx >= cols*rows;
        traversed[idx++] = [rStart, cStart];
        while (idx < cols * rows)
        {
            for (int m = 0; m < 2; m++)
            {

                for (int n = 0; n < step; n++)
                {
                    rStart += dir[direction][0];
                    cStart += dir[direction][1];
                    if (rStart >= 0 && rStart < rows && cStart >= 0 && cStart < cols)
                    {
                        traversed[idx++] = [rStart, cStart];
                    }
                }

                direction = (direction + 1) % 4;
            }
            ++step;
        }

        return traversed;
    }


    public static void Main(string[] args)
    {
        var sol = new Solution();
        var result = sol.SpiralMatrixIII(5, 6, 1, 4);
        foreach (var item in result)
        {
            Console.WriteLine($"[{item[0]}, {item[1]}]");
        }
    }
}
