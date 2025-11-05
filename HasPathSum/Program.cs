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
    public bool HasPathSum(TreeNode root, int targetSum)
    {
        Queue<(TreeNode node, int currSum)> q = new();
        q.Enqueue((root, targetSum));
        while (q.Any())
        {
            int n = q.Count;
            for (int i = 0; i < n; i++)
            {
                var candidate = q.Dequeue();
                TreeNode node = candidate.node;
                int currSum = candidate.currSum;
                if (node.left == null && node.right == null && currSum == 0)
                {
                    return true;
                }
                if (node.left != null)
                {
                    q.Enqueue((node.left, currSum - node.left.val));
                }
                if (node.right != null)
                {
                    q.Enqueue((node.right, currSum - node.right.val));
                }
            }
        }

        return false;
    }
}