using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleApplication
{
    class StatementV1
    {
        public List<StatementV1> Statements { get; set; } = new List<StatementV1>();
        public Operator Operator { get; set; }
        public double Number { get; set; }

        public StatementV1(string input)
        {
            //tokenize
            var nonNumbers = Regex.Matches(input, @"[\(\)\-+\*\/](?!\d)").Cast<Match>();
            var numbers = Regex.Matches(input, @"\-?\d+(\.\d)?").Cast<Match>();
            tokens = numbers
                .Concat(nonNumbers.Where(m => !numbers.Any(j => j.Index == m.Index)))
                .OrderBy(m => m.Index).Select(m => m.Value).ToArray();
            Categorize(this);
        }

        int i = 0;
        string[] tokens;
        private void Categorize(StatementV1 s)
        {
            //tokenize
            for(; i < tokens.Length; i++)
            {
                if(Regex.IsMatch(tokens[i], @"\-?\d+(\.\d)?"))
                {
                    s.Number = double.Parse(tokens[i]);
                }
                else if(tokens[i] == ")")
                {
                    break;
                }
                else if(tokens[i] == "(" || "+-*/".Contains(tokens[i]))
                {
                    Operator subOp = Operator.Addition;
                    if(tokens[i] == "-") subOp = Operator.Subtraction;
                    else if(tokens[i] == "*") subOp = Operator.Multiplication;
                    else if(tokens[i] == "/") subOp = Operator.Division;

                    s.Statements.Add(new StatementV1() { Operator = subOp });
                    i++;
                    Categorize(s.Statements.Last());
                }
            }
        }

        public static double Evaluate(string v)
        {
            return new StatementV1(v).Evaluate();
        }

        public StatementV1() { }

        public double Evaluate()
        {
            double value = Number;
            foreach (var other in Statements)
                value = Evaluate(other.Evaluate(), other.Operator, value);

            return value;
        }

        private double Evaluate(double number, Operator op, double currentValue = 0)
        {
            switch (op)
            {
                case Operator.Division:
                    currentValue /= number;
                    break;
                case Operator.Multiplication:
                    currentValue *= number;
                    break;
                case Operator.Subtraction:
                    currentValue -= number;
                    break;
                case Operator.Addition:
                default:
                    currentValue += number;
                    break;
            }
            
            return currentValue;
        }
    }
}