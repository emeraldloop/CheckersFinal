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
        CheckersPlayer whitePlayer, blackPlayer, currentPlayer;
        public void Init()
        {
            board = new CheckersBoard();
            Console.WriteLine("Введите имя белого игрока");
            whitePlayer = new CheckersPlayer("white");
            whitePlayer.name = Console.ReadLine();
            Console.WriteLine("Введите имя черного игрока");
            blackPlayer = new CheckersPlayer("black");
            blackPlayer.name = Console.ReadLine();
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

            currentPlayer = (currentPlayer == blackPlayer) ? whitePlayer : blackPlayer;
        }



    }
}
 
