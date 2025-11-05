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
    public TreeNode LcaDeepestLeaves(TreeNode root)
    {
        int maxDepth = MaxDepth(root, 1);
        return DFS(root, maxDepth, 1);
    }

    private int MaxDepth(TreeNode root, int depth)
    {
        int leftDepth = depth;
        int rightDepth = depth;
        if (root.left != null)
        {
            leftDepth = MaxDepth(root.left, depth + 1);
        }
        if (root.right != null)
        {
            rightDepth = MaxDepth(root.right, depth + 1);
        }
        return Math.Max(leftDepth, rightDepth);
    }

    private TreeNode DFS(TreeNode root, int maxDepth, int currentDepth)
    {
        if (root == null)
        {
            return null;
        }
        if (maxDepth - 1 == currentDepth)
        {
            return root;
        }
        TreeNode left = DFS(root.left, maxDepth, currentDepth + 1);
        TreeNode right = DFS(root.right, maxDepth, currentDepth + 1);
        if (left != null && right != null)
        {
            return root;
        }
        return left != null ? left : right;
    }

    public static void Main(string[] args)
    {
        var sln = new Solution();
        // 3,5,1,6,2,0,8,null,null,7,4
        var root = new TreeNode(3,
            new TreeNode(5,
                new TreeNode(6),
                new TreeNode(2,
                    new TreeNode(7),
                    new TreeNode(4))),
            new TreeNode(1,
                new TreeNode(0),
                new TreeNode(8)));
        Console.WriteLine(sln.LcaDeepestLeaves(root));
    }
}