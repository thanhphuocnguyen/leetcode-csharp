public class Solution
{
    public string[] FindRestaurant(string[] list1, string[] list2)
    {
        int n = list1.Length, m = list2.Length;
        var table = BuildWordTable(n <= m ? list1 : list2);
        var ans = GetSumIndex(n <= m ? list2 : list1, table);
        return ans;
    }
    private Dictionary<string, int> BuildWordTable(string[] arr)
    {
        Dictionary<string, int> table = new();
        for (int i = 0; i < arr.Length; i++)
        {
            table[arr[i]] = i;
        }
        return table;
    }
    private string[] GetSumIndex(string[] arr, Dictionary<string, int> wordTable)
    {
        List<string> ans = new();
        int currMin = wordTable.Count + arr.Length;
        for (int i = 0; i < arr.Length; i++)
        {
            if (wordTable.ContainsKey(arr[i]))
            {
                if (i + wordTable[arr[i]] < currMin)
                {
                    ans.Clear();
                    ans.Add(arr[i]);
                    currMin =
                }
                else if (i + wordTable[arr[i]] == currMin)
                {
                    ans.Add(arr[i]);
                }
            }
        }
        return ans.ToArray();
    }

    public static void Main(string[] args)
    {
        var sln = new Solution();
        Console.WriteLine(sln.FindRestaurant(["Shogun", "Tapioca Express", "Burger King", "KFC"], ["KFC", "Shogun", "Burger King"]));
    }
}