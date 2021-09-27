using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersFinal
{
    class Cell
    {
        public string name;
        public int x, y;
        public Checker checker;
        public Cell()
        {
            checker = null;
        }
        public bool available=true;
        public bool available2move = false;
        public bool available2fight = false;
    }
}
