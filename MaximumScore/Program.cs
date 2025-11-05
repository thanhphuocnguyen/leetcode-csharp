public class Solution
{
    private const int MOD = 1_000_000_007;
    public int MaximumScore(IList<int> nums, int k)
    {
        int n = nums.Count;
        List<int> primeScores = [.. new int[n]];
        for (int index = 0; index < n; index++)
        {
            int num = nums[index];
            for (int factor = 2; factor <= Math.Sqrt(num); factor++)
            {
                if (num % factor == 0)
                {
                    primeScores[index]++;
                    while (num % factor == 0)
                    {
                        num /= factor;
                    }
                }
            }
            if (num > 1)
            {
                primeScores[index]++;
            }
        }

        int[] nextDominant = new int[n];
        int[] prevDominant = new int[n];
        Array.Fill(nextDominant, n);
        Array.Fill(prevDominant, -1);

        Stack<int> descPrimeScoreSt = new();

        for (int i = 0; i < n; i++)
        {
            while (descPrimeScoreSt.Count > 0 && primeScores[descPrimeScoreSt.Peek()] < primeScores[i])
            {
                int topIdx = descPrimeScoreSt.Pop();
                nextDominant[topIdx] = i;
            }

            if (descPrimeScoreSt.Count > 0)
            {
                prevDominant[i] = descPrimeScoreSt.Peek();
            }

            descPrimeScoreSt.Push(i);
        }

        long[] numOfSubArrays = new long[n];
        for (int i = 0; i < n; i++)
        {
            numOfSubArrays[i] = ((long)nextDominant[i] - i) * (i - prevDominant[i]);
        }

        PriorityQueue<int[], int[]> pq = new(Comparer<int[]>.Create((a, b) =>
        {
            if (a[0] == b[0])
            {
                return a[1] - b[1];
            }
            else
            {
                return b[0] - a[0];
            }
        }));

        for (int i = 0; i < n; i++)
        {
            pq.Enqueue([nums[i], i], [nums[i], i]);
        }

        long score = 1;
        while (k > 0)
        {
            int[] top = pq.Dequeue();
            int num = top[0];
            int idx = top[1];
            long ops = Math.Min(k, numOfSubArrays[idx]);
            score = score * Power(num, ops) % MOD;
            k -= (int)ops;
        }
        return (int)score;
    }

    private long Power(long bs, long exp)
    {
        long res = 1;
        while (exp > 0)
        {
            if (exp % 2 == 1)
            {
                res = (res * bs) % MOD;
            }
            bs = bs * bs % MOD;
            exp /= 2;
        }
        return res;
    }

    public static void Main(string[] args)
    {
        var sln = new Solution();
        Console.WriteLine(sln.MaximumScore([19, 12, 14, 6, 10, 18], 3));
    }
}