public class Solution
{
    public int CountStudents(int[] students, int[] sandwiches)
    {
        Queue<int> q = new();
        foreach (int st in students)
        {
            q.Enqueue(st);
        }

        int i = 0;
        int cnt = 0;
        while (i < sandwiches.Length)
        {
            if (sandwiches[i] == q.Peek())
            {
                q.Dequeue();
                i++;
                cnt = 0;
            }
            else
            {
                q.Enqueue(q.Dequeue());
                cnt++;
                if (cnt == q.Count)
                {
                    return q.Count;
                }
            }
        }
        return 0;
    }

    public static void Main()
    {
        var sln = new Solution();
        sln.CountStudents([1, 1, 1, 0, 0, 1], [1, 0, 0, 0, 1, 1]);
    }
}