using System;
using System.Diagnostics;

namespace ConsoleApplication
{
    public class TestsV1
    {
        public static void PreloadedStatements()
        {
            //2 + 3 = 5
            StatementV1 s1 = new StatementV1();
            s1.Number = 2;

            StatementV1 s2 = new StatementV1();
            s2.Number = 3;
            s2.Operator = Operator.Addition;

            s1.Statements.Add(s2);

            var value = s1.Evaluate();
            if(value != 5) throw(new Exception($"2 + 3: expected 5 but got {value}"));
            
            //2 * 3 + 1 = 8
            s1 = new StatementV1() { Number = 2 };
            s1.Statements.Add(new StatementV1() {Number=3, Operator=Operator.Multiplication});
            s1.Statements.Add(new StatementV1() {Number=1, Operator=Operator.Addition});
            value = s1.Evaluate();
            if(value != 7) throw(new Exception($"2 * 3 + 1: expected 7 but got {value}"));

            //2 * (3 + 1) = 8
            s1 = new StatementV1() { Number = 2 };
            s1.Statements.Add(new StatementV1() {Number=3, Operator=Operator.Multiplication});
            s1.Statements[0].Statements.Add(new StatementV1() {Number=1, Operator=Operator.Addition});
            value = s1.Evaluate();
            if(value != 8) throw(new Exception($"2 * (3 + 1): expected 8 but got {value}"));

            //2 + 3 * 2 = 8

            //2 + (3 * 2) = 8

            //(2 + 3) * 2 = 12

            System.Console.WriteLine("Passed!");
        }

        public static void StringStatements()
        {
            //2 + 3 = 5
            StatementV1 s1 = new StatementV1("2 + 3");
            var value = s1.Evaluate();
            if(value != 5) throw(new Exception($"2 + 3: expected 5 but got {value}"));
            
            //2 * 3 + 1 = 7
            s1 = new StatementV1("2 * 3 + 1");
            value = s1.Evaluate();
            if(value != 7) throw(new Exception($"2 * 3 + 1: expected 7 but got {value}"));

            //2 * (3 + 1) = 8
            s1 = new StatementV1("2 * (3 + 1)");
            value = s1.Evaluate();
            if(value != 8) throw(new Exception($"2 * (3 + 1): expected 8 but got {value}"));

            //2 + 3 * 2 = 8
            value = StatementV1.Evaluate("2 + 3 * 2");
            if(value != 8) throw(new Exception($"2 * (3 + 1): expected 8 but got {value}"));

            //2 + (3 * 2) = 8
            value = StatementV1.Evaluate("2 + (3 * 2)");
            if(value != 8) throw(new Exception($"2 + (3 * 2): expected 8 but got {value}"));

            //(2 + 3) * 2 = 12
            value = StatementV1.Evaluate("(2 + 3) * 2");
            if(value != 12) throw(new Exception($"2 + (3 * 2): expected 12 but got {value}"));
        }
    }
}