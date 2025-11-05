public class Solution
{
    public double MaxAverageRatio(int[][] classes, int extraStudents)
    {
        PriorityQueue<(double gain, int passes, int students), double> pq = new(Comparer<double>.Create((a, b) => b.CompareTo(a)));
        foreach (int[] cl in classes)
        {
            int passes = cl[0], students = cl[1];
            double gain = CalculateGain(passes, students);
            pq.Enqueue((gain, passes, students), gain);
        }
        while (extraStudents > 0)
        {
            extraStudents--;
            var potential = pq.Dequeue();
            int passes = potential.passes + 1, students = potential.students + 1;
            double newGain = CalculateGain(passes, students);
            pq.Enqueue((newGain, passes, students), newGain);
        }

        double ans = 0;
        while (pq.Count > 0)
        {
            var cl = pq.Dequeue();
            ans += (double)cl.passes / cl.students;
        }
        return ans/classes.Length;
    }

    private double CalculateGain(int passes, int students)
    {
        return (double)(passes + 1) / (students + 1) - (double)passes / students;
    }

    public static void Main()
    {
        Solution solution = new();
        int[][] classes = [[1,2],[3,5],[2,2]];
        int extraStudents = 2;
        double result = solution.MaxAverageRatio(classes, extraStudents);
        Console.WriteLine(result);
    }
}