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
    public ListNode DoubleIt(ListNode head)
    {
        ListNode temp = head;
        ListNode prev = null;
        while (temp != null)
        {
            int doubleVal = temp.val * 2;
            if (doubleVal > 9)
            {
                int carry = doubleVal / 10;
                temp.val = doubleVal % 10;
                if (prev != null)
                {
                    prev.val += carry;
                }
                else
                {
                    ListNode newNode = new ListNode(carry);
                    newNode.next = head;
                    head = newNode;

                }
            }
            else
            {
                temp.val = doubleVal;
            }
            prev = temp;
            temp = temp.next;
        }

        return head;
    }

    public static void Main(string[] args)
    {
        ListNode head = new ListNode(9);
        head.next = new ListNode(9);
        head.next.next = new ListNode(9);
        Solution solution = new Solution();
        ListNode result = solution.DoubleIt(head);
        while (result != null)
        {
            Console.WriteLine(result.val);
            result = result.next;
        }
    }
}