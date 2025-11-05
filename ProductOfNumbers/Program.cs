public class ProductOfNumbers
{
    private List<int> prefixSum { get; init; }
    public ProductOfNumbers()
    {
        prefixSum = [1];
    }

    public void Add(int num)
    {
        if (num == 0)
        {
            prefixSum.Clear();
            prefixSum.Add(1);
        }
        else
        {
            prefixSum.Add(prefixSum[prefixSum.Count - 1] * num);
        }
    }

    public int GetProduct(int k)
    {
        if (k > prefixSum.Count - 1)
        {
            return 0;
        }
        return prefixSum[prefixSum.Count - 1] / prefixSum[prefixSum.Count - 1 - k];
    }
}

public class Program
{
    public static void Main()
    {
        ProductOfNumbers obj = new ProductOfNumbers();
        obj.Add(3);
        obj.Add(0);
        obj.Add(2);
        obj.Add(5);
        obj.Add(4);
        Console.WriteLine(obj.GetProduct(2));
        Console.WriteLine(obj.GetProduct(3));
        Console.WriteLine(obj.GetProduct(4));
        obj.Add(8);
        Console.WriteLine(obj.GetProduct(2));
    }
}

/**
 * Your ProductOfNumbers object will be instantiated and called as such:
 * ProductOfNumbers obj = new ProductOfNumbers();
 * obj.Add(num);
 * int param_2 = obj.GetProduct(k);
 */