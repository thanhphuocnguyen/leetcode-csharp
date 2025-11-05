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
    public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
    {
        ListNode temp = list1;
        ListNode aNode = null;
        ListNode bNode = null;
        int idx = 0;
        while (temp != null)
        {
            if (a >= 0 && idx == a - 1)
            {
                aNode = temp;
            }
            if (idx == b + 1)
            {
                bNode = temp;
            }
            idx++;
            temp = temp.next;
        }

        if (aNode != null)
        {
            aNode.next = list2;
        }
        else
        {
            list1 = list2;
        }
        temp = list2;
        while (temp.next != null)
        {
            temp = temp.next;
        }

        temp.next = bNode;
        return list1;
    }

    public static void Main()
    {
        var sln = new Solution();
        ListNode l1 = new ListNode(10, new(1, new(13, new(6, new(9, new(5))))));
        ListNode l2 = new ListNode(1000000, new(1000001, new(1000002)));
        sln.MergeInBetween(l1, 3, 4, l2);
    }
}