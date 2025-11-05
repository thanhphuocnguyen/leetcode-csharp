int RemoveStones(int[][] stones)
{
    bool[] visited = new bool[stones.Length];
    int groupCount = 0;
    for (int i = 0; i < stones.Length; i++)
    {
        if (!visited[i])
        {
            DFS(stones, visited, i);
            groupCount++;
        }
    }

    return stones.Length - groupCount;
}

void DFS(int[][] stones, bool[] visited, int idx)
{
    visited[idx] = true;
    for (int i = 0; i < stones.Length; i++)
    {
        if (!visited[i] && (stones[i][0] == stones[idx][0] || stones[i][1] == stones[idx][1]))
        {
            DFS(stones, visited, i);
        }
    }
}

Console.WriteLine(RemoveStones([[0,0],[0,1],[1,0],[1,2],[2,1],[2,2]]));