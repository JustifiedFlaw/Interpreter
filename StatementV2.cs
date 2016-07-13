using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleApplication
{
    public static class StatementV2
    {
        const string numberEx = @"\-?\d+(\.\d)?";
        public static double Evaluate(string input)
        {
            var match = Regex.Match(input, @"\(.*\)");
            if(!match.Success)
            {
                var left = Regex.Match(input, numberEx);
                if(left.Success && left.Index == 0)
                {
                    double value = double.Parse(left.Value);

                    foreach(Match right in Regex.Matches(input, @"([\-+/\*])\s*(" + numberEx + ")"))
                    {
                        double rightValue = double.Parse(right.Groups[2].Value);
                        char op = right.Groups[1].Value[0];
                        if(op == '+') value += rightValue;                       
                        else if(op == '-') value -= rightValue;                       
                        else if(op == '*') value *= rightValue;  //TODO: prioritize * and /                     
                        else if(op == '/') value /= rightValue;                       
                    }

                    return value;
                }
            }
            else 
            {
                //TODO: could have number and operator before or after the parantheses
                return Evaluate(match.Value.Substring(1, match.Value.Length - 2));
            }
            throw(new Exception("\"" + input + "\" is not a valid expression"));
        }
    }
}