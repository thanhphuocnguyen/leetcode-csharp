int PivotInteger(int n)
{
    int i = 1, j = n;
    int prefix = 0, suffix = 0;
    while (i <= j)
    {
        if (prefix == 0)
        {
            prefix += i;
            i++;
        }
        if (suffix == 0)
        {
            suffix += j;
            j--;
        }
        if (prefix == suffix)
        {
            return i;
        }
        while (prefix != 0 && prefix < suffix)
        {
            prefix += i;
            i++;
        }

        while (suffix != 0 && suffix < prefix)
        {
            suffix += j;
            j--;
        }

    }
    return -1;
}

Console.WriteLine(PivotInteger(8));