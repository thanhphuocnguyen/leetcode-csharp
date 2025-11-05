public class Router
{
    int limit;
    Queue<int[]> packets = new();
    Dictionary<int, Destination> destMap = new();
    public Router(int memoryLimit)
    {
        limit = memoryLimit;
        destMap = new();
        packets = new();
    }

    public bool AddPacket(int source, int destination, int timestamp)
    {
        if (!destMap.ContainsKey(destination))
        {
            destMap[destination] = new();
        }

        if (destMap[destination].ContainsKey(GetKey(source, destination, timestamp)))
        {
            return false;
        }

        if (limit == packets.Count)
        {
            // remove at peek
            var outdated = packets.Dequeue();
            if (destMap[outdated[1]].timestamps.Count > 0)
            {
                destMap[outdated[1]].RemoveFirst();
            }
        }
        destMap[destination].AddTimestamp(timestamp);
        packets.Enqueue([source, destination, timestamp]);
        limit++;
        return true;
    }

    public int[] ForwardPacket()
    {
        if (packets.Count == 0)
        {
            return [];
        }
        var outdated = packets.Dequeue();
        destMap[outdated[1]].RemoveFirst();
        limit--;
        return outdated;
    }

    public int GetCount(int destination, int startTime, int endTime)
    {
        return destMap[destination].QueryRange(startTime, endTime);
    }

    private int GetKey(int src, int dest, int time)
    {
        return (src << (18 + 30)) | (dest << 30) | time;
    }

    public class Destination
    {
        public HashSet<int> keys;
        public List<int> timestamps;

        public Destination()
        {
            keys = new();
            timestamps = new();
        }

        public void AddTimestamp(int time)
        {
            timestamps.Add(time);
        }

        public void RemoveFirst()
        {
            timestamps.RemoveAt(0);
        }

        public bool ContainsKey(int key)
        {
            return keys.Contains(key);
        }

        public int QueryRange(int startTime, int endTime)
        {
            int right = UpperBound(endTime);
            int left = LowerBound(startTime);
            return right - left;
        }

        public int UpperBound(int endTime)
        {
            int left = 0, right = timestamps.Count;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (timestamps[mid] < endTime)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            return left;
        }

        public int LowerBound(int startTime)
        {
            int left = 0, right = timestamps.Count;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (timestamps[mid] <= startTime)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            return left;
        }
    }
}

/**
 * Your Router object will be instantiated and called as such:
 * Router obj = new Router(memoryLimit);
 * bool param_1 = obj.AddPacket(source,destination,timestamp);
 * int[] param_2 = obj.ForwardPacket();
 * int param_3 = obj.GetCount(destination,startTime,endTime);
 */