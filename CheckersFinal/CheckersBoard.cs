using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersFinal
{
    class CheckersBoard
    {
        Cell[,] cells;

        public CheckersBoard()
        {
            CreateCells();
            CreateCheckers();

        }
        public void CreateCells()
        {
            cells = new Cell[8,8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    cells[i, j] = new Cell();
                }

            }


            for (int i=0;i<8;i++)
            {
                for (int j=0;j<8;j++)
                {

                    cells[i, j].x = j + 1;
                    cells[i, j].y = i + 1;
                    cells[i, j].checker = null;
                    if (i%2==0 && j%2==0)
                    {
                        cells[i, j].available = false;
                    }
                }
                
            }

        }

        public void CreateCheckers()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if( (cells[i,j].y==1 || cells[i,j].y==3) && (cells[i, j].x==2 || cells[i, j].x == 4 || cells[i, j].x == 6 || cells[i, j].x == 8))
                    {
                        cells[i, j].checker = new Checker();
                        cells[i, j].checker.team = "black";
                        cells[i, j].checker.x = cells[i, j].x;
                        cells[i, j].checker.y = cells[i, j].y;
                        cells[i, j].checker.name = Utilities.GetXLetter(cells[i, j].x)+ cells[i, j].y;
                        cells[i, j].available = true;
                        continue;
                    }
                    if(cells[i,j].y==2 && (cells[i,j].x==1 || cells[i,j].x==3 || cells[i, j].x == 5 || cells[i, j].x == 7))
                    {
                        cells[i, j].checker = new Checker();
                        cells[i, j].checker.team = "black";
                        cells[i, j].checker.x = cells[i, j].x;
                        cells[i, j].checker.y = cells[i, j].y;
                        cells[i, j].checker.name = Utilities.GetXLetter(cells[i, j].x) + cells[i, j].y;
                        cells[i, j].available = true;
                        continue;
                    }
                    if (cells[i, j].y==4 && (cells[i, j].x==1 || cells[i, j].x == 3 || cells[i, j].x == 5 || cells[i, j].x == 7))
                    {
                        cells[i, j].available = true;
                        cells[i, j].checker = null;
                        continue;
                    }
                    if(cells[i, j].y == 5 && (cells[i, j].x == 2 || cells[i, j].x == 4 || cells[i, j].x == 6 || cells[i, j].x == 8))
                    {
                        cells[i, j].available = true;
                        cells[i, j].checker = null;
                        continue;
                    }
                    if ((cells[i, j].y == 6 || cells[i, j].y == 8) && (cells[i, j].x == 1 || cells[i, j].x == 3 || cells[i, j].x == 5 || cells[i, j].x == 7))
                    {
                        cells[i, j].checker = new Checker();
                        cells[i, j].checker.team = "white";
                        cells[i, j].checker.x = cells[i, j].x;
                        cells[i, j].checker.y = cells[i, j].y;
                        cells[i, j].checker.name = Utilities.GetXLetter(cells[i, j].x) + cells[i, j].y;
                        cells[i, j].available = true;
                        continue;
                    }
                    if (cells[i, j].y == 7 && (cells[i, j].x == 2 || cells[i, j].x == 4 || cells[i, j].x == 6 || cells[i, j].x == 8))
                    {
                        cells[i, j].checker = new Checker();
                        cells[i, j].checker.team = "white";
                        cells[i, j].checker.x = cells[i, j].x;
                        cells[i, j].checker.y = cells[i, j].y;
                        cells[i, j].checker.name = Utilities.GetXLetter(cells[i, j].x) + cells[i, j].y;
                        cells[i, j].available = true;
                        continue;
                    }

                    cells[i, j].available = false;
                    cells[i, j].checker = null;
                }
            }
        }

        public void ShowBoard()
        {
            Console.WriteLine(GetStringBoard());
        }
        string GetStringBoard()
        {
            StringBuilder builder = new StringBuilder();


            for (int x = 1; x <= 8; x++)
            {
                builder.Append(Utilities.GetXLetter(x));
                Console.Write(Utilities.GetXLetter(x));
            }
            Console.Write("\n");
            builder.Append("\n");
            for (int i = 0; i < 8; i++)
            {
              
                for (int j = 0; j < 8; j++)
                {
                    builder.Append(Utilities.GetIcon(cells[i, j]));
                    Console.Write(Utilities.GetIcon(cells[i, j]));
                }
                Console.Write((i + 1)+"\n");
                builder.Append((i + 1) + "\n");
            }


            Console.WriteLine("\n");
            
            return builder.ToString();
        }
        public void MakeMove(string checkerName, string cell2move)
        {




        }

    }
}
