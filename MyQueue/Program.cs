public class MyQueue
{
    Stack<int> st1;
    Stack<int> st2;
    public MyQueue()
    {
        st1 = new();
        st2 = new();
    }

    public void Push(int x)
    {
        while (st1.Count > 0)
        {
            st2.Push(st1.Pop());
        }
        st1.Push(x);
        while (st2.Count > 0)
        {
            st1.Push(st2.Pop());
        }
    }


    public int Pop()
    {
        if (st1.Count == 0)
        {
            return -1;
        }
        return st1.Pop();
    }

    public int Peek()
    {
        return st1.Peek();
    }

    public bool Empty()
    {
        return st1.Count == 0;
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */
public static class Solution
{
    public static void Main()
    {
        string[] ops = ["MyQueue", "push", "push", "push", "push", "pop", "push", "pop", "pop", "pop", "pop"];
        int[][] vals = [[], [1], [2], [3], [4], [], [5], [], [], [], []];
        MyQueue obj = new MyQueue();
        for (int i = 0; i < ops.Length; i++)
        {
            var op = ops[i];
            var val = vals[i];
            switch (op)
            {
                case "MyQueue":
                    break;
                case "push":
                    obj.Push(val[0]);
                    break;
                case "pop":
                    Console.WriteLine(obj.Pop());
                    break;
                case "peek":
                    Console.WriteLine(obj.Peek());
                    break;
                case "empty":
                    Console.WriteLine(obj.Empty());
                    break;
            }
        }
    }
}