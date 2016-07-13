using System;
using System.Diagnostics;

namespace ConsoleApplication
{
    public class TestsV2
    {
        public static void StringStatements()
        {
            //2 + 3 = 5
            var value = StatementV2.Evaluate("2 + 3");
            if(value != 5) throw(new Exception($"2 + 3: expected 5 but got {value}"));
            
            //2 * 3 + 1 = 7
            value = StatementV2.Evaluate("2 * 3 + 1");
            if(value != 7) throw(new Exception($"2 * 3 + 1: expected 7 but got {value}"));

            //2 * (3 + 1) = 8
            value = StatementV2.Evaluate("2 * (3 + 1)");
            if(value != 8) throw(new Exception($"2 * (3 + 1): expected 8 but got {value}"));

            //2 + 3 * 2 = 8
            value = StatementV2.Evaluate("2 + 3 * 2");
            if(value != 8) throw(new Exception($"2 * (3 + 1): expected 8 but got {value}"));

            //2 + (3 * 2) = 8
            value = StatementV2.Evaluate("2 + (3 * 2)");
            if(value != 8) throw(new Exception($"2 + (3 * 2): expected 8 but got {value}"));

            //(2 + 3) * 2 = 12
            value = StatementV2.Evaluate("(2 + 3) * 2");
            if(value != 12) throw(new Exception($"2 + (3 * 2): expected 12 but got {value}"));
        }
    }
}