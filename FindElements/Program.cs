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
public class FindElements
{
    private HashSet<int> nodeValues { get; init; }
    public FindElements(TreeNode root)
    {
        // Init nodeValues
        nodeValues = new();
        // Recover root by DFS
        root.val = 0;
        Recover(root);

    }

    public bool Find(int target)
    {
        // return target if contains in hashset
        return nodeValues.Contains(target);
    }

    private void Recover(TreeNode root)
    {
        if (root == null)
        {
            return;
        }
        if (root.left != null)
        {
            root.left.val = root.val * 2 + 1;
            nodeValues.Add(root.left.val);
            Recover(root.left);
        }
        if (root.right != null)
        {
            root.right.val = root.val * 2 + 2;
            nodeValues.Add(root.right.val);
            Recover(root.right);
        }
    }
}

public class Solution
{
    public static void Main(string[] args)
    {
        TreeNode root = new(0, new(-1, null, new(-1)), null);
        FindElements findElements = new(root);
        Console.WriteLine(findElements.Find(1));
        Console.WriteLine(findElements.Find(2));
    }
}
/**
 * Your FindElements object will be instantiated and called as such:
 * FindElements obj = new FindElements(root);
 * bool param_1 = obj.Find(target);
 */