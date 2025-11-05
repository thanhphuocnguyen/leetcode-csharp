public class Solution
{
    public int SmallestChair(int[][] times, int targetFriend)
    {
        int n = times.Length;
        int[][] orderedTimes = times.Select(a => a.ToArray()).ToArray();
        Array.Sort(orderedTimes, (a, b) => a[0].CompareTo(b[0]));

        PriorityQueue<int, int> emptySeats = new();
        // int[] is [leaveTime, currentSeat]
        PriorityQueue<int[], int> occupiedSeats = new();

        for (int i = 0; i < n; i++)
        {
            emptySeats.Enqueue(i, i);
        }

        for (int i = 0; i < n; i++)
        {
            int arrival = orderedTimes[i][0], leave = orderedTimes[i][1];
            // if leave time is before arrival so leave the current occupied seat to empty seats
            while (occupiedSeats.Count > 0 && occupiedSeats.Peek()[0] <= arrival)
            {
                // current occupiled chair free
                int leavedChair = occupiedSeats.Dequeue()[1];
                emptySeats.Enqueue(leavedChair, leavedChair);
            }

            int currentEmptySeat = emptySeats.Dequeue();
            if (i == targetFriend)
            {
                return currentEmptySeat;
            }
            occupiedSeats.Enqueue([leave, currentEmptySeat], currentEmptySeat);
        }
        return -1;
    }
}