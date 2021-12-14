using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2021
{
    internal class Day11
    {
        internal static void Main()
        {
            var input = File.ReadAllLines("Year2021/Day11_Input.txt");

            #region Part1
            //var x = input.Count();
            //var y = input.First().Count();

            //var map = new int[x][];
            //for (var i = 0; i < x; i++)
            //{
            //    map[i] = input[i].Select(x => Convert.ToInt32(x.ToString())).ToArray();
            //}

            ////Visualize(map, x, y, "Before any steps:");

            //long flashes = 0;
            ////Perform 100 Steps
            //for (int l = 0; l < 100; l++)
            //{
            //    //Increase all by 1
            //    for (var i = 0; i < x; i++)
            //    {
            //        for (int j = 0; j < y; j++)
            //        {
            //            map[i][j]++;
            //        }
            //    }

            //    flashes += CheckFlashes(ref map, x, y);

            //    //Visualize(map, x, y, $"After step {l + 1}:");
            //}

            //Console.WriteLine($"Total flashes: {flashes}");
            #endregion

            #region Part2
            var x = input.Count();
            var y = input.First().Count();

            var map = new int[x][];
            for (var i = 0; i < x; i++)
            {
                map[i] = input[i].Select(x => Convert.ToInt32(x.ToString())).ToArray();
            }

            //Visualize(map, x, y, "Before any steps:");

            int steps = 0;
            while (true)
            {
                steps++;

                //Increase all by 1
                for (var i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        map[i][j]++;
                    }
                }

                if (CheckFlashes(ref map, x, y) == 100)
                {
                    break;
                }

                //Visualize(map, x, y, $"After step {l + 1}:");
            }

            Console.WriteLine($"Total Steps: {steps}");
            #endregion
        }

        private static long CheckFlashes(ref int[][] map, int x, int y)
        {
            var flashes = new HashSet<int>();

            bool flashFound;
            do
            {
                flashFound = false;
                for (var i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        if (map[i][j] > 9 && !flashes.Contains(i * 1000 + j))
                        {
                            flashes.Add(i * 1000 + j);
                            flashFound = true;

                            //Try increase surrounding Octopuses
                            TryIncrease(ref map, i, j - 1);
                            TryIncrease(ref map, i, j + 1);
                            TryIncrease(ref map, i - 1, j - 1);
                            TryIncrease(ref map, i - 1, j);
                            TryIncrease(ref map, i - 1, j + 1);
                            TryIncrease(ref map, i + 1, j - 1);
                            TryIncrease(ref map, i + 1, j);
                            TryIncrease(ref map, i + 1, j + 1);
                        }
                    }
                }
            } while (flashFound);

            //Reset Octopuses
            for (var i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (map[i][j] > 9)
                    {
                        map[i][j] = 0;
                    }
                }
            }

            return flashes.Count();
        }

        private static void TryIncrease(ref int[][] map, int i, int j)
        {
            try
            {
                map[i][j]++;
            }
            catch
            {
                //Do nothing
            }
        }

        private static void Visualize(int[][] map, int x, int y, string text)
        {
            Console.WriteLine(text);
            //Visualize
            for (var i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write(map[i][j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
