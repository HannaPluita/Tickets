using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Logic;
using Tickets.Parser;
using Tickets.Logic;
using Tickets.UI;

namespace Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            uint a = Calculator.SumToOneDigit(29);  //Debug function

            if (args.Length < 2)
            {
                UserUI.OutputMessage(UserUI.ERR_EMPTY_ARGS);
                return;
            }

            try
            {
                Analyzer analyzer = new Analyzer(args[0], args[1]);
                analyzer.Analyze();
            }
            catch(Exception e)
            {
                UserUI.OutputExceptionInfo(e);
            }
            finally
            {
                UserUI.OutputMessage(UserUI.APP_COMPLETED);
            }

            Console.ReadLine();
        }
    }
}
