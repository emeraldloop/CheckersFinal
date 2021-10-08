using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersFinal
{
    class CheckersPlayer
    {
        public string name;
        public string team;
        string checkerName, cell2move;

        public CheckersPlayer(string team)
        {
            this.team = team;
        }
        public bool MakeMove(ref CheckersBoard Board)
        {
            while (true)
            {
                

                Console.WriteLine("Ход команды {0}, укажите шашку ", team);
                checkerName = Console.ReadLine();
                if (Utilities.Check1stClick(team,ref Board,checkerName)==true)
                {
                    Console.WriteLine("Введите имя клетки для хода");
                    cell2move = Console.ReadLine();
                    if (Utilities.Check2ndClick(team, ref Board, checkerName, cell2move)==true)
                    {
                        Board.MakeMove(checkerName, cell2move,team);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка, попробуйте заново сделать ход");
                        Board.nullAtributes();
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка, попробуйте заново сделать ход ");
                    Board.nullAtributes();
                }


            }

            
        }
    }
}
