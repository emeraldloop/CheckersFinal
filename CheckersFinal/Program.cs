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
            }
        }
    }
}
