public class Solution
{
    public int MaxTaskAssign(int[] tasks, int[] workers, int pills, int strength)
    {
        Array.Sort(tasks);
        Array.Sort(workers);
        int low = 1, high = Math.Min(tasks.Length, workers.Length), ans = 0;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            if (Check(tasks, workers, pills, strength, mid))
            {
                ans = mid;
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        return ans;
    }

    private static bool Check(int[] tasks, int[] workers, int pills, int strength, int mid)
    {
        int p = pills;
        SortedDictionary<int, int> ws = new();
        for (int i = workers.Length - mid; i < workers.Length; i++)
        {
            ws[workers[i]] = ws.GetValueOrDefault(workers[i], 0) + 1;
        }

        for (int i = mid - 1; i >= 0; i--)
        {
            int key = ws.Last().Key;
            if (key >= tasks[i])
            {
                ws[key] = ws[key] - 1;
                if (ws[key] == 0)
                {
                    ws.Remove(key);
                }
            }
            else
            {
                if (p == 0)
                {
                    return false;
                }
                int neededStrength = tasks[i] - strength;
                key = -1;
                var keys = ws.Keys.ToArray();
                for (int j = keys.Length - 1; j >= 0; j--)
                {
                    if (keys[j] >= neededStrength)
                    {
                        key = keys[j];
                    }
                    else
                    {
                        break;
                    }
                }
                if (key == -1)
                {
                    return false;
                }
                ws[key]--;
                if (ws[key] == 0)
                {
                    ws.Remove(key);
                }
                p--;
            }
        }
        return true;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] tasks = [3, 2, 1];
        int[] workers = [0, 3, 3];
        int pills = 1;
        int strength = 1;
        Console.WriteLine(solution.MaxTaskAssign(tasks, workers, pills, strength)); // Output: 2

    }