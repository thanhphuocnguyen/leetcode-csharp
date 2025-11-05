public class Solution
{
    private class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int Height { get; set; }

        public Cell(int row, int column, int height)
        {
            Row = row;
            Column = column;
            Height = height;
        }
    }

    public int TrapRainWater(int[][] heightMap)
    {
        int[] dRow = [0, 0, -1, 1];
        int[] dCol = [-1, 1, 0, 0];
        int numOfRows = heightMap.Length, numOfCols = heightMap.Length;
        bool[,] visited = new bool[numOfRows, numOfCols];
        PriorityQueue<Cell, int> boundary = new();
        for (var i = 0; i < numOfRows; i++)
        {
            boundary.Enqueue(new Cell(i, 0, heightMap[i][0]), heightMap[i][0]);
            boundary.Enqueue(new Cell(i, numOfCols - 1, heightMap[i][numOfCols - 1]), heightMap[i][numOfCols - 1]);
            visited[i, 0] = visited[i, numOfCols - 1] = true;
        }

        for (var i = 0; i < numOfCols; i++)
        {
            boundary.Enqueue(new Cell(0, i, heightMap[0][i]), heightMap[0][i]);
            boundary.Enqueue(new Cell(numOfRows - 1, i, heightMap[i][numOfRows - 1]), heightMap[i][numOfRows - 1]);
            visited[0, i] = visited[numOfRows - 1, i] = true;
        }

        var ans = 0;
        while (boundary.Count > 0)
        {
            var cell = boundary.Dequeue();
            
        }

        return ans;
    }

    private static bool IsValidCell(int row, int column, int numOfRows, int numOfCols)
    {
        return row >= 0 && row < numOfRows && column >= 0 && column < numOfCols;
    }
}