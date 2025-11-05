public class BrowserHistory
{
    Stack<string> backward;
    Stack<string> forward;
    string currPage;
    public BrowserHistory(string homepage)
    {
        currPage = homepage;
        backward = new();
        forward = new();
    }

    public void Visit(string url)
    {
        backward.Push(currPage);
        if (forward.Count > 0)
        {
            forward.Clear();
        }
        currPage = url;
    }

    public string Back(int steps)
    {
        int n = backward.Count;
        for (int i = 0; i < Math.Min(steps, n); i++)
        {
            forward.Push(currPage);
            currPage = backward.Peek();
            backward.Pop();
        }

        return currPage;
    }

    public string Forward(int steps)
    {
        int n = forward.Count;
        for (int i = 0; i < Math.Min(steps, n); i++)
        {
            backward.Push(currPage);
            currPage = forward.Peek();
            forward.Pop();
        }

        return currPage;
    }
}

/**
 * Your BrowserHistory object will be instantiated and called as such:
 * BrowserHistory obj = new BrowserHistory(homepage);
 * obj.Visit(url);
 * string param_2 = obj.Back(steps);
 * string param_3 = obj.Forward(steps);
 */