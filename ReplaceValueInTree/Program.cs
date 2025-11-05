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
    public TreeNode ReplaceValueInTree(TreeNode root)
    {
        List<int> sumsByLevel = new();
        Queue<TreeNode> q = new();
        q.Enqueue(root);
        while (q.Any())
        {
            int n = q.Count;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                TreeNode node = q.Dequeue();
                sum += node.val;
                if (node.left != null)
                {
                    q.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    q.Enqueue(node.right);
                }
            }
            sumsByLevel.Add(sum);
        }
        root.val = 0;
        q.Enqueue(root);
        int level = 1; // skip root
        while (q.Any())
        {
            int n = q.Count;
            while (n-- > 0)
            {
                TreeNode node = q.Dequeue();
                if (node.left != null && node.right != null)
                {
                    int cousinSum = sumsByLevel[level] - (node.left.val + node.right.val);
                    node.left.val = cousinSum;
                    node.right.val = cousinSum;
                    q.Enqueue(node.left);
                    q.Enqueue(node.right);
                }
                else if (node.left != null)
                {
                    node.left.val = sumsByLevel[level] - node.left.val;
                    q.Enqueue(node.left);
                }
                else if (node.right != null)
                {
                    node.right.val = sumsByLevel[level] - node.right.val;
                    q.Enqueue(node.right);
                }
            }
            level++;
        }
        return root;
    }


    public void PrintTree(TreeNode root)
    {
        if (root == null)
        {
            return;
        }
        Console.WriteLine(root.val);
        PrintTree(root.left);
        PrintTree(root.right);
    }

    public static void Main(string[] args)
    {
        TreeNode root = new TreeNode(5);
        root.left = new TreeNode(4);
        root.right = new TreeNode(9);
        root.left.left = new TreeNode(1);
        root.left.right = new TreeNode(10);
        root.right.right = new TreeNode(7);
        Solution sol = new Solution();
        sol.ReplaceValueInTree(root);
        sol.PrintTree(root);
    }
}