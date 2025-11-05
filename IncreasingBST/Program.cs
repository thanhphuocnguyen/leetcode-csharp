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
    public TreeNode IncreasingBST(TreeNode root)
    {
        return DFS(root, null);
    }
    private TreeNode DFS(TreeNode root, TreeNode tail)
    {
        if (root == null)
        {
            return tail;
        }
        var res = DFS(root.left, root);
        root.left = null;
        root.right = DFS(root.right, tail);
        return res;
    }

    public static void Main()
    {
        var sln = new Solution();

        TreeNode root = new(5, new(3, new(2, new(1)), new(4)), new(6, null, new(8, new(7), new(9))));
        sln.IncreasingBST(root);
    }
}