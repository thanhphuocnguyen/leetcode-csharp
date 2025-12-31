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
    public void Flatten(TreeNode root)
    {
        TreeNode prev = null;
        PreorderTraversal(root, ref prev);
    }
    private void PreorderTraversal(TreeNode root, ref TreeNode prev)
    {
        if (root == null)
        {
            return;
        }
        PreorderTraversal(root.right, ref prev);
        PreorderTraversal(root.left, ref prev);
        root.right = prev;
        root.left = null;
        prev = root;
    }
    public static void Main()
    {
        var sln = new Solution();
        var root = new TreeNode(
            val: 1,
            left: new(2, left: new(3), right: new(4)),
            right: new(5, left: null, right: new(6)));
        sln.Flatten(root);
    }
}