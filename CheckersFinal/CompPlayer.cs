using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersFinal
{
    class CompPlayer : Player
    {
        new string  name;
        new string  team;
        public CompPlayer(string team)
        {
            this.team = team;
            name = "Bot";
        }
        public override bool MakeMove(ref CheckersBoard Board)
        {
            throw new NotImplementedException();
        }
    }
}
