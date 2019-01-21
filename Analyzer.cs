using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Logic;
using Tickets.Parser;
using Tickets.UI;

namespace Tickets
{
    public class Analyzer
    {
        public const string WAY_UNASSIGNED_LONG = "The way to calculate ticket lucky is unassigned.";

        protected IList<Ticket> _tickets;

        protected string _wayToCount = string.Empty;

        protected string _path = string.Empty;
        
        public Analyzer(string path, string wayToCount)
        {
            _path = path;
            _wayToCount = wayToCount;
        }

        public Analyzer(Analyzer a)
            :this(a._path, a._wayToCount)
        {
        }
        
        public string Path
        {
            get { return _path; }
        }

        public void Analyze()
        {
            if(!Tickets.Parser.FileParser.FileReader(_path, out _tickets, out _wayToCount))
            {
                UserUI.OutputMessage(string.Format("{0} {1}",UserUI.ERR_READING_FILE, _path));
                return;
            }

            for(int i = 0; i < _tickets.Count; ++i)
            {
                _tickets[i].SetNumber();
            }

            bool isMoskov = false;

            if (TextParser.IsMoskowLine(_wayToCount))
            {
                isMoskov = true;
            }
            else if (TextParser.IsPiterLine(_wayToCount))
            {
                isMoskov = false;
            }
            else
            {
                UserUI.OutputMessage(UserUI.OUTPUT_EMPTY_DATA);
                UserUI.OutputMessage(WAY_UNASSIGNED_LONG);
                return;
            }

            _tickets.PrintTicketsInfo(isMoskov);
        }

    }
}
