using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Logic;
using Tickets.Parser;

namespace Tickets.UI
{
    public static class UserUI
    {
        #region    Constants
        public const string PATH_RESOURSES = @"..\..\Resources\Info.txt";

        public const string EXTRA = " Extra details:";
        public const string KEY = "   Key:";
        public const string DATA = "  Data:";
        public const string TRACE = "  StackTrace:";
        public const string SITE = "  TargetSite:";

        public const string ERR_DATA_FILE_NOT_EXISTS = "Error: data file does not exist.";
        public const string ERR_EMPTY_DATA_FILE = "Error: data file is empty.";
        public const string ERR_READING_FILE = "Error of the reading of data file:";
        public const string OUTPUT_EMPTY_DATA = "Error of outputting data.";
        public const string APP_COMPLETED = "Application is completed.";
        public const string ERR_EMPTY_ARGS = "Error: empty command arguments line.";

        public const string TITLE = "===============Lucky Tikets===============";
        public const string WAY = "Way to calculate lucky of tikets";
        public const string MOSKOW = "Moskov";
        
        public const string PITER = "Piter";
        public const string LINE = "------------------------------------------";
        public const string LUCKY = "Lucky";
        public const string UNLUCKY = "Unlucky";
        public const string TOTAL_LUCKY = "Total amount of lucky tickets";

        #endregion

        public static void OutputMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void OutputInstructions()
        {
            try
            {
                if (File.Exists(PATH_RESOURSES))
                {
                    string[] info = File.ReadAllLines(PATH_RESOURSES);

                    foreach (string str in info)
                    {
                        Console.WriteLine(str);
                    }
                }
            }
            catch (Exception e)
            {
                e.Data.Add("File Path:", PATH_RESOURSES);
                e.Data.Add("File Operation:", "Try to read all lines.");

                Console.WriteLine(e.Message);
                foreach (DictionaryEntry entry in e.Data)
                {
                    Console.WriteLine(string.Format("{0} {1}", entry.Key, entry.Value));
                }
            }
        }

        public static void OutputExceptionInfo(Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("{0} {1}", SITE, e.StackTrace);
            Console.WriteLine("{0} {1}", TRACE, e.TargetSite.ToString());

            if (e.Data.Count > 0)
            {
                Console.WriteLine(EXTRA);

                foreach (DictionaryEntry entry in e.Data)
                {
                    Console.WriteLine(" {0} {1}        {2} {3}", KEY, entry.Key.ToString(), DATA, entry.Value);
                }
            }
        }

        public static void PrintTicketsInfo(this IList<Ticket> list, bool isMoskov)
        {
            if(list == null)
            {
                Console.WriteLine(OUTPUT_EMPTY_DATA);
            }

            string wayName = string.Empty;

            if(isMoskov)
            {
                wayName = MOSKOW;
            }
            else
            {
                wayName = PITER;
            }

            Console.WriteLine(TITLE);
            Console.WriteLine(string.Format("{0}: {1}", WAY, wayName));
            Console.WriteLine(LINE);

            uint totalIndexLucky = 0;

            foreach(Ticket item in list)
            {
                string lucky = string.Empty;

                if (isMoskov)
                {
                    if(item.IsLuckyMoskow())
                    {
                        lucky = LUCKY;
                        ++totalIndexLucky;
                    }
                    else
                    {
                        lucky = UNLUCKY;
                    }
                }
                else
                {
                    if (item.IsLuckyPiter())
                    {
                        lucky = LUCKY;
                        ++totalIndexLucky;
                    }
                    else
                    {
                        lucky = UNLUCKY;
                    }
                }
                
                Console.WriteLine("{0}: {1}", item.ToString(), lucky);
            }

            Console.WriteLine(LINE);
            Console.WriteLine("{0}: {1}", TOTAL_LUCKY, totalIndexLucky);
            Console.WriteLine(LINE);
        }
    }
}
