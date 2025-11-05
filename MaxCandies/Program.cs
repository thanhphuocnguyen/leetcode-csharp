public class Solution
{
    public int MaxCandies(int[] status, int[] candies, int[][] keys, int[][] containedBoxes, int[] initialBoxes)
    {
        int n = candies.Length;
        bool[] visited = new bool[n];
        bool[] canOpen = new bool[n];
        Queue<int> openedBoxes = new();
        int ans = 0;
        foreach (int box in initialBoxes)
        {

            if (status[box] == 1)
            {
                openedBoxes.Enqueue(box);
            }
            else
            {

            }
        }

        while (openedBoxes.Count > 0)
        {
            int currBox = openedBoxes.Dequeue();
            visited[currBox] = true;
            ans += candies[currBox];
            foreach (int key in keys[currBox])
            {
                canOpen[key] = true;
                if (visited[key] == false && status[key] == 1)
                {
                    openedBoxes.Enqueue(key);
                }
            }
            foreach (int box in containedBoxes[currBox])
            {

            }
        }

        return ans;
    }
}