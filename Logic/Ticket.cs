using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Parser;

namespace Tickets.Logic
{
    public class Ticket
    {
        protected string _number = "";

        public Ticket()
        {
        }

        public Ticket(string number)
        {
            _number = number;
        }

        public Ticket(Ticket t)
            :this(t._number)
        {
        }

        public string Number
        {
            get { return _number; }
        }

        public override string ToString()
        {
            return string.Format("{0}", _number);
        }

        public bool SetNumber()
        {
            if (string.IsNullOrEmpty(_number))
            {
                return false;
            }

            return SetNumerals(_number) && SetEvenDigitCount();
        }

        public bool SetNumerals(string line)
        {
            if (string.IsNullOrEmpty(line))
            {
                return false;
            }

            string result = TextParser.PickOutNumerals(line);

            if (!string.IsNullOrEmpty(result))
            {
                _number = result;

                return true;
            }

            return false;
        }

        protected bool SetEvenDigitCount()
        {
            if (string.IsNullOrEmpty(_number))
            {
                return false;
            }

            string result = TextParser.SetEvenCountOfDigits(_number);

            if (!string.IsNullOrEmpty(result))
            {
                _number = result;

                return true;
            }

            return false;
        }
    }
}
