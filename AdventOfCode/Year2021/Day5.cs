using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2021
{
    internal class Day5
    {
        internal static void Main()
        {
            #region Input
            var lines = File.ReadAllLines("Year2021/Day5_Input.txt");

            var vents = lines.Select(line => new Vent(line)).ToList();
            #endregion

            #region Part1
            //var part1List = vents.Where(x => x.IsHorizontal || x.IsVertical).ToList();

            //var xValues = part1List.SelectMany(x => new[] { x.X1, x.X2 }).ToList();
            //var yValues = part1List.SelectMany(x => new[] { x.X1, x.X2 }).ToList();

            ////Not interesting, starting with 0,0 anyway
            //var lowestX = xValues.Min();
            //var lowestY = yValues.Min();

            //var highestX = xValues.Max();
            //var highestY = yValues.Max();

            ////Initialize Grid
            //var grid = new int[highestY + 1][];
            //for (int y = 0; y <= highestY; y++)
            //{
            //    grid[y] = new int[highestX + 1];
            //    for (int x = 0; x <= highestX; x++)
            //    {
            //        grid[y][x] = 0;
            //    }
            //}

            //foreach (var line in part1List)
            //{
            //    if (line.IsVertical)
            //    {
            //        for (int y = line.LowY; y <= line.HighY; y++)
            //        {
            //            grid[y][line.X1] += 1;
            //        }
            //    }
            //    if (line.IsHorizontal)
            //    {
            //        for (int x = line.LowX; x <= line.HighX; x++)
            //        {
            //            grid[line.Y1][x] += 1;
            //        }
            //    }
            //}

            //////Visualize for Example
            ////var count = 0;
            ////for (int y = 0; y <= highestY; y++)
            ////{
            ////    for (int x = 0; x <= highestX; x++)
            ////    {
            ////        var val = grid[y][x];
            ////        if (val > 1)
            ////            count++;
            ////        Console.Write(val == 0 ? "." : val);
            ////    }
            ////    Console.WriteLine();
            ////}
            ////Console.WriteLine();
            ////Console.WriteLine($"Overlaps: {count}");

            //var result = grid.Select(x => x.Where(y => y > 1).Count()).Sum();

            //Console.WriteLine($"Overlaps: {result}");
            #endregion

            #region Part2
            var xValues = vents.SelectMany(x => new[] { x.X1, x.X2 }).ToList();
            var yValues = vents.SelectMany(x => new[] { x.X1, x.X2 }).ToList();

            //Not interesting, starting with 0,0 anyway
            var lowestX = xValues.Min();
            var lowestY = yValues.Min();

            var highestX = xValues.Max();
            var highestY = yValues.Max();

            //Initialize Grid
            var grid = new int[highestY + 1][];
            for (int y = 0; y <= highestY; y++)
            {
                grid[y] = new int[highestX + 1];
                for (int x = 0; x <= highestX; x++)
                {
                    grid[y][x] = 0;
                }
            }

            foreach (var line in vents)
            {
                if (line.IsVertical)
                {
                    for (int y = line.LowY; y <= line.HighY; y++)
                    {
                        grid[y][line.X1] += 1;
                    }
                }
                else if (line.IsHorizontal)
                {
                    for (int x = line.LowX; x <= line.HighX; x++)
                    {
                        grid[line.Y1][x] += 1;
                    }
                }
                else //Diagonal
                {
                    switch (line.Diagonal)
                    {
                        case Diagonal.NorthEast:
                            var neCount = line.X1 - line.X2;
                            for (int ne = 0; ne <= neCount; ne++)
                            {
                                grid[line.Y2 - ne][line.X2 + ne] += 1;
                            }
                            break;
                        case Diagonal.NorthWest:
                            var nwCount = line.X1 - line.X2;
                            for (int nw = 0; nw <= nwCount; nw++)
                            {
                                grid[line.Y2 + nw][line.X2 + nw] += 1;
                            }
                            break;
                        case Diagonal.SouthEast:
                            var seCount = line.X2 - line.X1;
                            for (int se = 0; se <= seCount; se++)
                            {
                                grid[line.Y1 + se][line.X1 + se] += 1;
                            }
                            break;
                        case Diagonal.SouthWest:
                            var swCount = line.X2 - line.X1;
                            for (int sw = 0; sw <= swCount; sw++)
                            {
                                grid[line.Y2 + sw][line.X2 - sw] += 1;
                            }
                            break;
                        case Diagonal.None:
                        default:
                            break;
                    }
                }
            }

            ////Visualize for Example
            //for (int y = 0; y <= highestY; y++)
            //{
            //    for (int x = 0; x <= highestX; x++)
            //    {
            //        var val = grid[y][x];
            //        Console.Write(val == 0 ? "." : val);
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine();

            var result = grid.Select(x => x.Where(y => y > 1).Count()).Sum();

            Console.WriteLine($"Overlaps: {result}");
            #endregion
        }

        private class Vent
        {
            public Vent(string line)
            {
                var split = line.Split(" -> ");
                var vs1 = split[0].Split(',').Select(x => Convert.ToInt32(x)).ToArray();
                var vs2 = split[1].Split(',').Select(x => Convert.ToInt32(x)).ToArray();

                Text = line;

                X1 = vs1[0];
                Y1 = vs1[1];

                X2 = vs2[0];
                Y2 = vs2[1];

                if (!IsHorizontal && !IsVertical)
                {
                    //Diagonal
                    if (X1 > X2) //North
                    {
                        if (Y1 > Y2) //West
                        {
                            Diagonal = Diagonal.NorthWest;
                        }
                        else
                        {
                            Diagonal = Diagonal.NorthEast;
                        }
                    }
                    else //South
                    {
                        if (Y1 > Y2) //West
                        {
                            Diagonal = Diagonal.SouthWest;
                        }
                        else
                        {
                            Diagonal = Diagonal.SouthEast;
                        }
                    }
                }
            }


            public int X1 { get; set; }
            public int Y1 { get; set; }

            public int X2 { get; set; }
            public int Y2 { get; set; }

            public bool IsHorizontal => Y1 == Y2;
            public bool IsVertical => X1 == X2;

            public int LowX => X1 > X2 ? X2 : X1;
            public int HighX => X1 > X2 ? X1 : X2;

            public int LowY => Y1 > Y2 ? Y2 : Y1;
            public int HighY => Y1 > Y2 ? Y1 : Y2;

            public Diagonal Diagonal { get; set; }

            private string Text { get; set; }
            public override string ToString() => Text;

        }

        private enum Diagonal
        {
            None,
            NorthEast,
            NorthWest,
            SouthEast,
            SouthWest,
        }
    }
}
