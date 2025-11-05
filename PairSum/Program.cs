/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
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
    public int PairSum(ListNode head)
    {
        ListNode temp = head;
        // find n
        int n = 0;
        while (temp != null)
        {
            n++;
            temp = temp.next;
        }

        // reverse first list
        temp = head;
        int i = 0;
        while (i < n / 2)
        {
            temp = temp.next;
            i++;
        }
        // reverse temp node that is in half node
        ListNode curr = temp;
        ListNode prev = null;
        ListNode next;
        while (curr != null)
        {
            next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }

        int ans = 0;
        while (prev != null)
        {
            ans = Math.Max(ans, head.val + prev.val);
            prev = prev.next;
            head = head.next;
        }
        return ans;
    }

    public static void Main()
    {
        var sln = new Solution();
        ListNode root = new(5, new(4, new(2, new(1))));
        Console.WriteLine(sln.PairSum(root));
    }
}