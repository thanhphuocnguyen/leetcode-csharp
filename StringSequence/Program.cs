using System.Text;

IList<string> StringSequence(string target)
{
    IList<string> ans = new List<string>();
    StringBuilder sb = new();
    int i = 0;
    foreach (char c in target)
    {
        sb.Append('a');
        ans.Add(sb.ToString());
        while (sb[i] != c)
        {
            sb[i] = (char)(sb[i] + 1);
            ans.Add(sb.ToString());
        }

        i++;
    }
    return ans;
}

StringSequence("abc");