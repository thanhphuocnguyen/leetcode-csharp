public class TaskManager
{
    Dictionary<int, (int priority, int userId)> taskMap;
    PriorityQueue<(int priority, int taskId), (int priority, int taskId)> pq;
    public TaskManager(IList<IList<int>> tasks)
    {
        taskMap = new();
        pq = new(Comparer<(int priority, int taskId)>.Create((a, b) => a.priority == b.priority ? b.taskId.CompareTo(a.taskId) : b.priority.CompareTo(a.priority)));
        foreach (int[] task in tasks)
        {
            int userId = task[0], taskId = task[1], priority = task[2];
            taskMap[taskId] = (priority, userId);
            var pair = (priority, taskId);
            pq.Enqueue(pair, pair);
        }
    }

    public void Add(int userId, int taskId, int priority)
    {
        if (taskMap.ContainsKey(taskId))
        {
            return;
        }
        taskMap[taskId] = (priority, userId);
        var pair = (priority, taskId);
        pq.Enqueue(pair, pair);
    }

    public void Edit(int taskId, int newPriority)
    {
        if (!taskMap.ContainsKey(taskId))
        {
            return;
        }
        taskMap[taskId] = (newPriority, taskMap[taskId].userId);
        var pair = (newPriority, taskId);
        pq.Enqueue(pair, pair);
    }

    public void Rmv(int taskId)
    {
        if (!taskMap.ContainsKey(taskId))
        {
            return;
        }
        taskMap.Remove(taskId);
    }

    public int ExecTop()
    {
        while (pq.Count > 0)
        {
            var peek = pq.Peek();
            if (taskMap.ContainsKey(peek.taskId) && peek.priority == taskMap[peek.taskId].priority)
            {
                int userId = taskMap[peek.taskId].userId;
                pq.Dequeue();
                taskMap.Remove(peek.taskId);
                return userId;
            }
            else
            {
                pq.Dequeue();
            }
        }
        return -1;
    }

    public static void Main()
    {
        TaskManager sln = new TaskManager([]);
        string[] actions = ["TaskManager", "add", "edit", "execTop", "rmv", "add", "execTop"];
        int[][][] initData = [[[1, 101, 10], [2, 102, 20], [3, 103, 15]]];
        int[][] data = [[], [4, 104, 5], [102, 8], [], [101], [5, 105, 15], []];
        for (int i = 0; i < actions.Length; i++)
        {
            string action = actions[i];
            switch (action)
            {
                case "TaskManager":
                    sln = new(initData[i]);
                    break;
                case "add":
                    sln.Add(data[i][0], data[i][1], data[i][2]);
                    break;
                case "edit":
                    sln.Edit(data[i][0], data[i][1]);
                    break;
                case "execTop":
                    Console.WriteLine(sln.ExecTop());
                    break;
                case "rmv":
                    sln.Rmv(data[i][0]);
                    break;
                default:
                    break;
            }
        }
    }
}

/**
 * Your TaskManager object will be instantiated and called as such:
 * TaskManager obj = new TaskManager(tasks);
 * obj.Add(userId,taskId,priority);
 * obj.Edit(taskId,newPriority);
 * obj.Rmv(taskId);
 * int param_4 = obj.ExecTop();
 */