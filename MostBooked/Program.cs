public class Solution
{
    public int MostBooked(int n, int[][] meetings)
    {
        Array.Sort(meetings, (a, b) => a[0] - b[0]);
        PriorityQueue<int, int> freeRooms = new();
        // end time of room and room number
        PriorityQueue<long[], long[]> occupiedRooms = new(Comparer<long[]>.Create((x, y) => x[0] != y[0] ? x[0].CompareTo(y[0]) : x[1].CompareTo(y[1])));
        int[] roomUsedCount = new int[n];
        for (int i = 0; i < n; i++)
        {
            freeRooms.Enqueue(i, i);
        }
        foreach (int[] m in meetings)
        {
            int start = m[0], end = m[1];
            while (occupiedRooms.TryPeek(out long[]? roomWithEndTime, out long[]? _) && roomWithEndTime[0] <= start)
            {
                int roomNumber = (int)roomWithEndTime[1];
                freeRooms.Enqueue(roomNumber, roomNumber);
            }

            if (freeRooms.TryDequeue(out int room, out int _))
            {
                occupiedRooms.Enqueue([end, room], [end, room]);
                roomUsedCount[room]++;
            }
            else
            {
                long[] availabilityRoomAtTime = occupiedRooms.Dequeue();
                int endTime = (int)availabilityRoomAtTime[0], incomingRoom = (int)availabilityRoomAtTime[1];
                occupiedRooms.Enqueue([endTime + end - start, incomingRoom], [endTime + end - start, incomingRoom]);
                roomUsedCount[incomingRoom]++;
            }
        }
        int maxMeetingCount = 0, maxMeetingRoom = 0;
        for (int i = 0; i < n; i++)
        {
            if (roomUsedCount[i] > maxMeetingCount)
            {
                maxMeetingCount = roomUsedCount[i];
                maxMeetingRoom = i;
            }
        }
        return maxMeetingRoom;
    }

    public static void Main(string[] args)
    {
        var sln = new Solution();
        Console.WriteLine(sln.MostBooked(2, [[0, 10], [1, 5], [2, 7], [3, 4]]));
    }
}