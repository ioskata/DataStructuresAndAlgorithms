namespace Task03CalculateArithmeticExpression
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Task03CalculateArithmeticExpressionClass
    {
        static void Main()
        {
            string expr = string.Empty;
            Console.WriteLine("To break insert \"end\"");

            while (expr != "end")
            {
                Console.Write("Insert the expression in infix notation: ");
                expr = Console.ReadLine().Replace(" ", "");

                try
                {
                    Console.WriteLine("The result is {0:F3}", CalculatePostfixExpression(ConvertToRPN(expr)));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static ushort Precedence(string operatorStr)
        {
            ushort precedence;
            switch (operatorStr)
            {
                case "+":
                case "-":
                    precedence = 2;
                    break;
                case "*":
                case "/":
                    precedence = 1;
                    break;
                default:
                    precedence = 0;
                    break;
            }

            return precedence;
        }

        private static bool IsNumber(string str)
        {
            double dbl;
            return double.TryParse(str, out dbl);
        }

        private static Queue<string> ConvertToRPN(string expr)
        {
            List<string> operators = new List<string> { "*", "/", "+", "-" };
            List<string> functions = new List<string> { "ln", "sqrt", "pow" };
            List<string> brackets = new List<string> { "(", ")" };
            List<string> separator = new List<string> { "," };

            Queue<string> outputQueue = new Queue<string>();
            Stack<string> operatorStack = new Stack<string>();

            string concatenation = null;

            // while there are tokens to be read
            for (int pos = 0; pos < expr.Length; pos++)
            {
                // read a token
                string token = concatenation + expr[pos].ToString();

                // token is number
                // Unary minus handled - a minus sign is always unary if it immediately follows another operator or a left parenthesis, or if it occurs at the very beginning of the input. 
                if (IsNumber(token) ||
                    (token == "-" && pos == 0) ||
                    (token == "-" && (expr[pos - 1].ToString() == "(" || expr[pos - 1].ToString() == ",")) ||
                    (token == "-" && operators.Contains(expr[pos - 1].ToString())))
                {
                    //check if the next token is number or decimal point
                    int counter = 1;
                    while ((pos + counter) < expr.Length && (expr[pos + counter].ToString() == "." || IsNumber(expr[pos + counter].ToString())))
                    {
                        token = token + expr[pos + counter].ToString();
                        counter++;
                    }
                    pos += counter - 1;
                    outputQueue.Enqueue(token);
                    concatenation = null;
                    continue;
                }

                // token is a separator
                if (separator.Contains(token))
                {

                    while (operatorStack.Peek() != "(")
                    {
                        /*Until the token at the top of the stack is a left parenthesis,
                         * pop operators off the stack onto the output queue.*/
                        outputQueue.Enqueue(operatorStack.Pop());
                    }
                    /*If the stack runs out without finding a left parenthesis,
                                             * then there are mismatched parentheses.*/
                    if (!operatorStack.Contains("(")) throw new ArgumentException();
                    concatenation = null;
                    continue;
                }

                // token is bracket
                if (brackets.Contains(token))
                {
                    //token is left paranthesis=> push onto the stack
                    if (token == "(") operatorStack.Push(token);
                    //token is right paranthesis
                    if (token == ")")
                    {
                        /*If the stack runs out without finding a left parenthesis,
                         *then there are mismatched parentheses.*/
                        if (!operatorStack.Contains("(")) throw new ArgumentException();

                        /*Until the token at the top of the stack is a left parenthesis,*/
                        while (operatorStack.Peek() != "(")
                        {
                            /* pop operators off the stack onto the output queue.*/
                            outputQueue.Enqueue(operatorStack.Pop());
                        }
                        /*Pop the left parenthesis from the stack, but not onto the output queue.*/
                        if (operatorStack.Peek() == "(") operatorStack.Pop();
                        /*If the token at the top of the stack is a function token, pop it onto the output queue.*/
                        if (operatorStack.Count() > 0 && functions.Contains(operatorStack.Peek())) outputQueue.Enqueue(operatorStack.Pop());
                    }

                    concatenation = null;
                    continue;
                }

                // token is function
                if (functions.Contains(token))
                {
                    operatorStack.Push(token);
                    concatenation = null;
                    continue;
                }

                // token is operator
                //If the token is an operator, o1, then:
                if (operators.Contains(token))
                {
                    /* while there is an operator token, o2, at the top of the stack, and
                       either o1 is left-associative and its precedence is equal to that of o2,
                       or o1 has precedence less than that of o2,*/
                    while (operatorStack.Count() > 0 && operators.Contains(operatorStack.Peek()) && Precedence(token) >= Precedence(operatorStack.Peek()))
                    {
                        //pop o2 off the stack, onto the output queue;
                        outputQueue.Enqueue(operatorStack.Pop());
                    }
                    //push o1 onto the stack.
                    operatorStack.Push(token);
                    concatenation = null;
                    continue;
                }

                concatenation = token;
            }

            //While there are still operator tokens in the stack:
            while (operatorStack.Count() > 0)
            {
                //If the operator token on the top of the stack is a parenthesis, then there are mismatched parentheses.
                if (brackets.Contains(operatorStack.Peek()))
                {
                    throw new ArgumentException("There are mismatched parentheses");
                }
                //Pop the operator onto the output queue.
                outputQueue.Enqueue(operatorStack.Pop());
            }

            return outputQueue;
        }

        private static double CalculatePostfixExpression(Queue<string> postfixQueue)
        {
            Stack<string> resultingStack = new Stack<string>();
            string token;

            // While there are input tokens left 
            while (postfixQueue.Count > 0)
            {
                // Read the next token from input.
                token = postfixQueue.Dequeue();

                // If the token is a value, Push it onto the stack.
                if (IsNumber(token))
                {
                    resultingStack.Push(token);
                }

                // Otherwise, the token is an operator or function
                else
                {
                    string operatorResult = null;

                    // Else, Pop the top n values from the stack.
                    switch (token)
                    {
                        case "/":
                            operatorResult = ExecuteDivision(resultingStack);
                            break;
                        case "*":
                            operatorResult = ExecuteMultiplication(resultingStack);
                            break;
                        case "+":
                            operatorResult = ExecuteAddition(resultingStack);
                            break;
                        case "-":
                            operatorResult = ExecuteSubtraction(resultingStack);
                            break;
                        case "pow":
                            operatorResult = ExecutePow(resultingStack);
                            break;
                        case "sqrt":
                            operatorResult = ExecuteSqrt(resultingStack);
                            break;
                        case "ln":
                            operatorResult = ExecuteLn(resultingStack);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException("The inserted operator or function is not allowed to be used");
                    }

                    resultingStack.Push(operatorResult);
                }
            }

            if (resultingStack.Count > 1)
            {
                throw new Exception(" The user input has too many values");
            }

            return double.Parse(resultingStack.Pop());
        }

        private static string ExecuteSubtraction(Stack<string> myStack)
        {
            if (myStack.Count < 2)
            {
                throw new InvalidOperationException("There are not enough elements in the stack to perform subtraction.");
            }

            string operatorResult = (-double.Parse(myStack.Pop()) + double.Parse(myStack.Pop())).ToString();
            return operatorResult;
        }

        private static string ExecuteAddition(Stack<string> myStack)
        {
            if (myStack.Count < 2)
            {
                throw new InvalidOperationException("There are not enough elements in the stack to perform addition.");
            }

            string operatorResult = (double.Parse(myStack.Pop()) + double.Parse(myStack.Pop())).ToString();
            return operatorResult;
        }

        private static string ExecuteMultiplication(Stack<string> myStack)
        {
            if (myStack.Count < 2)
            {
                throw new InvalidOperationException("There are not enough elements in the stack to perform multiplication.");
            }

            string operatorResult = (double.Parse(myStack.Pop()) * double.Parse(myStack.Pop())).ToString();
            return operatorResult;
        }

        private static string ExecuteDivision(Stack<string> myStack)
        {
            if (myStack.Count < 2)
            {
                throw new InvalidOperationException("There are not enough elements in the stack to perform division.");
            }

            string operatorResult = (1 / double.Parse(myStack.Pop()) * double.Parse(myStack.Pop())).ToString();
            return operatorResult;
        }

        private static string ExecuteLn(Stack<string> myStack)
        {
            if (myStack.Count < 1)
            {
                throw new InvalidOperationException("There are not enough elements in the stack to perform ln calculation.");
            }

            string operatorResult = Math.Log(double.Parse(myStack.Pop())).ToString();
            return operatorResult;
        }

        private static string ExecutePow(Stack<string> myStack)
        {
            if (myStack.Count < 2)
            {
                throw new InvalidOperationException("There are not enough elements in the stack to perform Power calculation.");
            }

            string exp = myStack.Pop();
            string myBase = myStack.Pop();
            string result = Math.Pow(double.Parse(myBase), double.Parse(exp)).ToString();

            return result;
        }

        private static string ExecuteSqrt(Stack<string> myStack)
        {
            if (myStack.Count < 1)
            {
                throw new InvalidOperationException("There are not enough elements in the stack to perform SQRT calculation.");
            }

            string result = Math.Sqrt(double.Parse(myStack.Pop())).ToString();
            return result;
        }
    }
}
