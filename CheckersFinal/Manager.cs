using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersFinal
{
    class Manager
    {
        CheckersBoard board;
        Player whitePlayer, blackPlayer, currentPlayer;
        public void Init()
        {
            board = new CheckersBoard();
            Console.WriteLine("Введите имя белого игрока");
            whitePlayer = new CheckersPlayer("white");
            whitePlayer.name = Console.ReadLine();
            Console.WriteLine("Черный игрок - человек/бот? Человек - 1, бот - 2");
            string mode = Console.ReadLine();
            if (mode == "1")
            {
                Console.WriteLine("Введите имя черного игрока");
                blackPlayer = new CheckersPlayer("black");
                blackPlayer.name = Console.ReadLine();
            }
            if(mode=="2")
            {
                blackPlayer = new CompPlayer("black");
            }
            currentPlayer = whitePlayer;
        }
        
        void ShowBoard()
        {
            board.ShowBoard();
        }

        public void MakeMove()
        {
        
            ShowBoard();
            while (!currentPlayer.MakeMove(ref board))
            {
                Console.WriteLine("Not available move, try again ");
                board.nullAtributes();
                ShowBoard();
            }
            board.nullAtributes();
            currentPlayer = (currentPlayer == blackPlayer) ? whitePlayer : blackPlayer;
        }

        public bool CheckWin() => board.IsWin() == true;
        


    }
}
 
