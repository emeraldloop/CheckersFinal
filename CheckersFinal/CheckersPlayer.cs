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
            bool firstmove = true;
            while (true)
            {   
                
                Console.WriteLine("0 - дамка белых, O - дамка черных");
                if (firstmove == true)
                {
                    Console.WriteLine("Ход команды {0}, укажите шашку ", team);
                    checkerName = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Ход команды {0} продолжается, есть бой ", team);
                    checkerName = cell2move;
                    Board.ShowBoard();
                }
                if (Utilities.Check1stClick(team,ref Board,checkerName)==true)
                {
                    Console.WriteLine("Введите имя клетки для хода");
                    cell2move = Console.ReadLine();
                    if (Utilities.Check2ndClick(team, ref Board, checkerName, cell2move)==true)
                    {
                        if (Board.MakeMove(checkerName, cell2move, team))
                        {
                            if (Board.jumpneed == true)
                            {
                                Board.nullAtributes();
                                if (Utilities.CheckFights(ref Board, team, cell2move) == true && Utilities.GetCell(ref Board, cell2move).checker.mustEat == true)//нужно написать проверку для конкретной шашки
                                {
                                    Board.nullAtributes();
                                    Console.WriteLine("У этой шашки еще есть бой");
                                    firstmove = false;
                                    continue;
                                }
                                else
                                    return true;
                            }
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Ошибка, ход не сделан");
                            return false;
                        }
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
