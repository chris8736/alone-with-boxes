using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

/* A C# program to evaluate a given expression where tokens are separated   
   by space.  
   Test Cases:  
     "10 + 2 * 6"            ---> 22  
     "100 * 2 + 12"          ---> 212  
     "100 * ( 2 + 12 )"      ---> 1400  
     "100 * ( 2 + 12 ) / 14" ---> 100      
*/

public class EvaluateString
{
    public static int Evaluate(string expression, Hashtable references)
    {
        // Stack for numbers: 'values'  
        Stack<int> values = new Stack<int>();

        // Stack for Operators: 'ops'  
        Stack<char> ops = new Stack<char>();

        for (int i = 0; i < expression.Length; i++)
        {
            // Current token is a whitespace, skip it  
            if (expression[i] == ' ')
            {
                continue;
            }

            // Current token is a number, push it to stack for numbers  
            if (Char.IsDigit(expression[i]))
            {
                StringBuilder sbuf = new StringBuilder();
                // There may be more than one digits in number  
                while (i < expression.Length && Char.IsDigit(expression[i]))
                {
                    sbuf.Append(expression[i++]);
                }
                values.Push(int.Parse(sbuf.ToString()));
                i -= 1;
            }

            // Current token is a letter, get the variable name, access, and push to stack
            if (Char.IsLetter(expression[i]))
            {
                StringBuilder sbuf = new StringBuilder();
                // There may be more than one digits in number  
                while (i < expression.Length && ((Char.IsLetterOrDigit(expression[i])) || expression[i] == '_'))
                {
                    sbuf.Append(expression[i++]);
                }
                if (references.Contains(sbuf.ToString()))
                {
                    GameObject reference = (GameObject)references[sbuf.ToString()];
                    reference.GetComponent<Animator>().SetTrigger("Referenced");
                    values.Push(((GameObject)references[sbuf.ToString()]).transform.Find("Canvas").transform.Find("Out").GetComponent<VariableEject>().data);
                }
                else
                {
                    throw new System.NotSupportedException("Not declared.");
                }
                i -= 1;
            }

            // Current token is an opening brace, push it to 'ops'  
            else if (expression[i] == '(')
            {
                ops.Push(expression[i]);
            }

            // Closing brace encountered, solve entire brace  
            else if (expression[i] == ')')
            {
                while (ops.Peek() != '(')
                {
                    values.Push(ApplyOp(ops.Pop(), values.Pop(), values.Pop()));
                }
                ops.Pop();
            }

            // Current token is an operator.  
            else if (expression[i] == '+' || expression[i] == '-' || expression[i] == '*' || expression[i] == '/')
            {
                // While top of 'ops' has same or greater precedence to current  
                // token, which is an operator. Apply operator on top of 'ops'  
                // to top two elements in values stack  
                while (ops.Count > 0 && HasPrecedence(expression[i], ops.Peek()))
                {
                    values.Push(ApplyOp(ops.Pop(), values.Pop(), values.Pop()));
                }

                // Push current token to 'ops'.  
                ops.Push(expression[i]);
            }
        }

        // Entire expression has been parsed at this point, apply remaining  
        // ops to remaining values  
        while (ops.Count > 0)
        {
            values.Push(ApplyOp(ops.Pop(), values.Pop(), values.Pop()));
        }

        // Top of 'values' contains result, return it  
        return values.Pop();
    }

    // Returns true if 'op2' has higher or same precedence as 'op1',  
    // otherwise returns false.  
    public static bool HasPrecedence(char op1, char op2)
    {
        if (op2 == '(' || op2 == ')')
        {
            return false;
        }
        if ((op1 == '*' || op1 == '/') && (op2 == '+' || op2 == '-'))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    // A utility method to apply an operator 'op' on operands 'a'   
    // and 'b'. Return the result.  
    public static int ApplyOp(char op, int b, int a)
    {
        switch (op)
        {
            case '+':
                return a + b;
            case '-':
                return a - b;
            case '*':
                return a * b;
            case '/':
                if (b == 0)
                {
                    throw new System.NotSupportedException("Cannot divide by zero");
                }
                return a / b;
        }
        return 0;
    }
}

// This code is contributed by Shrikant13 

