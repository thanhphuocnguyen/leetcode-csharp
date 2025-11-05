using System.Text;

string StringHash(string s, int k)
{
    StringBuilder sb = new();
    int sum = 0;
    for (int i = 0; i < s.Length; i++)
    {
        if (i > 0 && i % k == 0)
        {
            sb.Append((char)((sum % 26) + 'a'));
            sum = 0;
        }
        sum += s[i] - 'a';
    }
    sb.Append((char)((sum % 26) + 'a'));
    return sb.ToString();
}

StringHash("mxz", 3);
StringHash("abcd", 2);