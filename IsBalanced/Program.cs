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
    public bool IsBalanced(TreeNode root)
    {
        if (root == null)
        {
            return true;
        }

        int leftSideDepth = GetDepth(root.left);
        int rightSideDepth = GetDepth(root.right);
        return Math.Abs(leftSideDepth - rightSideDepth) <= 1;
    }

    private int GetDepth(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }
        return Math.Max(GetDepth(node.left), GetDepth(node.right)) + 1;
    }

    public static void Main(string[] args)
    {
        TreeNode root = new TreeNode(1);
        root.right = new TreeNode(2);
        root.right.right = new TreeNode(3);
        Solution solution = new Solution();
        Console.WriteLine(solution.IsBalanced(root));
    }
}