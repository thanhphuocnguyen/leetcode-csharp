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
    public int SumEvenGrandparent(TreeNode root)
    {
        TreeNode grandParent = null;
        TreeNode parent = null;
        int ans = 0;
        Dfs(root, grandParent, parent, ref ans);
        return ans;
    }

    private void Dfs(TreeNode node, TreeNode grandParent, TreeNode parent, ref int ans)
    {
        if (node == null)
        {
            return;
        }
        if (grandParent != null && grandParent.val % 2 == 0)
        {
            ans += node.val;
        }
        grandParent = parent;
        parent = node;
        Dfs(node.left, grandParent, parent, ref ans);
        Dfs(node.right, grandParent, parent, ref ans);
    }

    public static void Main()
    {
        var sln = new Solution();
        TreeNode root = new(6, new(7, new(2, new(9)), new(7, new(1), new(4))), new(8, new(1), new(3, null, new(5))));
        Console.WriteLine(sln.SumEvenGrandparent(root));
    }
}