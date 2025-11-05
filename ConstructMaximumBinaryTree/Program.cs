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
    public TreeNode ConstructMaximumBinaryTree(int[] nums)
    {
        return BuildRoot(nums, 0, nums.Length);
    }

    private TreeNode BuildRoot(int[] nums, int start, int end)
    {
        if (start >= end)
        {
            return null;
        }
        int max = nums[start], idx = start;
        for (int i = start + 1; i < end; i++)
        {
            if (nums[i] > max)
            {
                max = nums[i];
                idx = i;
            }
        }
        var root = new TreeNode(max);
        root.left = BuildRoot(nums, start, idx);
        root.right = BuildRoot(nums, idx + 1, end);
        return root;
    }

    public static void Main()
    {
        var sln = new Solution();
        Console.WriteLine(sln.ConstructMaximumBinaryTree([3, 2, 1, 6, 0, 5]));
    }
}