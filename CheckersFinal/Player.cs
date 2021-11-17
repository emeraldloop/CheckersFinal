using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersFinal
{
    abstract class Player
    {
        public string team;
        public string name;
        abstract public bool MakeMove(ref CheckersBoard Board);

    }
}
