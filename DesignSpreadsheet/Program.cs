public class Spreadsheet
{
    int[,] sheet;
    public Spreadsheet(int rows)
    {
        sheet = new int[rows, 26];
    }

    private (int row, int col) GetCoord(string cell)
    {
        int row = 0, col = cell[0] - 'A';
        for (int i = 1; i < cell.Length; i++)
        {
            row = row * 10 + (cell[i] - '0');
        }
        return (row - 1, col);
    }

    private bool IsUpperAlpha(char c)
    {
        return c >= 'A' && c <= 'Z';
    }

    public void SetCell(string cell, int value)
    {
        var (row, col) = GetCoord(cell);
        sheet[row, col] = value;
    }

    public void ResetCell(string cell)
    {
        var (row, col) = GetCoord(cell);
        sheet[row, col] = 0;
    }

    public int GetValue(string formula)
    {
        string[] vals = formula.Substring(1).Split('+');

        int ans = 0;
        foreach (string val in vals)
        {
            int row = -1;
            int col = -1;
            bool isCell = false;
            int num = 0;
            foreach (char c in val)
            {
                if (IsUpperAlpha(c))
                {
                    row = 0;
                    isCell = true;
                    col = c - 'A';
                }
                else if (isCell)
                {
                    row = row * 10 + (c - '0');
                }
                else
                {
                    num = num * 10 + (c - '0');
                }
            }
            if (row != -1)
            {
                num = sheet[row - 1, col];
            }
            ans += num;
        }
        return ans;
    }
    public static void Main()
    {
        var sln = new Spreadsheet(576);
        sln.SetCell("H45", 88383);
        Console.WriteLine(sln.GetValue("=992+H45"));
    }
}

/**
 * Your Spreadsheet object will be instantiated and called as such:
 * Spreadsheet obj = new Spreadsheet(rows);
 * obj.SetCell(cell,value);
 * obj.ResetCell(cell);
 * int param_3 = obj.GetValue(formula);
 */