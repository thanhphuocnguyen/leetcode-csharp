int[][] directions = [[0, 1], [1, 0], [0, -1], [-1, -0]]; //x,y: e, s, w, n

int RobotSim(int[] commands, int[][] obstacles)
{
    int x = 0, y = 0;
    HashSet<string> obstacleSet = new();
    int d = 0;
    foreach (int[] obs in obstacles)
    {
        obstacleSet.Add($"{obs[0]},{obs[1]}");
    }
    int ans = 0;
    foreach (int cmd in commands)
    {
        if (cmd == -1)
        {
            d = (d + 1) % 4;
        }
        else if (cmd == -2)
        {
            d = (d + 3) % 4;
        }
        else if (obstacles.Length > 0)
        {
            for (int i = 0; i < cmd; i++)
            {
                int nx = x + directions[d][0];
                int ny = y + directions[d][1];
                if (obstacleSet.Contains($"{nx},{ny}"))
                {
                    break;
                }
                x = nx;
                y = ny;
                ans = Math.Max(ans, x * x + y * y);
            }
        }
        else
        {
            x += cmd * directions[d][0];
            y += cmd * directions[d][1];
            ans = Math.Max(ans, x * x + y * y);
        }
    }

    return ans;
}

Console.WriteLine(RobotSim([4, -1, 4, -2, 4], [[2, 4]])); // 65
Console.WriteLine(RobotSim([4, -1, 3], [])); // 65
Console.WriteLine(RobotSim([6, -1, -1, 6], [])); // 65