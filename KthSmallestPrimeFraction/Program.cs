public class Solution {
    public int[] KthSmallestPrimeFraction(int[] arr, int k) {
        PriorityQueue<int[],double> pq = new(Comparer<double>.Create((a,b) => b.CompareTo(a)));
        for(int i = 0; i < arr.Length; i++) {
            for(int j = i+1; j < arr.Length; j++) {
                pq.Enqueue([arr[i],arr[j]], (double)arr[i]/arr[j]);
                if(pq.Count > k) {
                    pq.Dequeue();
                }
            }
        }
        return pq.Peek();
    }

    public static void Main(string[] args) {
        Solution solution = new Solution();
        int[] arr = new int[]{1,2,3,5};
        int k = 3;
        int[] res = solution.KthSmallestPrimeFraction(arr, k);
        Console.WriteLine("", res);
    }
}