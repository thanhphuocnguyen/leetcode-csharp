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
    public TreeNode BstFromPreorder(int[] preorder)
    {
        Stack<TreeNode> st = new();
        TreeNode root = new(preorder[0]);
        st.Push(root);
        for (int i = 1; i < preorder.Length && st.Count > 0; i++)
        {
            int val = preorder[i];
            TreeNode newNode = new(val);

            if (val < st.Peek().val)
            {
                st.Peek().left = newNode;
            }
            else
            {
                TreeNode curr = st.Peek();
                while (st.Count > 0 && val > st.Peek().val)
                {
                    curr = st.Pop();
                }
                curr.right = newNode;
            }
            st.Push(newNode);
        }
        return root;
    }

    public static void Main()
    {
        var sln = new Solution();
        sln.BstFromPreorder([8, 5, 1, 7, 10, 12]);
    }
}