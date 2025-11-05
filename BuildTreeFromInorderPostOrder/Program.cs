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
    public TreeNode BuildTree(int[] inorder, int[] postorder)
    {
        int postorderIdx = postorder.Length - 1;
        return BuildRecursive(inorder, postorder, ref postorderIdx, 0, inorder.Length - 1);
    }

    private TreeNode BuildRecursive(int[] inorder, int[] postorder, ref int postorderIdx, int left, int right)
    {
        if (left > right)
        {
            return null;
        }
        int val = postorder[postorderIdx];
        TreeNode node = new(val);
        int inorderIdx = SearchIdx(inorder, val, left, right);
        postorderIdx--;
        node.right = BuildRecursive(inorder, postorder, ref postorderIdx, inorderIdx + 1, right);
        node.left = BuildRecursive(inorder, postorder, ref postorderIdx, left, inorderIdx - 1);
        return node;
    }

    private static int SearchIdx(int[] arr, int target, int left, int right)
    {
        for (int i = left; i <= right; i++)
        {
            if (target == arr[i])
            {
                return i;
            }
        }
        return -1;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] inorder = [9, 3, 15, 20, 7];
        int[] postorder = [9, 15, 7, 20, 3];
        TreeNode result = solution.BuildTree(inorder, postorder);
        Console.WriteLine(result.val);
    }

}