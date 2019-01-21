using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Logic;

namespace Tickets.Parser
{
    public static class TextParser
    {
        public static string MOSKOW = "moskow";
        public static string PITER = "piter";

        public static string PickOutNumerals(string line)  
        {
            if (string.IsNullOrEmpty(line))
            {
                return null;
            }

            string result = "";

            for (int i = 0; i < line.Length; ++i)
            {
                if (line[i] >= '0' && line[i] <= '9')
                {
                    result += line[i];
                }
            }

            return result;
        }

        public static bool IsMoskowLine(string line)
        {
            if(string.IsNullOrEmpty(line))
            {
                return false;
            }

            if(line.ToLower() == MOSKOW)
            {
                return true;
            }

            return false;
        }

        public static bool IsPiterLine(string line)
        {
            if (string.IsNullOrEmpty(line))
            {
                return false;
            }

            if (line.ToLower() == PITER)
            {
                return true;
            }

            return false;
        }

        public static string SetEvenCountOfDigits(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return null;
            }

            string result = string.Empty;

            if (Calculator.IsOdd(number.Length))
            {
                result = '0' + number;
            }

            return result;
        }

    }
}
