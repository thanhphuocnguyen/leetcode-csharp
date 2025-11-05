int GarbageCollection(string[] garbage, int[] travel)
{
    int[] prefixSum = new int[travel.Length + 1];
    for (int i = 1; i <= travel.Length; i++)
    {
        prefixSum[i] = prefixSum[i - 1] + travel[i - 1];
    }
    int ans = 0;
    bool seenG = false, seenM = false, seenP = false;
    foreach (string gb in garbage)
    {
        ans += gb.Length;
    }
    for (int i = garbage.Length-1; i >= 0; i--)
    {
        if (!seenG && garbage[i].Contains('G'))
        {
            ans += prefixSum[i];
            seenG = true;
        }
        if (!seenM && garbage[i].Contains('M'))
        {
            ans += prefixSum[i];
            seenM = true;
        }
        if (!seenP && garbage[i].Contains('P'))
        {
            ans += prefixSum[i];
            seenP = true;
        }
    }
    return ans;
}

Console.WriteLine(GarbageCollection(["G", "P", "GP", "GG"], [2, 4, 3]));