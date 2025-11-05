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
    public int RangeSumBST(TreeNode root, int low, int high)
    {
        int ans = 0;
        Dfs(root, low, high, ref ans);
        return ans;
    }

    private void Dfs(TreeNode node, int low, int high, ref int ans)
    {
        if (node == null)
        {
            return;
        }
        if (node.val >= low && node.val <= high)
        {
            ans += node.val;
        }
        if (node.val > high)
        {
            Dfs(node.left, low, high, ref ans);
        }
        else if (node.val < low)
        {
            Dfs(node.right, low, high, ref ans);
        }
        else
        {
            Dfs(node.left, low, high, ref ans);
            Dfs(node.right, low, high, ref ans);
        }
    }

    public static void Main()
    {
        var sln = new Solution();
        var root = new TreeNode(10, left: new(5, left: new(3), right: new(7)), right: new(15, right: new(18)));
        Console.WriteLine(sln.RangeSumBST(root, 7, 15));
    }
}