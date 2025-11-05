public class Solution
{
    public int CalPoints(string[] operations)
    {
        List<int> records = new();
        foreach (string op in operations)
        {
            switch (op)
            {
                case "C":
                    records.RemoveAt(records.Count - 1);
                    break;
                case "D":
                    records.Add(records[records.Count - 1] * 2);
                    break;
                case "+":
                    records.Add(records[records.Count - 1] + records[records.Count - 2]);
                    break;
                default:
                    int sign = 1;
                    int num = 0;
                    foreach (char c in op)
                    {
                        if (c == '-')
                        {
                            sign = -1;
                            continue;
                        }
                        num = num * 10 + (c - '0');
                    }
                    records.Add(num * sign);
                    break;
            }
        }

        int ans = 0;
        foreach (int rc in records)
        {
            ans += rc;
        }
        return ans;
    }
}