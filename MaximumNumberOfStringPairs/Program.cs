int MaximumNumberOfStringPairs(string[] words)
{
    HashSet<string> set = new();
    int ans = 0;
    foreach (string w in words)
    {
        if (set.Contains(w))
        {
            ans++;
        }
        else
        {
            char[] rv = new char[w.Length];
            for (int i = 0, j = w.Length - 1; i < j; i++, j--)
            {
                rv[i] = w[j];
                rv[j] = w[i];
            }
            set.Add(new string(rv));
        }
    }
    return ans;
}

Console.WriteLine(MaximumNumberOfStringPairs(["cd", "ac", "dc", "ca", "zz"]));