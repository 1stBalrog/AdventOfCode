using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2021
{
    internal class Day13
    {
        internal static void Main()
        {
            var input = File.ReadAllLines("Year2021/Day13_Input.txt");

            #region Input
            var dots = new List<(int x, int y)>();
            var folds = new List<(string direction, int line)>();
            foreach (var line in input)
            {
                //Empty line
                if (string.IsNullOrEmpty(line))
                    continue;

                if (line.StartsWith("fold along x="))
                {
                    folds.Add(("x", Convert.ToInt32(line.Replace("fold along x=", ""))));
                    continue;
                }
                if (line.StartsWith("fold along y="))
                {
                    folds.Add(("y", Convert.ToInt32(line.Replace("fold along y=", ""))));
                    continue;
                }

                var split = line.Split(',');
                dots.Add((Convert.ToInt32(split[0]), Convert.ToInt32(split[1])));
            }
            var x = dots.Max(x => x.x);
            var y = dots.Max(x => x.y);

            var map = new bool[y + 1][];
            for (var i = 0; i <= y; i++)
            {
                map[i] = new bool[x + 1];
            }
            foreach (var dot in dots)
            {
                map[dot.y][dot.x] = true;
            }
            #endregion

            #region Part1
            ////Visualize(map, x, y, "Original map:");

            //var dotsVisible = 0;
            //foreach (var fold in folds)
            //{
            //    if (fold.direction == "y")
            //    {
            //        for (int i = 0; i < fold.line; i++)
            //        {
            //            for (int j = 0; j <= x; j++)
            //            {
            //                map[i][j] = map[i][j] || map[y - i][j];
            //                if (map[i][j])
            //                    dotsVisible++;
            //            }
            //        }
            //        //Visualize(map, x, fold.line, "After first Fold");
            //    }
            //    else // x
            //    {
            //        for (int i = 0; i <= y; i++)
            //        {
            //            for (int j = 0; j < fold.line; j++)
            //            {
            //                map[i][j] = map[i][j] || map[i][x - j];
            //                if (map[i][j])
            //                    dotsVisible++;
            //            }
            //        }
            //        //Visualize(map, fold.line, y, "After second Fold");
            //    }

            //    //Only the first Fold
            //    break;
            //}

            //Console.WriteLine($"Dots visible: {dotsVisible}");
            #endregion

            #region Part2
            int lastFoldX = x + 1;
            int lastFoldY = y + 1;
            //Visualize(map, x, y, "0 Original map");
            VisualizeFile(map, x, y, "0 Original map");

            int count = 0;
            foreach (var fold in folds)
            {
                if (fold.direction == "y")
                {
                    for (int i = 0; i < fold.line; i++)
                    {
                        for (int j = 0; j < lastFoldX; j++)
                        {
                            map[i][j] = map[i][j] || map[lastFoldY - 1 - i][j];
                        }
                    }
                    lastFoldY = fold.line;
                }
                else // x
                {
                    for (int i = 0; i < lastFoldY; i++)
                    {
                        for (int j = 0; j < fold.line; j++)
                        {
                            map[i][j] = map[i][j] || map[i][lastFoldX - 1 - j];
                        }
                    }
                    lastFoldX = fold.line;
                }

                //Visualize(map, lastFoldX > x ? x : lastFoldX, lastFoldY > y ? y : lastFoldY, $"{++count} Fold");
                VisualizeFile(map, lastFoldX > x ? x : lastFoldX, lastFoldY > y ? y : lastFoldY, $"{++count} Fold");
            }

            Visualize(map, lastFoldX, lastFoldY, "Code:");
            #endregion
        }

        private static void Visualize(bool[][] map, int x, int y, string text)
        {
            Console.WriteLine(text);
            //Visualize
            for (var i = 0; i <= y; i++)
            {
                for (int j = 0; j <= x; j++)
                {
                    Console.Write(map[i][j] ? "#" : ".");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void VisualizeFile(bool[][] map, int x, int y, string text)
        {
            Console.WriteLine(text);
            //Visualize
            var list = new List<string>();
            for (var i = 0; i <= y; i++)
            {
                list.Add(string.Join("", map[i].Take(x).Select(x => x ? "#" : ".")));
            }

            File.WriteAllLines(text, list.ToArray());
        }
    }
}
