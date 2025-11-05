public class MyLinkedList
{
    private class Node
    {
        public int Value;
        public Node Next;
        public Node(int val)
        {
            Value = val;
        }
    }

    private Node Head;
    private Node Tail;
    private int Len;

    public MyLinkedList()
    {
        Head = null;
        Tail = null;
        Len = 0;
    }

    public int Get(int index)
    {
        if (index >= Len)
        {
            return -1;
        }
        Node temp = Head;
        for (int i = 0; i < index; i++)
        {
            temp = temp.Next;
        }
        return temp.Value;
    }

    public void AddAtHead(int val)
    {
        if (Head == null)
        {
            Head = new Node(val);
            Tail = Head;
        }
        else
        {
            Node newNode = new(val);
            newNode.Next = Head;
            Head = newNode;
        }
        Len++;
    }

    public void AddAtTail(int val)
    {
        if (Tail == null)
        {
            Tail = new Node(val);
            Head = Tail;
        }
        else
        {
            Node newNode = new(val);
            Tail.Next = newNode;
            Tail = newNode;
        }
        Len++;
    }

    public void AddAtIndex(int index, int val)
    {
        if (index > Len)
        {
            return;
        }
        if (index == 0)
        {
            AddAtHead(val);
        }
        else if (index == Len)
        {
            AddAtTail(val);
        }
        else
        {
            Node temp = Head;
            for (int i = 0; i < index - 1; i++)
            {
                temp = temp.Next;
            }
            Node newNode = new(val);
            newNode.Next = temp.Next;
            temp.Next = newNode;
            Len++;
        }
    }

    public void DeleteAtIndex(int index)
    {
        if (index >= Len || Len == 0)
        {
            return;
        }
        if (index == 0)
        {
            Head = Head.Next;
        }
        else
        {
            Node temp = Head;
            for (int i = 0; i < index - 1; i++)
            {
                temp = temp.Next;
            }
            temp.Next = temp.Next.Next;
            if (index == Len - 1)
            {
                Tail = temp;
            }
        }
        Len--;
    }
}
// test case
// ["MyLinkedList","addAtHead","addAtHead","addAtHead","addAtIndex","deleteAtIndex","addAtHead","addAtTail","get","addAtHead","addAtIndex","addAtHead"]
//[[],[7],[2],[1],[3,0],[2],[6],[4],[4],[4],[5,0],[6]]
class Program
{
    static void Main(string[] args)
    {
        string[] commands = ["MyLinkedList", "addAtHead", "addAtHead", "addAtHead", "addAtIndex", "deleteAtIndex", "addAtHead", "addAtTail", "get", "addAtHead", "addAtIndex", "addAtHead"];
        int[][] values = [[], [7], [2], [1], [3, 0], [2], [6], [4], [4], [4], [5, 0], [6]];
        MyLinkedList obj = new MyLinkedList();

        for (int i = 1; i < commands.Length; i++)
        {
            if (commands[i] == "addAtHead")
            {
                obj.AddAtHead(values[i][0]);
            }
            else if (commands[i] == "addAtTail")
            {
                obj.AddAtTail(values[i][0]);
            }
            else if (commands[i] == "addAtIndex")
            {
                obj.AddAtIndex(values[i][0], values[i][1]);
            }
            else if (commands[i] == "deleteAtIndex")
            {
                obj.DeleteAtIndex(values[i][0]);
            }
            else if (commands[i] == "get")
            {
                Console.WriteLine(obj.Get(values[i][0]));
            }
        }
    }
}

/**
 * Your MyLinkedList object will be instantiated and called as such:
 * MyLinkedList obj = new MyLinkedList();
 * int param_1 = obj.Get(index);
 * obj.AddAtHead(val);
 * obj.AddAtTail(val);
 * obj.AddAtIndex(index,val);
 * obj.DeleteAtIndex(index);
 */