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
    public TreeNode ReverseOddLevels(TreeNode root)
    {
        Queue<TreeNode> q = new();
        q.Enqueue(root);
        int currLevel = 0;
        while (q.Any())
        {
            int n = q.Count;
            TreeNode[] listNode = new TreeNode[n];
            for (int i = 0; i < n; i++)
            {
                listNode[i] = q.Dequeue();
                if (listNode[i].left != null)
                    q.Enqueue(listNode[i].left);
                if (listNode[i].right != null)
                    q.Enqueue(listNode[i].right);
            }
            if (currLevel % 2 != 0)
            {
                for (int i = 0; i < n / 2; i++)
                {
                    var temp = listNode[i].val;
                    listNode[i].val = listNode[i + n / 2].val;
                    listNode[i + n / 2].val = temp;
                }
            }
            currLevel++;
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
        //[0,1,2,0,0,0,0,1,1,1,1,2,2,2,2]
        TreeNode root = new TreeNode(0);
        root.left = new TreeNode(1);
        root.right = new TreeNode(2);
        root.left.val = 1;
        root.right.val = 2;
        root.left.left = new TreeNode(0);
        root.left.right = new TreeNode(0);
        root.right.left = new TreeNode(0);
        root.right.right = new TreeNode(0);
        root.left.left.left = new TreeNode(1);
        root.left.left.right = new TreeNode(1);
        root.left.right.left = new TreeNode(1);
        root.left.right.right = new TreeNode(1);
        Solution sol = new Solution();
        sol.PrintTree(root);
        sol.ReverseOddLevels(root);
        sol.PrintTree(root);
    }
}