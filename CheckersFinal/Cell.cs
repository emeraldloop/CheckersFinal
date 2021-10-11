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
            available = true;
            available2move = false;
            available2fight = false;
    }
        public bool available;
        public bool available2move;
        public bool available2fight;
    }
}
