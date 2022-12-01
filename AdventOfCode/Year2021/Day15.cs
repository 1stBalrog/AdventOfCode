using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2021
{
    internal class Day15
    {
        internal static void Main()
        {
            var input = File.ReadAllLines("Year2021/Day15_Input.txt");

            #region Input
            var x = input.Count();
            var y = input.First().Count();

            var map = new int[x][];
            for (var i = 0; i < x; i++)
            {
                map[i] = input[i].Select(x => Convert.ToInt32(x.ToString())).ToArray();
            }

            //Visualize(map, x, y, "Map");
            #endregion

            #region Part1
            //Startpoint = Top Left (0,0)
            //Endpoint = Bottom Right (x,y)

            var startpoint = 0;

            //Console.WriteLine($"Risk: {risk}");
            #endregion

            #region Part2
            #endregion
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
