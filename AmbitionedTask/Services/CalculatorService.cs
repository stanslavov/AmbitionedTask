using AmbitionedTask.Models;
using AmbitionedTask.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;

namespace AmbitionedTask.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly Stack<Number> results;
        private readonly Stack<Number> values;
        private readonly Stack<char> operations;

        public CalculatorService()
        {
            this.results = new Stack<Number>();
            this.values = new Stack<Number>();
            this.operations = new Stack<char>();
        }

        public void Calculate(ExpressionViewModel input)
        { 
            var i = 0;
            while (true)
            {
                var restOfExpression = input.Expression.Substring(i);
                if (string.IsNullOrEmpty(restOfExpression))
                {
                    break;
                }

                var number = DummyLexer.Parse(restOfExpression, out var tokenLength);
                if (number != null)
                {
                    this.values.Push(number);
                    i += tokenLength;
                    continue;
                }

                if (DummyLexer.ParseExact(restOfExpression, Constants.Parentheses1, out tokenLength) != null)
                {
                    this.operations.Push(Constants.Parentheses3);
                    i += tokenLength;
                    continue;
                }

                if (DummyLexer.ParseExact(restOfExpression, Constants.Parentheses2, out tokenLength) != null)
                {
                    while (this.operations.Peek() != Constants.Parentheses3)
                    {
                        this.values.Push(Calculate(this.operations.Pop(), this.values.Pop(), this.values.Pop()));
                    }
                    this.operations.Pop();
                    i += tokenLength;
                    continue;
                }

                var operation = DummyLexer.Parse(restOfExpression, Constants.Regex1, out tokenLength).FirstOrDefault();
                if (operation != 0)
                {
                    while (this.operations.Count > 0 && Precedence.IsPrecided(operation, this.operations.Peek()))
                    {
                        this.values.Push(Calculate(this.operations.Pop(), this.values.Pop(), this.values.Pop()));
                    }
                    this.operations.Push(operation);
                    i += tokenLength;
                }
            }

            while (this.operations.Count > 0)
            {
                this.values.Push(Calculate(this.operations.Pop(), this.values.Pop(), this.values.Pop()));
            }

            var result = this.values.Pop();
            if (this.values.Any() || this.operations.Any())
            {
                throw new InvalidOperationException();
            }


            this.results.Push(result);
        }

        public Number GetResult()
        {
            return this.results.Pop();
        }

        private static Number Calculate(char op, Number b, Number a)
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
                    return a / b;
                default:
                    throw new InvalidOperationException(op.ToString());
            }
        }
    }
}
