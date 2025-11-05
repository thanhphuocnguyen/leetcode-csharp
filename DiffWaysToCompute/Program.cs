IList<int> DiffWaysToCompute(string expression)
{
    return Compute(expression, new Dictionary<string, List<int>>());
}

bool IsMathOperator(char c)
{
    return c == '+' || c == '-' || c == '*';
}

List<int> Compute(string expr, Dictionary<string, List<int>> memo)
{
    if (memo.ContainsKey(expr)) return memo[expr];
    List<int> ans = new();
    for (int i = 0; i < expr.Length; i++)
    {
        if (IsMathOperator(expr[i]))
        {
            List<int> leftExprSideComputed = Compute(expr.Substring(0, i), memo);
            List<int> righExprSideComputed = Compute(expr.Substring(i + 1), memo);
            ans.AddRange(CombineResult(leftExprSideComputed, righExprSideComputed, expr[i]));
        }
    }
    if (ans.Count == 0) ans.Add(int.Parse(expr));
    memo[expr] = ans;
    return memo[expr];
}

List<int> CombineResult(List<int> leftResults, List<int> rightResults, char currOp)
{
    List<int> combinedResults = new();
    foreach (int left in leftResults)
    {
        foreach (int right in rightResults)
        {
            if (currOp == '+')
            {
                combinedResults.Add(left + right);
            }
            if (currOp == '-')
            {
                combinedResults.Add(left - right);
            }
            if (currOp == '*')
            {
                combinedResults.Add(left * right);
            }
        }
    }
    return combinedResults;
}

Console.WriteLine(DiffWaysToCompute("2-1-1")); // [0, 2]