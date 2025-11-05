public class Program
{
    /**
    * Definition for singly-linked list.
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

    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 == null) return list2;
        if (list2 == null) return list1;
        ListNode head;
        ListNode tail;
        // init ans 
        if (list1.val < list2.val)
        {
            head = tail = list1;
            list1 = list1.next;
        }
        else
        {
            head = tail = list2;
            list2 = list2.next;
        }

        // merge

        while (list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                // append list1
                tail.next = list1;
                tail = list1;
                // move list1
                list1 = list1.next;
            }
            else
            {
                // set tail next to list2
                tail.next = list2;
                // move tail to list2
                tail = list2;
                // move list2
                list2 = list2.next;
            }
        }

        // append the rest of the list
        tail.next = list1 != null ? list1 : list2;

        return head;
    }

    public static void Main(string[] args)
    {
        ListNode list1 = new(1, new(2, new(4)));
        ListNode list2 = new(1, new(3, new(4)));
        Program program = new();
        ListNode ans = program.MergeTwoLists(list1, list2);
        while (ans.next != null)
        {
            Console.WriteLine(ans.val);
            ans = ans.next;
        }
    }
}