// Double linked list
public class Node
{
    public Node Prev;
    public Node Next;
    public int Value;

    public Node(int value)
    {
        Value = value;
    }
}

public class MyCircularDeque
{
    private int Len;
    private int Cap;
    private Node Head = new Node(-1);
    private Node Tail = new Node(-1);

    public MyCircularDeque(int k)
    {
        Len = 0;
        Cap = k;
        Head.Next = Tail;
        Tail.Prev = Head;
    }

    public bool InsertFront(int value)
    {
        if (Len == Cap) return false;

        AddNode(Head, value);
        return true;
    }

    public bool InsertLast(int value)
    {
        if (Len == Cap) return false;

        AddNode(Tail.Prev, value);
        return true;
    }

    public bool DeleteFront()
    {
        if (Len == 0 || Head.Next == null) return false;
        RemoveNode(Head.Next);
        return true;
    }

    public bool DeleteLast()
    {
        if (Len == 0 || Tail.Prev == null) return false;
        RemoveNode(Tail.Prev);
        return true;
    }

    public int GetFront()
    {
        if (Len == 0) return -1;
        return Head.Next.Value;
    }

    public int GetRear()
    {
        if (Len == 0) return -1;
        return Tail.Prev.Value;
    }

    public bool IsEmpty()
    {
        return Len == 0;
    }

    public bool IsFull()
    {
        return Cap == Len;
    }

    private void AddNode(Node node, int val)
    {
        Node newNode = new Node(val);
        Node next = node.Next;
        newNode.Prev = node;
        newNode.Next = next;
        node.Next = newNode;
        next.Prev = newNode;
        Len++;
    }

    private void RemoveNode(Node node)
    {
        Node next = node.Next;
        Node prev = node.Prev;
        prev.Next = next;
        next.Prev = prev;
        Len--;
    }

    public static void Main(string[] args)
    {
        MyCircularDeque obj = new MyCircularDeque(5);
        Console.WriteLine(obj.InsertFront(7));
        Console.WriteLine(obj.InsertLast(0));
        Console.WriteLine(obj.GetFront());
        Console.WriteLine(obj.InsertLast(3));
        Console.WriteLine(obj.GetFront());
        Console.WriteLine(obj.InsertFront(9));
        Console.WriteLine(obj.GetRear());
        Console.WriteLine(obj.GetFront());
        Console.WriteLine(obj.GetFront());
        Console.WriteLine(obj.DeleteLast());
        Console.WriteLine(obj.GetRear());
    }
}

