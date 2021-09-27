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
                if (CheckFights(board) == true)
                {
                    board.jumpneed = true;
                    if (CheckPossibility2Fight(checkerName) == true)
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
                    if (CheckPossibility2Move(checkerName) == true)
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
            if (board.jumpneed == true && CheckCell2Move(cellName) == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        static bool CheckTeam(Cell cell,string team)
        {
            if (cell.checker.team == team)
                return true;
            else
                return false;
        }

        static bool CheckFights(CheckersBoard board)
        {

            return true;
        }
        static bool CheckPossibility2Fight(string checkername)
        {

            return true;
        }
        static bool CheckPossibility2Move(string checkerName)
        {
            return true;
        }
        static bool CheckCell2Move(string cellName)
        {
            return true;
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
