string ReplaceDigits(string s)
{
    char[] arr = new char[s.Length];
    for (int i = 0; i < s.Length; i += 2)
    {
        arr[i] = s[i];
    }
    for (int i = 1; i < s.Length; i += 2)
    {
        arr[i] = (char)((s[i - 1] - 'a' + (s[i] - '0')) % 26 + 'a');
    }
    return new string(arr);
}

Console.WriteLine(ReplaceDigits("a1c1e1"));
Console.WriteLine(ReplaceDigits("a1b2c3d4e"));