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
    public IList<TreeNode> AllPossibleFBT(int n)
    {
        if (n % 2 == 0)
        {
            return [];
        }
        Dictionary<int, IList<TreeNode>> memo = new();
        return Build(memo, n);
    }

    public IList<TreeNode> Build(Dictionary<int, IList<TreeNode>> memo, int n)
    {
        if (memo.ContainsKey(n))
        {
            return memo[n];
        }
        IList<TreeNode> res = new List<TreeNode>();
        if (n == 1)
        {
            res.Add(new TreeNode());
        }
        else
        {
            for (int i = 1; i < n - 1; i += 2)
            {
                IList<TreeNode> left = AllPossibleFBT(i);
                IList<TreeNode> right = AllPossibleFBT(n - i - 1);
                foreach (TreeNode l in left)
                {
                    foreach (TreeNode r in right)
                    {
                        TreeNode root = new(0, l, r);
                        res.Add(root);
                    }
                }
            }
        }

        memo[n] = res;
        return res;
    }

    public static void Main()
    {
        var sln = new Solution();
        sln.AllPossibleFBT(5);
    }
}