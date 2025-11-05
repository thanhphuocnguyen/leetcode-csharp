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
    public bool IsPalindrome(ListNode head)
    {
        ListNode slow = head, fast = head;
        // find middle of linked list
        while (fast != null && fast.next != null)
        {
            fast = fast.next.next;
            slow = slow.next;
        }

        // reverse till slow
        ListNode prev = null, rev = slow, next;
        while (rev != null)
        {
            next = rev.next;
            rev.next = prev;
            prev = rev;
            rev = next;
        }

        while (prev != null)
        {
            if (head.val != prev.val)
            {
                return false;
            }
            head = head.next;
            prev = prev.next;
        }

        return true;
    }

    public static void Main()
    {
        var sln = new Solution();
        ListNode list = new ListNode(1);
        Console.WriteLine(sln.IsPalindrome(list));

        list = new ListNode(1, new(2, new(2, new(1))));
        Console.WriteLine(sln.IsPalindrome(list));


        list = new ListNode(1, new(2));
        Console.WriteLine(sln.IsPalindrome(list));
    }
}