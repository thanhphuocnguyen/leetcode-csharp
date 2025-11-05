
// Definition for singly-linked list.
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}
public class Solution
{
    // clockwise: right -> down -> left -> up
    private readonly int[][] directions = [[0, 1], [1, 0], [0, -1], [-1, 0]];
    public int[][] SpiralMatrix(int m, int n, ListNode head)
    {
        int[][] ans = new int[m][];
        for (int i = 0; i < m; i++)
        {
            ans[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                ans[i][j] = -1;
            }
        }
        int currDirection = 0, currRow = 0, currCol = 0;
        while (head != null)
        {
            ans[currRow][currCol] = head.val;
            int newRow = currRow + directions[currDirection][0];
            int newCol = currCol + directions[currDirection][1];
            if (newRow >= m || newCol >= n || newRow < 0 || newCol < 0 || ans[newRow][newCol] != -1)
            {
                currDirection = (1 + currDirection) % 4;
            }

            currRow += directions[currDirection][0];
            currCol += directions[currDirection][1];
            head = head.next;
        }

        return ans;
    }
}

public class Program
{
    public static void Main()
    {
        ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
        Solution solution = new Solution();
        int[][] ans = solution.SpiralMatrix(3, 3, head);
        foreach (int[] row in ans)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }
}