public class Solution
{
    public class Node
    {
        public int[] point;
        public Node left;
        public Node right;
        public Node(int[] point)
        {
            this.point = point;
        }
    }

    public class TwoDTree
    {
        private Node Insert(Node node, int[] point, int depth)
        {
            if (node == null)
            {
                return new Node(point);
            }
            int cd = depth % 2;
            if (point[cd] <= node.point[cd])
            {
                node.left = Insert(node.left, point, depth + 1);
            }
            else
            {
                node.right = Insert(node.right, point, depth + 1);
            }

            return node;
        }

        public Node Insert(Node node, int[] point)
        {
            return Insert(node, point, 0);
        }

        public int Distance(int[] p1, int[] p2)
        {
            int dx = p1[0] - p2[0], dy = p1[1] - p2[1];
            return dx * dx + dy * dy;
        }

        public int CountPointInCircle(Node node, int[] point, int rSquare, int depth)
        {
            if (node == null)
            {
                return 0;
            }
            int cnt = 0;

            // if (x1-x2)^2 + (y1-y2)^2 <= r^2 add 1 in result
            if (Distance(point, node.point) <= rSquare)
            {
                cnt++;
            }
            // find current axis in tree
            int cd = depth % 2;

            int diff = point[cd] - node.point[cd];

            // if current value at axis less than node value
            if (diff <= 0)
            {
                // find next at left tree
                cnt += CountPointInCircle(node.left, point, rSquare, depth + 1);
                if (diff * diff <= rSquare)
                {
                    // if square of diff less than radius square we can possibly find some point that match criteria on the right
                    cnt += CountPointInCircle(node.right, point, rSquare, depth + 1);
                }
            }
            else
            {
                // find next point at the right tree because current axis value larger than current node axis value
                cnt += CountPointInCircle(node.right, point, rSquare, depth + 1);
                if (diff * diff <= rSquare)
                {
                    // same as case less than
                    cnt += CountPointInCircle(node.left, point, rSquare, depth + 1);
                }
            }

            return cnt;
        }
    }
    public int[] CountPoints(int[][] points, int[][] queries)
    {
        Node root = null;
        var twoDimensionTree = new TwoDTree();
        foreach (int[] point in points)
        {
            root = twoDimensionTree.Insert(root, point);
        }

        int[] ans = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            int rSquare = queries[i][2] * queries[i][2];
            ans[i] = twoDimensionTree.CountPointInCircle(root, [queries[i][0], queries[i][1]], rSquare, 0);
        }
        return ans;
    }

    public static void Main()
    {
        var sln = new Solution();
        sln.CountPoints([[1, 3], [3, 3], [5, 3], [2, 2]], [[2, 3, 1], [4, 3, 1], [1, 1, 2]]);
    }
}

