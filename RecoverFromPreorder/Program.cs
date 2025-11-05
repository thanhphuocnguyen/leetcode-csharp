/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
public class Solution
{
    public TreeNode RecoverFromPreorder(string traversal)
    {
        Stack<TreeNode> nodes = new();
        int i = 0, n = traversal.Length;
        while (i < n)
        {
            int depth = 0;
            while (i < n && traversal[i] == '-')
            {
                depth++;
                i++;
            }
            int val = 0;
            while (i < n && traversal[i] != '-')
            {
                val = val * 10 + (traversal[i] - '0');
                i++;
            }
            while (depth != nodes.Count)
            {
                nodes.Pop();
            }
            TreeNode node = new(val);
            if (nodes.Count > 0)
            {
                if (nodes.Peek().left == null)
                {
                    nodes.Peek().left = node;
                }
                else
                {
                    nodes.Peek().right = node;
                }
            }
            nodes.Push(node);
        }
        if (nodes.Count > 1)
        {
            nodes.Pop();
        }
        return nodes.Peek();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Solution solution = new();
        TreeNode root = solution.RecoverFromPreorder("1-2--3--4-5--6--7");
        Console.WriteLine(root.val);
    }
}