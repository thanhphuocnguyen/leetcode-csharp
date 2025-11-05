/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val,IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/
public class Node
{
    public int val;
    public IList<Node> children;

    public Node() { }

    public Node(int _val)
    {
        val = _val;
    }

    public Node(int _val, IList<Node> _children)
    {
        val = _val;
        children = _children;
    }
}

public class Solution
{
    // iterative way
    public IList<int> Preorder(Node root)
    {
        Stack<Node> st = new();
        IList<int> ans = new List<int>();
        Node curr = root;

        while (curr != null)
        {
            ans.Add(curr.val);
            for (int i = curr.children.Count - 1; i >= 0; i--)
            {
                st.Push(curr.children[i]);
            }
            curr = st.TryPop(out Node node) ? node : null;
        }

        return ans;
    }

    public static void Main()
    {
        Node root = new Node(
            _val: 1,

            _children: [
                new Node(_val:3, [
                    new Node(_val:5,[]),
                    new Node(_val:6,[]),
                ]),
                new Node(_val:2, []),
                new Node(_val:4, []),
            ]
        );
        var sln = new Solution();
        sln.Preorder(root);
    }
}