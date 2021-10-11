using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersFinal
{
    static class Utilities
    {
       
        public static string GetXLetter(int x)
        {
            string letter;
            switch (x)
            {
                case 1:
                    letter = "a";
                    break;
                case 2:
                    letter = "b";
                    break;
                case 3:
                    letter = "c";
                    break;
                case 4:
                    letter = "d";
                    break;
                case 5:
                    letter = "e";
                    break;
                case 6:
                    letter = "f";
                    break;
                case 7:
                    letter = "g";
                    break;
                case 8:
                    letter = "h";
                    break;
                default:
                    letter = "cringe";
                    break;
            }

            return letter;
        }
        public static char GetIcon(Cell cell)
        {
            if (cell.available == false && cell.checker == null)
            {
                return '\u25A0';
            }
            if (cell.available == true && cell.checker == null)
            {
                return '_';
            }

            if (cell.checker != null && cell.checker.team == "white")
            {
                return 'W';
            }
            if (cell.checker != null && cell.checker.team == "black")
            {
                return 'B';
            }

            return '?';
        }
        public static bool Check1stClick(string team, ref CheckersBoard board, string checkerName)
        {
            board.jumpneed = false;
            if (CheckTeam(GetCell(ref board,checkerName),team) == true)
            {
                if (CheckFights(ref board,team, checkerName) == true)
                {
                    board.jumpneed = true;
                    if (CheckPossibility2Fight(board,checkerName) == true)
                    {
                        Console.WriteLine("Вы должны есть этой шашкой");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Эта шашка не может ходить, есть необходимый бой");
                        return false;
                    }
                }
                else
                {
                    board.jumpneed = false;
                    if (CheckPossibility2Move(ref board,checkerName) == true)
                    {
                        Console.WriteLine("Эта шашка может ходить");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("У этой шашки нет ходов");
                        return false;
                    }
                }
            }
            return false;
        }
        public static bool Check2ndClick(string team, ref CheckersBoard board, string checkerName, string cellName)
        {

            if (board.jumpneed == true && GetCell(ref board,cellName).available2fight == true)
            {
                return true;
            }
            if(board.jumpneed!=true && GetCell(ref board,cellName).available2move==true)
            {
                return true;
            }
            return false;
        }

        static bool CheckTeam(Cell cell,string team)
        {
            if (cell.checker != null )
            {
                if (cell.checker.team == team)
                    return true;
            }
            return false;
        }

        static bool CheckFights(ref CheckersBoard board, string team, string checkerName)
        {
            if (   CheckWay4Fights(ref board.GoldWay, team,checkerName) | CheckWay4Fights(ref board.DoubleWay_g8a2, team, checkerName)
                | CheckWay4Fights(ref board.DoubleWay_h7b1, team, checkerName) | CheckWay4Fights(ref board.TripleWay_a6f1, team, checkerName)
                | CheckWay4Fights(ref board.TripleWay_c8h3,team, checkerName) 
                | CheckWay4Fights(ref board.TripleWay_c8a6,team, checkerName) | CheckWay4Fights(ref board.TripleWay_h3f1, team, checkerName) 
                | CheckWay4Fights(ref board.UltraWay_e8a4,team, checkerName)  | CheckWay4Fights(ref board.UltraWay_h5d1,team, checkerName)
                | CheckWay4Fights(ref board.UltraWay_a4d1, team, checkerName) | CheckWay4Fights(ref board.UltraWay_e8h5, team, checkerName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static bool CheckWay4Fights(ref Cell[] Way,string team,string checkerName)
        {

            for (int i=0;i<Way.Length-2;i++)
            {
                if(Way[i].checker !=null)
                {
                    if (Way[i].checker.team==team)
                    {
                        if(Way[i+1].checker !=null)
                        {
                            if (Way[i+1].checker.team!=team)
                            {
                                if (Way[i + 2].checker == null)
                                {
                                    if(Way[i].name==checkerName)
                                    {
                                        Way[i + 2].available2fight = true;
                                        Way[i + 1].checker.need2eat = true;
                                        Way[i].checker.mustEat = true;
                                    }
                                    return true;
                                }
                            }
                        }
                    }
                }
            }

            for (int i=Way.Length-1;i>1;i--)
            {
                if(Way[i].checker!=null)
                {
                    if(Way[i].checker.team==team)
                    {
                        if(Way[i-1].checker != null)
                        {
                            if(Way[i-1].checker.team!=team)
                            {
                                if (Way[i - 2].checker == null)
                                {
                                    if (Way[i].name == checkerName)
                                    {
                                        Way[i - 2].available2fight = true;
                                        Way[i -1].checker.need2eat = true;
                                        Way[i].checker.mustEat = true;
                                    }
                                    return true;
                                }                           
                            }
                        }
                    }
                }
            }
            return false;
        }
        
        static bool CheckPossibility2Fight(CheckersBoard board,string checkername)
        {
            if (GetCell(ref board, checkername).checker.mustEat == true)
                return true;
            else
                return false;
        }
        static bool CheckPossibility2Move(ref CheckersBoard board,string checkerName)
        {
            if (  CheckWay4Moves(ref board,ref board.GoldWay, checkerName) | CheckWay4Moves(ref board, ref board.DoubleWay_g8a2, checkerName)
                | CheckWay4Moves(ref board, ref board.DoubleWay_h7b1, checkerName) | CheckWay4Moves(ref board, ref board.TripleWay_a6f1, checkerName)
                | CheckWay4Moves(ref board, ref board.TripleWay_c8h3, checkerName) | CheckWay4Moves(ref board, ref board.TripleWay_h3f1, checkerName) | CheckWay4Moves(ref board, ref board.TripleWay_c8a6, checkerName)
                | CheckWay4Moves(ref board, ref board.UltraWay_a4d1, checkerName)  | CheckWay4Moves(ref board, ref board.UltraWay_e8a4, checkerName)
                | CheckWay4Moves(ref board, ref board.UltraWay_h5d1, checkerName)  | CheckWay4Moves(ref board,ref board.UltraWay_e8h5, checkerName))
            {
                return true;
            }
            return false;
        }
        private static bool CheckWay4Moves(ref CheckersBoard board, ref Cell[] Way, string checkerName)
        {
            

            if(GetCell(ref board,checkerName).checker.team=="white")
            {
                for (int i = 0; i < Way.Length - 1; i++)
                {
                    if (Way[i].checker != null)
                    {
                        if (Way[i].checker.name == checkerName)
                        {
                            if (Way[i + 1].checker == null)
                            {
                                Way[i + 1].available2move = true;

                                return true;
                            }
                        }
                    }
                }
            }
            if(GetCell(ref board, checkerName).checker.team == "black")
            {
                for (int i = Way.Length - 1; i > 1; i--)
                {
                    if (Way[i].checker != null)
                    {
                        if (Way[i].checker.name == checkerName)
                        {
                            if (Way[i - 1].checker == null)
                            {
                                Way[i - 1].available2move = true;

                                return true;
                            }
                        }
                    }
                }
            }
            return false;

        }

        public static ref Cell GetCell(ref CheckersBoard board, string cellName)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board.cells[i, j].name == cellName)
                    {
                        return ref board.cells[i, j];
                    }

                }
            }
            Console.WriteLine("Ошибка, клетки с таким именем не существует");
            return ref board.cells[0, 0]; //костыль
        }

    }
}
