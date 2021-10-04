using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersFinal
{
    class CheckersBoard
    {
        public Cell[,] cells;
        public bool jumpneed;
        public Cell[] GoldWay = new Cell[8];
        public Cell[] DoubleWay_h7b1 = new Cell[7];
        public Cell[] DoubleWay_g8a2 = new Cell[7];
        public Cell[] TripleWay_h3f1 = new Cell[3];
        public Cell[] TripleWay_c8a6 = new Cell[3];
        public Cell[] TripleWay_a6f1 = new Cell[6];
        public Cell[] TripleWay_c8h3 = new Cell[6];
        public Cell[] UltraWay_h5d1  = new Cell[5];
        public Cell[] UltraWay_e8a4  = new Cell[5];
        public Cell[] UltraWay_a4d1  = new Cell[4];
        public Cell[] UltraWay_e8h5  = new Cell[4];
        public CheckersBoard()
        {
            CreateCells();
            CreateCheckers();
            CreateWays();
            ShowBoard();
        }

        private void CreateWays()
        {
            GoldWay        = new Cell[] { GetCell("a8"), GetCell("b7"), GetCell("c6"), GetCell("d5"), GetCell("e4"), GetCell("f3"), GetCell("g2"), GetCell("h1") };
            DoubleWay_g8a2 = new Cell[] { GetCell("g8"), GetCell("f7"), GetCell("e6"), GetCell("d5"), GetCell("c4"), GetCell("b3"), GetCell("a2") };
            DoubleWay_h7b1 = new Cell[] { GetCell("h7"), GetCell("g6"), GetCell("f5"), GetCell("e4"), GetCell("d3"), GetCell("c2"), GetCell("b1") };
            TripleWay_a6f1 = new Cell[] { GetCell("a6"), GetCell("b5"), GetCell("c4"), GetCell("d3"), GetCell("e2"), GetCell("f1") };
            TripleWay_c8h3 = new Cell[] { GetCell("c8"), GetCell("d7"), GetCell("e6"), GetCell("f5"), GetCell("g4"), GetCell("h3") };
            TripleWay_c8a6 = new Cell[] { GetCell("c8"), GetCell("b7"), GetCell("a6") };
            TripleWay_h3f1 = new Cell[] { GetCell("h3"), GetCell("g2"), GetCell("f1") };
            UltraWay_e8a4  = new Cell[] { GetCell("e8"), GetCell("d7"), GetCell("c6"), GetCell("b5"), GetCell("a4") };
            UltraWay_h5d1  = new Cell[] { GetCell("h5"), GetCell("g4"), GetCell("f3"), GetCell("e2"), GetCell("d1") };
            UltraWay_a4d1  = new Cell[] { GetCell("a4"), GetCell("b3"), GetCell("c2"), GetCell("d1") };
            UltraWay_e8h5  = new Cell[] { GetCell("e8"), GetCell("f7"), GetCell("g6"), GetCell("h5") };
        }

        public void CreateCells()
        {
            cells = new Cell[8,8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    cells[i, j] = new Cell();
                    cells[i, j].x = j + 1;
                    cells[i, j].y = i + 1;
                    cells[i,j].name = Utilities.GetXLetter(cells[i, j].x) + cells[i, j].y;
                    cells[i, j].checker = null;
                    if (i % 2 == 0 && j % 2 == 0)
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
                        cells[i, j].checker = new Checker("black");
                        cells[i, j].checker.x = cells[i, j].x;
                        cells[i, j].checker.y = cells[i, j].y;
                        cells[i, j].checker.name = Utilities.GetXLetter(cells[i, j].x)+ cells[i, j].y;
                        cells[i, j].available = true;
                        continue;
                    }
                    if(cells[i,j].y==2 && (cells[i,j].x==1 || cells[i,j].x==3 || cells[i, j].x == 5 || cells[i, j].x == 7))
                    {
                        cells[i, j].checker = new Checker("black");
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
                        cells[i, j].checker = new Checker("white");
                        cells[i, j].checker.x = cells[i, j].x;
                        cells[i, j].checker.y = cells[i, j].y;
                        cells[i, j].checker.name = Utilities.GetXLetter(cells[i, j].x) + cells[i, j].y;
                        cells[i, j].available = true;
                        continue;
                    }
                    if (cells[i, j].y == 7 && (cells[i, j].x == 2 || cells[i, j].x == 4 || cells[i, j].x == 6 || cells[i, j].x == 8))
                    {
                        cells[i, j].checker = new Checker("white");
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
            }
            builder.Append("\n");
            for (int i = 0; i < 8; i++)
            {
              
                for (int j = 0; j < 8; j++)
                {
                    builder.Append(Utilities.GetIcon(cells[i, j]));
                }
                builder.Append((i + 1) + "\n");
            }
            return builder.ToString();
        }
        public void MakeMove(string checkerName, string cell2move,string team)
        {
            if(jumpneed==true)
            {
                for(int i=0;i<8;i++)
                {
                    for(int j=0;j<8;j++)
                    {
                        if(cells[i,j].checker!=null)
                        {
                            if (cells[i, j].checker.mustEat == true)
                                cells[i, j].checker = null;
                            if (cells[i, j].checker.need2eat == true)
                                cells[i, j].checker = null;
                        }
                        if (cells[i, j].available2fight == true)
                            cells[i, j].checker = new Checker(team);


                    }
                }
            }
            else
            {
                GetCell(checkerName).checker = null;
                GetCell(cell2move).checker = new Checker(team);


            }


        }
        public ref Cell GetCell( string cellName)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (cells[i, j].name == cellName)
                    {
                        return ref cells[i, j];
                    }

                }
            }
            Console.WriteLine("Ошибка, клетки с таким именем не существует");
            return ref cells[0, 0]; //костыль
        }
        public void nullAtributes()// надо исправить 
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    







                    cells[i, j].available2fight = false;
                    cells[i, j].available2move = false;
                    if(cells[i,j].checker!=null)
                    {
                        cells[i, j].checker.mustEat = false;
                        cells[i, j].checker.need2eat = false;
                    }
                }
            }
        }

    }
}
