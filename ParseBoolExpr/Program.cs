public class Solution
{
    public bool ParseBoolExpr(string expression)
    {
        Stack<char> exprStack = new();
        foreach (char el in expression)
        {
            if(el == ',') continue;
            if (el != ')')
            {
                exprStack.Push(el);
            }
            else
            {
                List<char> subExpr = new();
                while (exprStack.Peek() != '(')
                {
                    subExpr.Add(exprStack.Pop());
                }
                exprStack.Pop();// remove '('
                char op = exprStack.Pop();
                exprStack.Push(Parse(subExpr, op));
            }
        }

        return exprStack.Pop() == 't';
    }

    private char Parse(List<char> subExpr, char op)
    {
        return op switch
        {
            '|' => ParseOr(subExpr),
            '&' => ParseAnd(subExpr),
            '!' => ParseNot(subExpr[0]),
            _ => throw new ArgumentOutOfRangeException(nameof(op), $"Not expected operator value: {op}"),
        };
    }


    private char ParseOr(List<char> expression)
    {
        foreach (char b in expression)
        {
            if (b == 't') return 't';
        }
        return 'f';
    }

    private char ParseAnd(List<char> expression)
    {
        foreach (char b in expression)
        {
            if (b == 'f') return 'f';
        }
        return 't';
    }

    private char ParseNot(char currentBool)
    {
        return currentBool == 'f' ? 't' : 'f';
    }

    public static void Main()
    {
        Solution s = new();
        Console.WriteLine(s.ParseBoolExpr("!(f)")); // t
        Console.WriteLine(s.ParseBoolExpr("|(f,t)")); // t
        Console.WriteLine(s.ParseBoolExpr("&(t,f)")); // f
        Console.WriteLine(s.ParseBoolExpr("|(&(t,f,t),!(t))")); // f
    }
}