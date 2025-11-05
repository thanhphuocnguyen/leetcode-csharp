using System.Text;

Dictionary<int, string> roman = new()
{
    { 1000, "M" },
    { 900, "CM" },
    { 500, "D" },
    { 400, "CD" },
    { 100, "C" },
    { 90, "XC" },
    { 50, "L" },
    { 40, "XL" },
    { 10, "X" },
    { 9, "IX" },
    { 5, "V" },
    { 4, "IV" },
    { 1, "I" },
};

string IntToRoman(int num)
{
    StringBuilder sb = new();

    foreach (var item in roman)
    {
        while (num >= item.Key)
        {
            sb.Append(item.Value);
            num -= item.Key;
        }
    }

    return sb.ToString();
}

Console.WriteLine(IntToRoman(3749)); // MMMMDCCXLIX
Console.WriteLine(IntToRoman(58)); // MMMMDCCXLIX