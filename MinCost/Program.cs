public class Solution
{
    public int MinCost(int[][] grid)
    {
        int[][] dirs =
        [
            [0, 1], // right
            [0, -1], // left
            [1, 0], // down
            [-1, 0], // up
        ];
        int numRows = grid.Length, numCols = grid[0].Length;
        int[][] minCost = new int[numRows][];
        for (int i = 0; i < numRows; i++)
        {
            minCost[i] = new int[numCols];
            Array.Fill(minCost[i], int.MaxValue);
        }

        LinkedList<int[]> deque = new();
        deque.AddLast([0, 0]);
        minCost[0][0] = 0;
        while (deque.Count > 0)
        {
            var currCell = deque.First.Value;
            deque.RemoveFirst();
            int currRow = currCell[0], currCol = currCell[1];
            for (int i = 0; i < 4; i++)
            {
                int[] dir = dirs[i];
                int moveRow = dir[0], moveCol = dir[1];
                int nextRow = currRow + moveRow, nextCol = currCol + moveCol;
                if (IsOutBound(numRows, numCols, nextRow, nextCol))
                {
                    continue;
                }

                int cost = grid[nextRow][nextCol] == i + 1 ? 0 : 1;
                minCost[nextRow][nextCol] = cost;
                if (cost == 1)
                {
                    deque.AddLast([nextRow, nextCol]);
                }
                else
                {
                    deque.AddFirst([nextRow, nextCol]);
                }
            }
        }

        return minCost[numRows - 1][numCols - 1];
    }

    private static bool IsOutBound(int numRows, int numCols, int currRow, int currCol)
    {
        return currRow < 0 || currCol < 0 || currRow >= numRows || currCol >= numCols;
    }
}