public class MyCalendarTwo
{
    SortedDictionary<int, int> bookingsOverlap;
    int maxOverlaps;
    public MyCalendarTwo()
    {
        bookingsOverlap = new();
        maxOverlaps = 2;
    }

    public bool Book(int start, int end)
    {
        if (bookingsOverlap.ContainsKey(start))
        {
            bookingsOverlap[start]++;
        }
        else
        {
            bookingsOverlap.Add(start, 1);
        }
        if (bookingsOverlap.ContainsKey(end))
        {
            bookingsOverlap[end]--;
        }
        else
        {
            bookingsOverlap.Add(end, -1);
        }

        int count = 0;

        foreach (KeyValuePair<int, int> booking in bookingsOverlap)
        {
            count += booking.Value;
            if (count > maxOverlaps)
            {
                bookingsOverlap[start]--;
                bookingsOverlap[end]++;
                return false;
            }
        }
        return true;
    }

    public static void Main()
    {
        MyCalendarTwo obj = new();
        Console.WriteLine(obj.Book(10, 20));
        Console.WriteLine(obj.Book(50, 60));
        Console.WriteLine(obj.Book(10, 40));
        Console.WriteLine(obj.Book(5, 15));
        Console.WriteLine(obj.Book(5, 10));
        Console.WriteLine(obj.Book(25, 55));
    }
}

/**
 * Your MyCalendarTwo object will be instantiated and called as such:
 * MyCalendarTwo obj = new MyCalendarTwo();
 * bool param_1 = obj.Book(start,end);
 */