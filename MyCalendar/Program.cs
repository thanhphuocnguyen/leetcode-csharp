public class MyCalendar
{
    public class BSTNode
    {
        public int Start;
        public int End;
        public BSTNode Left;
        public BSTNode Right;

        public BSTNode(int start, int end, BSTNode left = null, BSTNode right = null)
        {
            Start = start;
            End = end;
            Left = left;
            Right = right;
        }
    }

    BSTNode Root;

    public MyCalendar()
    {
        Root = new BSTNode(-2, -1);
    }

    public bool Book(int start, int end)
    {
        return DFS(Root, start, end);
    }

    public bool DFS(BSTNode node, int start, int end)
    {
        if (start >= node.End)
        {
            if (node.Right == null)
            {
                node.Right = new BSTNode(start, end);
                return true;
            }
            else
            {
                return DFS(node.Right, start, end);
            }
        }
        else if (end <= node.Start)
        {
            if (node.Left == null)
            {
                node.Left = new BSTNode(start, end);
                return true;
            }
            else
            {
                return DFS(node.Left, start, end);
            }
        }
        else
        {
            return false;
        }
    }
}

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */