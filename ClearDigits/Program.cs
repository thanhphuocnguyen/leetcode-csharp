namespace ClearDigits;

class Program
{
    static void Main(string[] args)
    {
        var sln = new Solution();
        sln.ClearDigits("cb34");
    }
}
public class Solution {
    public string ClearDigits(string s) {
        Stack<char> clearedDigits = new();
        foreach(char c in s) {
            if(c >= '0' && c <= '9' && clearedDigits.Count > 0 && clearedDigits.Peek() >= 'a' && clearedDigits.Peek()<='z') {
                clearedDigits.Pop();
            } else {
                clearedDigits.Push(c);
            }
        }
        string ans = "";
        foreach (var c in clearedDigits.Reverse())
        {
            ans += c;
        }

        return ans;
    }
}