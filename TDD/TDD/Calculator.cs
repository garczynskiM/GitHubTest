using System;
using System.Collections.Generic;
using System.Text;
using TDD.Exceptions;

namespace TDD
{
    public class Calculator
    {
        
        public Calculator()
        {
        }
        private char[] PrepareSeparators(string potentialAdditionalSeparator)
        {
            List<char> separatorsList = new List<char>();
            separatorsList.Add(',');
            separatorsList.Add('\n');
            if (potentialAdditionalSeparator.Length == 2 && potentialAdditionalSeparator[1] == '\n' && !char.IsDigit(potentialAdditionalSeparator[0]))
                separatorsList.Add(potentialAdditionalSeparator[0]);
            return separatorsList.ToArray();
        }
        public double Calculate(string input)
        {
            char[] separators;
            if(input.Length >= 2) separators = PrepareSeparators(input.Substring(0, 2));
            else separators = PrepareSeparators("");
            int numberValue;
            double result;
            
            if (input == "") return 0;
            else
            {
                if(int.TryParse(input, out numberValue))
                {
                    if (numberValue < 0) throw new NegativeNumberException("You cannot input negative numbers, as strange as it sounds");
                    if (numberValue > 1000) return 0;
                    return numberValue;
                }
                else
                {
                    result = 0;
                    string[] numbers = input.Split(separators);
                    foreach (string s in numbers)
                    {
                        if (s == "") continue;
                        else if (int.TryParse(s, out numberValue))
                        {
                            if (numberValue < 0) throw new NegativeNumberException("You cannot input negative numbers, as strange as it sounds");
                            if (numberValue > 1000) continue;
                            result += numberValue;
                        }
                        else throw new NotANumberException("Wrong format of input string");
                    }
                }
                return result;
            }
        }
    }
}
