public class FenwickTree
{
    private int[] tree;
    public FenwickTree(int size)
    {
        tree = new int[size + 1];
    }

    public void Update(int index, int delta)
    {
        index++;
        while (index < tree.Length)
        {
            tree[index] += delta;
            index += index & -index;
        }
    }

    public int Query(int index)
    {
        index++;
        int res = 0;
        while (index > 0)
        {
            res += tree[index];
            index -= index & -index;
        }
        return res;
    }
}
public class Solution
{
    public long GoodTriplets(int[] nums1, int[] nums2)
    {
        int n = nums1.Length;
        int[] pos2 = new int[n], reversedIndexMapping = new int[n];
        for (int i = 0; i < n; i++)
        {
            pos2[nums2[i]] = i;
        }
        for (int i = 0; i < n; i++)
        {
            reversedIndexMapping[pos2[nums1[i]]] = i;
        }
        var tree = new FenwickTree(n);
        long ans = 0;
        for (int value = 0; value < n; value++)
        {
            int pos = reversedIndexMapping[value];
            int left = tree.Query(pos);
            tree.Update(pos, 1);
            int right = (n - 1 - pos) - (value - left);
            ans += (long)left * right;
        }
        return ans;
    }

    public static void Main(string[] args)
    {
        var sln = new Solution();
        Console.WriteLine(sln.GoodTriplets([4, 0, 1, 3, 2], [4, 1, 0, 2, 3]));
    }
}