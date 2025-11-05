// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

void FractionAddition(string expression)
{
    Stack<int> numerators = new();
    Stack<int> denominator = new();
    int n = expression.Length;
    int i = 0;
    while (i < expression.Length)
    {
        int sign = 1;
        if (expression[i] == '-')
        {
            sign = -1;
            i++;
        }
        else if (expression[i] == '+')
        {
            i++;
        }
        int j = i;
        int num = 0;
        int power = 0;
        while (j < n && expression[j] != '/')
        {
            num = (int)Math.Pow(10.0, power) * num + expression[j] - '0';
            power++;
            j++;
        }
        numerators.Push(sign * num);
        i = j + 1;
        j = i;
        num = 0;
        power = 0;
        while (j < n && expression[j] != '+' && expression[j] != '-')
        {
            num = (int)Math.Pow(10.0, power) * num + expression[j] - '0';
            power++;
            j++;
        }
        denominator.Push(num);
        i = j;
    }

    int lcm = 1;
}


FractionAddition("-1/2+1/2+1/3");