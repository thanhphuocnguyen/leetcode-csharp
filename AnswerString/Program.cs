public class Solution
{
    public string AnswerString(string word, int numFriends)
    {
        int n = word.Length;
        if (numFriends <= 1)
        {
            return word;
        }
        int substrLen = n - numFriends + 1;
        string ans = "";
        for (int i = 0; i < n; i++)
        {
            string temp = "";
            if (i + substrLen > n)
            {
                temp = word.Substring(i);
            }
            else
            {
                temp = word.Substring(i, substrLen);
            }
            if (ans.Length == 0)
            {
                ans = temp;
            }
            else
            {
                for (int j = 0; j < Math.Min(temp.Length, ans.Length); j++)
                {
                    if (ans[j] < temp[j])
                    {
                        ans = temp;
                    }
                    else if (ans[j] == temp[j])
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        return ans;
    }
}