﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersFinal
{
    class Checker
    {
        public Checker(string team)
        {
            this.team = team;
            need2eat = false;
            queen = false;
            mustEat = false;

        }
        public string name;
        public int x, y;
        public string team; //white / black
        public bool queen;
        public bool need2eat;
        public bool mustEat;
        

    }
}
