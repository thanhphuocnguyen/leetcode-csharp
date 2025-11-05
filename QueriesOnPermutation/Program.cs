public class Solution
{
    public int[] ProcessQueries(int[] queries, int m)
    {
        Node head = new(1);
        Node temp = head;
        for (int i = 2; i <= m; i++)
        {
            temp.next = new(i);
            temp = temp.next;
        }
        int[] ans = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            Node tmp = head;
            Node prev = head;
            int j = 0;
            while (tmp.val != queries[i])
            {
                prev = tmp;
                tmp = tmp.next;
                j++;
            }
            if (j == 0)
            {
                head = head.next;
            }
            else if (j == m - 1)
            {
                prev.next = null;
            }
            else if (prev.next != null)
            {
                prev.next = prev.next.next;
            }
            ans[i] = j;
            Node newHead = new(queries[i]);
            newHead.next = head;
            head = newHead;
        }
        return ans;
    }

    public static void Main()
    {
        var sln = new Solution();
        sln.ProcessQueries([1, 2, 1], 3);
    }
}

public class Node(int val)
{
    public Node next;
    public int val = val;
}