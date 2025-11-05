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
public class Solution
{
    public int AverageOfSubtree(TreeNode root)
    {
        int ans = 0
        Dfs(root, ref ans);
        return ans;
    }

    private (int, int) Dfs(TreeNode node, ref int ans)
    {
        if (node == null)
        {
            return (0, 0);
        }
        (int sumL, int cntL) = Dfs(node.left, ref ans);
        (int sumR, int cntR) = Dfs(node.right, ref ans);
        int sum = node.val + sumL + sumR;
        int cnt = 1 + cntL + cntR;
        if (node.val == sum / cnt)
        {
            ans++;
        }
        return (sum, cnt);
    }
}