bool CanVisitAllRooms(IList<IList<int>> rooms)
{
    bool[] visited = new bool[rooms.Count];
    Queue<int> q = new();

    q.Enqueue(0);
    visited[0] = true;
    int cnt = 1;
    while (q.Count > 0)
    {
        var room = q.Dequeue();
        foreach (int key in rooms[room])
        {
            if (!visited[key])
            {
                cnt++;
                visited[key] = true;
                q.Enqueue(key);
            }
        }
    }
    return cnt >= rooms.Count;
}

Console.WriteLine(CanVisitAllRooms([[1], [2], [3], []]));
Console.WriteLine(CanVisitAllRooms([[1, 2], [2, 1], [1]]));
Console.WriteLine(CanVisitAllRooms([[1, 3], [3, 0, 1], [2], [0]]));