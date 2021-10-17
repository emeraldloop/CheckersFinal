using System;

namespace CheckersFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();

            manager.Init();
      
            while (true)
            {
                manager.MakeMove();
                if (manager.CheckWin() == true)
                    break;
            }
            Console.WriteLine("Игра окончена");
        }
    }
}
