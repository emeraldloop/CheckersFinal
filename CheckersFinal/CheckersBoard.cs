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
        public Cell[] GoldWay = new Cell[8];       // Way - это одна из диагоналей по которым едят/ходят шашки
        public Cell[] DoubleWay_h7b1 = new Cell[7];// Way нужны для проверки доски на бои, свободные ходы
        public Cell[] DoubleWay_g8a2 = new Cell[7];// Каждый путь содержит ссылки на клетки доски
        public Cell[] TripleWay_h3f1 = new Cell[3];
        public Cell[] TripleWay_c8a6 = new Cell[3];
        public Cell[] TripleWay_a6f1 = new Cell[6];
        public Cell[] TripleWay_c8h3 = new Cell[6];
        public Cell[] UltraWay_h5d1  = new Cell[5];
        public Cell[] UltraWay_e8a4  = new Cell[5];
        public Cell[] UltraWay_a4d1  = new Cell[4];
        public Cell[] UltraWay_e8h5  = new Cell[4];
        public Cell[] miniDoubleWay_a2b1 = new Cell[2];//два пути ниже участвуют только в ходах
        public Cell[] miniDoubleWay_g8h7 = new Cell[2];
        public CheckersBoard()
        {
            CreateCells();
            CreateCheckers();
            CreateWays();
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
            miniDoubleWay_a2b1 = new Cell[] { GetCell("a2"), GetCell("b1") };
            miniDoubleWay_g8h7 = new Cell[] { GetCell("g8"), GetCell("h7") };
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
                    if( (cells[i,j].y==1 || cells[i,j].y==3) && (cells[i, j].x%2==0))
                    {
                        cells[i, j].checker = new Checker("black", j + 1, i + 1);
                        cells[i, j].available = true;
                        continue;
                    }
                    if(cells[i,j].y==2 && (cells[i,j].x%2!=0))
                    {
                        cells[i, j].checker = new Checker("black", j + 1, i + 1);
                        cells[i, j].available = true;
                        continue;
                    }
                    if (cells[i, j].y==4 && (cells[i, j].x%2!= 0))
                    {
                        cells[i, j].available = true;
                        cells[i, j].checker = null;
                        continue;
                    }
                    if(cells[i, j].y == 5 && (cells[i, j].x % 2 == 0))
                    {
                        cells[i, j].available = true;
                        cells[i, j].checker = null;
                        continue;
                    }
                    if ((cells[i, j].y == 6 || cells[i, j].y == 8) && (cells[i, j].x % 2 != 0))
                    {
                        cells[i, j].checker = new Checker("white", j + 1, i + 1);
                        cells[i, j].available = true;
                        continue;
                    }
                    if (cells[i, j].y == 7 && (cells[i, j].x % 2 == 0))
                    {
                        cells[i, j].checker = new Checker("white", j + 1, i + 1);
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
        public bool MakeMove(string checkerName, string cell2move,string team)
        {
            if(jumpneed==true)
            {
                if (GoWays(checkerName, cell2move, team))
                {
                    return true;
                }
                else
                    return false;
            }
            else 
            {
                for(int i=0;i<8;i++)
                {
                    for(int j=0;j<8;j++)
                    {
                        if(cells[i, j].name ==cell2move)
                        {   
                            if (GetCell(checkerName).checker!=null&&GetCell(checkerName).checker.queen==true)
                            {
                                cells[i, j].checker = new Checker(team, j + 1, i + 1);
                                cells[i, j].checker.queen = true;

                            }
                            else
                            {
                                cells[i, j].checker = new Checker(team, j + 1, i + 1);
                                if (cells[i, j].y == 1 && (cells[i, j].x == 2 || cells[i, j].x == 4 || cells[i, j].x == 6 || cells[i, j].x == 8))
                                    cells[i, j].checker.queen = true;
                                if (cells[i, j].y == 8 && (cells[i, j].x == 1 || cells[i, j].x == 3 || cells[i, j].x == 5 || cells[i, j].x == 7))
                                    cells[i, j].checker.queen = true;
                            }
                            GetCell(checkerName).checker = null;
                            return true;
                        }
                        
                    }
                }
            }
            return false;

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
        public void nullAtributes()
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
        private bool GoWays(string checkerName,string cellName,string team)//for fights
        {
            if(goWay(ref GoldWay,team,checkerName,cellName) || goWay(ref DoubleWay_g8a2, team, checkerName, cellName)
                || goWay(ref DoubleWay_h7b1, team, checkerName, cellName) || goWay(ref TripleWay_a6f1, team, checkerName, cellName)
                || goWay(ref TripleWay_c8a6, team, checkerName, cellName) || goWay(ref TripleWay_c8h3, team, checkerName, cellName)
                || goWay(ref TripleWay_h3f1, team, checkerName, cellName) || goWay(ref UltraWay_a4d1, team, checkerName, cellName)
                || goWay(ref UltraWay_e8a4, team, checkerName, cellName)  || goWay(ref UltraWay_e8h5, team, checkerName, cellName)
                || goWay(ref UltraWay_h5d1, team, checkerName, cellName))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private bool goWay(ref Cell[] Way,string team, string checkerName, string cellName) //must fix!!!
        {
            for (int i = 0; i < Way.Length - 2; i++)
            {
                if(Way[i].checker!=null&& Way[i].checker.name==checkerName)
                {
                    if(Way[i].checker.queen==true)
                    {
                        for (int j = i; j < Way.Length; j++)
                        {
                            if(Way[j].name==cellName)
                            {
                                Way[j].checker = new Checker(team, Way[j].x, Way[j].y);
                                Way[j].checker.queen = true;
                                Way[j - 1].checker = null;
                                Way[i].checker = null;
                                if (Way[j].y == 1 && (Way[j].x == 2 || Way[j].x == 4 || Way[j].x == 6 || Way[j].x == 8))
                                    Way[j].checker.queen = true;
                                if (Way[j].y == 8 && (Way[j].x == 1 || Way[j].x == 3 || Way[j].x == 5 || Way[j].x == 7))
                                    Way[j].checker.queen = true;
                                return true;
                            }
                        }

                    }
                    else
                    if(Way[i+2].name==cellName && Way[i+1].checker!=null && Way[i+1].checker.need2eat==true)
                    {
                        Way[i + 2].checker = new Checker(team, Way[i + 2].x, Way[i + 2].y);
                        Way[i].checker = null;
                        Way[i + 1].checker = null;
                        if (Way[i+2].y == 1 && (Way[i+2].x == 2 || Way[i+2].x == 4 || Way[i+2].x == 6 || Way[i+2].x == 8))
                            Way[i+2].checker.queen = true;
                        if (Way[i+2].y == 8 && (Way[i+2].x == 1 || Way[i+2].x == 3 || Way[i+2].x == 5 || Way[i+2].x == 7))
                            Way[i+2].checker.queen = true;
                        return true;
                    }
                }
            }
            for (int i = Way.Length - 1; i > 1; i--)
            {
                if (Way[i].checker != null && Way[i].checker.name == checkerName)
                {
                    if(Way[i].checker.queen==true)
                    {
                        for (int j = i; j >= 0; j--)
                        {
                            if (Way[j].name == cellName)
                            {
                                Way[j].checker = new Checker(team, Way[j].x, Way[j].y);
                                Way[j].checker.queen = true;
                                Way[j + 1].checker = null;
                                Way[i].checker = null;
                                if (Way[j].y == 1 && (Way[j].x == 2 || Way[j].x == 4 || Way[j].x == 6 || Way[j].x == 8))
                                    Way[j].checker.queen = true;
                                if (Way[j].y == 8 && (Way[j].x == 1 || Way[j].x == 3 || Way[j].x == 5 || Way[j].x == 7))
                                    Way[j].checker.queen = true;
                                return true;
                            }
                        }
                    }
                    else
                    if (Way[i - 2].name == cellName && Way[i - 1].checker != null && Way[i - 1].checker.need2eat == true)
                    {
                        
                        Way[i - 2].checker = new Checker(team, Way[i - 2].x, Way[i - 2].y);
                        Way[i].checker = null;
                        Way[i - 1].checker = null;
                        
                        if (Way[i-2].y == 1 && (Way[i-2].x == 2 || Way[i-2].x == 4 || Way[i-2].x == 6 || Way[i-2].x == 8))
                            Way[i-2].checker.queen = true;
                        if (Way[i-2].y == 8 && (Way[i-2].x == 1 || Way[i-2].x == 3 || Way[i-2].x == 5 || Way[i-2].x == 7))
                            Way[i-2].checker.queen = true;
                        return true;
                    }
                }

            }
            return false;
        }

        public bool IsWin()
        {
            int white = 0;
            int black = 0;
            for(int i=0;i<8;i++)
            {
                for(int j=0;j<8;j++)
                {
                    if(cells[i,j].checker!=null)
                    {
                        if (cells[i, j].checker.team == "white")
                            white++;
                        else
                            black++;
                    }
                }
            }
            if(white==0&&black>0)
            {
                Console.WriteLine("Черные выиграли");
                return true;
            }
            if(black==0&&white>0)
            {
                Console.WriteLine("Белые выиграли");
                return true;
            }
            return false;
        }
    }
}
