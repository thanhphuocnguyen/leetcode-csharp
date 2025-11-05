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
    public int MinimumOperations(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }
        Queue<TreeNode> q = new();
        q.Enqueue(root);
        int ans = 0;
        while (q.Any())
        {
            int size = q.Count;
            int[] values = new int[size];
            for (int i = 0; i < size; i++)
            {
                TreeNode node = q.Dequeue();
                values[i] = node.val;
                if (node.left != null)
                {
                    q.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    q.Enqueue(node.right);
                }
            }

            ans += GetMinSwap(values);
        }
        return ans;
    }
    private int GetMinSwap(int[] arr)
    {
        int swap = 0;
        int[] sortedArr = new int[arr.Length];
        arr.CopyTo(sortedArr, 0);
        Array.Sort(sortedArr);
        Dictionary<int, int> posMap = new();
        for (int i = 0; i < arr.Length; i++)
        {
            posMap[arr[i]] = i;
        }
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != sortedArr[i])
            {
                swap++;
                int currPos = posMap[sortedArr[i]];
                posMap[arr[i]] = currPos;
                arr[currPos] = arr[i];
            }
        }
        return swap;
    }
}