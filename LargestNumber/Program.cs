using System.Text;

string LargestNumber(int[] nums)
{
    QuickSort(nums, 0, nums.Length - 1);
    StringBuilder sb = new();
    foreach (int num in nums)
    {
        sb.Append(num);
    }
    return sb[0] == '0' ? "0" : sb.ToString();
}

void QuickSort(int[] nums, int left, int right)
{
    if (left > right) return;
    int pivotIdx = Partition(nums, left, right);
    QuickSort(nums, left, pivotIdx - 1);
    QuickSort(nums, pivotIdx + 1, right);
}

int Partition(int[] nums, int left, int right)
{
    int pivot = nums[right];
    int lowIdx = left;
    for (int i = left; i < right; i++)
    {
        if (Compare(nums[i], pivot))
        {
            Swap(nums, i, lowIdx);
            lowIdx++;
        }
    }
    Swap(nums, lowIdx, right);
    return lowIdx;
}

bool Compare(int firstNum, int secondNum)
{
    string a = firstNum.ToString();
    string b = secondNum.ToString();
    return string.Compare(a + b, b + a) > 0;
}

void Swap(int[] nums, int i, int j)
{
    int temp = nums[i];
    nums[i] = nums[j];
    nums[j] = temp;
}

int[] nums = { 3, 30, 34, 5, 9 };

Console.WriteLine(LargestNumber(nums)); // Output: 9534330