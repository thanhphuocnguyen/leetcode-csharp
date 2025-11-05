public class AllOne
{
    private class Node
    {
        public Node Next;
        public Node Prev;
        public int Freq;
        public HashSet<string> Keys = new();
        public Node(int freq = 0)
        {
            Freq = freq;
        }
    }

    private Dictionary<string, Node> KeysMap;
    private Node Head = new Node();
    private Node Tail = new Node();

    public AllOne()
    {
        KeysMap = new();
        Head.Next = Tail;
        Tail.Prev = Head;
    }

    public void Inc(string key)
    {
        if (KeysMap.ContainsKey(key))
        {
            var currNode = KeysMap[key];
            currNode.Keys.Remove(key);
            var nextNode = currNode.Next;
            if (nextNode == Tail || nextNode.Freq != currNode.Freq + 1)
            {
                Node newNode = new Node(currNode.Freq + 1);
                newNode.Keys.Add(key);
                newNode.Next = nextNode;
                newNode.Prev = currNode;

                currNode.Next = newNode;
                nextNode.Prev = newNode;

                KeysMap[key] = newNode;
            }
            else
            {
                nextNode.Keys.Add(key);
                KeysMap[key] = nextNode;
            }
            if (currNode.Keys.Count == 0)
            {
                RemoveNode(currNode);
            }
        }
        else
        {
            var nextNode = Head.Next;
            if (nextNode == Tail || nextNode.Freq > 1)
            {
                Node newNode = new(1);
                newNode.Keys.Add(key);

                newNode.Prev = Head;
                newNode.Next = nextNode;

                nextNode.Prev = newNode;
                Head.Next = newNode;

                KeysMap[key] = newNode;
            }
            else
            {
                nextNode.Keys.Add(key);
                KeysMap[key] = nextNode;
            }
        }
    }

    public void Dec(string key)
    {
        if (!KeysMap.ContainsKey(key))
        {
            return;
        }
        var currNode = KeysMap[key];
        currNode.Keys.Remove(key);
        if (currNode.Freq == 1)
        {
            KeysMap.Remove(key);
        }
        else
        {
            var prevNode = currNode.Prev;
            if (prevNode == Head || prevNode.Freq != currNode.Freq - 1)
            {
                Node newNode = new Node(currNode.Freq - 1);
                newNode.Keys.Add(key);

                newNode.Next = currNode;
                newNode.Prev = prevNode;

                prevNode.Next = newNode;
                currNode.Prev = newNode;

                KeysMap[key] = newNode;
            }
            else
            {
                prevNode.Keys.Add(key);
                KeysMap[key] = prevNode;
            }
        }
        if (currNode.Keys.Count == 0)
        {
            RemoveNode(currNode);
        }
    }

    public string GetMaxKey()
    {
        if (Head == Tail.Prev)
        {
            return "";
        }
        return Tail.Prev.Keys.Last();
    }

    public string GetMinKey()
    {
        if (Head.Next == Tail)
        {
            return "";
        }
        return Head.Next.Keys.Last();
    }

    private void RemoveNode(Node node)
    {
        Node after = node.Next;
        Node before = node.Prev;
        before.Next = after;
        after.Prev = before;
    }

    public static void Main()
    {
        AllOne obj = new AllOne();
        obj.Inc("hello");
        obj.GetMaxKey();
        obj.GetMinKey();
    }
}

/**
 * Your AllOne object will be instantiated and called as such:
 * AllOne obj = new AllOne();
 * obj.Inc(key);
 * obj.Dec(key);
 * string param_3 = obj.GetMaxKey();
 * string param_4 = obj.GetMinKey();
 */