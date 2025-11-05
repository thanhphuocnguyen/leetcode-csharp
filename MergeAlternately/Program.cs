string MergeAlternately(string word1, string word2)
{
    int m = word1.Length, n = word2.Length;
    if (n < m)
    {
        (m, n) = (n, m);
        (word1, word2) = (word2, word1);
    }
    char[] ca = new char[m + n];
    int i = 0, j = 0, k = 0;
    while (i < m)
    {
        ca[k++] = word2[j++];
        ca[k++] = word1[i++];
    }
    while (j < n)
    {
        ca[k++] = word2[j++];
    }
    return new string(ca);
}

MergeAlternately("abcd", "pq");