using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Parser;

namespace Tickets.Logic
{
    public static class Calculator
    {
        public static bool IsLuckyMoskow(this Ticket ticket)
        {
            return SumFirstHalf(ticket.Number) == SumSecondHalf(ticket.Number);
        }

        public static bool IsLuckyPiter(this Ticket t)
        {
            return SumOddPositions(t.Number) == SumEvenPositions(t.Number);
        }
        
        public static uint SumFirstHalf(string line)    //Works with parsed strings
        {
            uint sum = 0;
            uint indexLength = (uint)(line.Length / 2); 

            for(int i = 0; i < indexLength; ++i)
            {
                uint lineInt;

                if (uint.TryParse(line[i].ToString(), out lineInt))
                {
                    sum += lineInt;
                }
            }

            return sum;
        }

        public static uint SumSecondHalf(string line)    //Works with parsed strings
        {
            uint sum = 0;
            uint indexLength = (uint)(line.Length / 2);

            for (uint i = indexLength; i < line.Length; ++i)
            {
                uint lineInt;

                if (uint.TryParse(line[(int)i].ToString(), out lineInt))
                {
                    sum += lineInt;
                }
            }

            return sum;
        }

        public static uint SumEvenPositions(string line)   //Works with parsed strings
        {
            if(string.IsNullOrEmpty(line))
            {
                return 0;
            }

            uint sum = 0;

            for(int i = 0; i < line.Length; ++i)
            {
                if (Calculator.IsEven(i+1))
                {
                    uint lineInt;

                    if(uint.TryParse(line[i].ToString(), out lineInt))
                    {
                        sum += lineInt;
                    }
                }
            }
           
            return sum;
        }

        public static uint SumOddPositions(string line)
        {
            if (string.IsNullOrEmpty(line))
            {
                return 0;
            }

            uint sum = 0;

            for (int i = 0; i < line.Length; ++i)
            {
                if (Calculator.IsOdd(i + 1))
                {
                    uint lineInt;

                    if (uint.TryParse(line[i].ToString(), out lineInt))
                    {
                        sum += lineInt;
                    }
                }
            }

            return sum;
        }

        public static bool IsOdd(int number)
        {
            if(number == 0)   //0 is even
            {
                return false;
            }

            if(number == 1)
            {
                return true;
            }

            if(number % 2 == 1)
            {
                return true;
            }

            return false;
        }

        public static bool IsEven(int number)
        {
            if (number == 1)
            {
                return false;
            }

            if (number % 2 == 0)
            {
                return true;
            }

            return false;
        }

        public static uint SumToOneDigit(uint number)
        {
            uint sum = 0;

            if (number > 9)
            {
                string line = number.ToString();

                foreach(char ch in line)
                {
                    byte digit = 0;

                    if (byte.TryParse(ch.ToString(), out digit))
                    {
                        sum += sum;
                    }
                }

                if(sum > 9)
                {
                    SumToOneDigit(sum);
                }
            }

            return sum;
        }
    }
}
