using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Logic;
using Tickets.UI;

namespace Tickets.Parser
{
    public static class FileParser
    {
        public static bool FileReader(string path, out IList<Ticket> tickets, out string wayToCount)
        {
            if(string.IsNullOrEmpty(path))
            {
                tickets = null;
                wayToCount = null;
                return false;
            }

            FileInfo file = new FileInfo(path);

            if(!file.Exists)
            {
                UserUI.OutputMessage(UserUI.ERR_DATA_FILE_NOT_EXISTS);
                tickets = null;
                wayToCount = null;
                return false;
            }

            if(file.Length == 0)
            {
                UserUI.OutputMessage(UserUI.ERR_EMPTY_DATA_FILE);
                tickets = null;
                wayToCount = null;
                return false;
            }

            try
            {
                tickets = new List<Ticket>();
                wayToCount = "";

                using (StreamReader reader = new StreamReader(path))
                {
                    string baseLine = string.Empty;
                    int index = 0;

                    while ((baseLine = reader.ReadLine()) != null)
                    {
                        if(index == 0)
                        {
                            wayToCount = baseLine;
                            ++index;
                            continue;
                        }

                        tickets.Add(new Ticket(baseLine));

                        ++index;
                    }
                }
                return true;
            }
            catch(Exception e)
            {
                e.Data.Add("Operation", "Read file");
                e.Data.Add("File path", path);

                throw new Exception(e.Message, e);
            }
        }

        public static bool CheckFileExists(string path)
        {
            if (!File.Exists(path))
            {
                UserUI.OutputMessage(string.Format("{0}: {1}", path, UserUI.ERR_DATA_FILE_NOT_EXISTS));

                return false;
            }

            return true;
        }

        public static bool CheckNonZeroLength(string path)
        {
            FileInfo file = new FileInfo(path);

            if (!file.Exists)
            {
                return false;
            }

            if (file.Length == 0)
            {
                UserUI.OutputMessage(string.Format("{0}: {1}", path, UserUI.ERR_EMPTY_DATA_FILE));

                return false;
            }

            return true;
        }

        public static string GetFullPathResultFile(string baseFullPath, string resultFileName)
        {
            if (string.IsNullOrEmpty(baseFullPath) || string.IsNullOrEmpty(resultFileName))
            {
                return null;
            }

            return Path.Combine(Path.GetDirectoryName(baseFullPath), resultFileName);

        }
    }
}
