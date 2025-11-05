namespace LargestIsland;

public class DisjointSetUnion {
        private int[] Parent { get; init; }
        private int[] Size { get; init; }
        public DisjointSetUnion(int n) {
            Parent = new int[n];
            Size = new int[n];
            for(int i = 0; i < n; i++) {
                Parent[i] = i;
                Size[i] = 0;
            }
        }

        public int Find(int i) {
            if(Parent[i] != i) {
                Parent[i] = Find(Parent[i]);
            }
            return Parent[i];
        }

        public bool Union(int u, int v) {
            int pu = Find(u);
            int pv = Find(v);
            if(pu == pv) {
                return false;
            }
            int su = Size[pu];
            int sv = Size[pv];
            if(su < sv) {
                Parent[pu] = pv;
                Size[pv] += su;
            } else {
                Parent[pv] = pu;
                Size[pu] += sv;
            }
            return true;
        }

        public int GetSize(int node) {
            return Size[node];
        }
    }
public class Solution {
    private static readonly int[] RowDirs = [0,0,-1,1];
    private static readonly int[] ColDirs = [-1,1,0,0];
    public int LargestIsland(int[][] grid) {
        int n = grid.Length;
        var dsu = new DisjointSetUnion(n*n);
        for(int i = 0; i < n; i++) {
            for(int j = 0; j < n; j++) {
                if(grid[i][j] == 1) {
                    int currNode = (i*n)+j;
                    for(int dir = 0; dir < 4; dir++) {
                        int nextRow = RowDirs[dir];
                        int nextCol = ColDirs[dir];
                        if(IsValidCell(nextRow, nextCol, n) && grid[nextRow][nextCol] == 1) {
                            int neiNode = (n*nextRow)+nextCol;
                            dsu.Union(currNode,neiNode);
                        }
                    }
                }
            }
        }
        int maxIslandSize = 0;
        bool hasZero = false;
        HashSet<int> uniqParents = new();
        for(int row = 0; row < n; row++) {
            for(int col = 0; col < n; col++) {
                if(grid[row][col] == 0) {
                    hasZero = true;
                    int currentIslandSize = 0;
                    for(int dir = 0; dir < 4; dir++) {
                        int neiRow = row + RowDirs[dir];
                        int neiCol = col + ColDirs[dir];
                        if(IsValidCell(neiRow, neiCol, n) && grid[neiRow][neiCol] == 1) {
                            int neiNode = n * neiRow + neiCol;
                            int root = dsu.Find(neiNode);
                            uniqParents.Add(root);
                        }
                    }

                    foreach(int parent in uniqParents) {
                        currentIslandSize+=dsu.GetSize(parent);
                    }
                    uniqParents.Clear();
                    maxIslandSize = Math.Max(maxIslandSize, currentIslandSize);
                }
            }
        }
        if(!hasZero) return n*n;
        return maxIslandSize;
    }

    private static bool IsValidCell(int row, int col, int n) {
        return row >= 0 && col >= 0 && row < n && col < n;
    }
}