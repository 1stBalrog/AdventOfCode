using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2021
{
    internal class Day7
    {
        internal static void Main()
        {
            var input = File.ReadAllLines("Year2021/Day7_Input.txt").First().Split(',').Select(x => Convert.ToInt32(x)).ToList();

            #region Part1
            //var positions = input.GroupBy(x => x).Select(x => new { x.Key, Count = x.Count() }).ToList();

            //int min = positions.Min(x => x.Key);
            //int max = positions.Max(x => x.Key);

            //var array = new int[max - min+1];
            //for (int i = min; i <= max; i++)
            //{
            //    var fuel = 0;
            //    foreach (var position in positions)
            //    {
            //        if (position.Key == i)
            //        {
            //            continue;
            //        }

            //        if (position.Key < i)
            //        {
            //            fuel += (i - position.Key) * position.Count;
            //        }
            //        else
            //        {
            //            fuel += (position.Key - i) * position.Count;
            //        }
            //    }
            //    array[i - min] = fuel;
            //}

            //var minFuel = array.Min();
            //Console.WriteLine($"Fuel required: {minFuel}");
            #endregion

            #region Part2
            var positions = input.GroupBy(x => x).Select(x => new { x.Key, Count = x.Count() }).ToList();

            int min = positions.Min(x => x.Key);
            int max = positions.Max(x => x.Key);

            var array = new long[max - min + 1];
            for (int i = min; i <= max; i++)
            {
                var fuel = 0l;
                foreach (var position in positions)
                {
                    if (position.Key == i)
                    {
                        continue;
                    }

                    int steps;
                    if (position.Key < i)
                    {
                        steps = i - position.Key;
                    }
                    else
                    {
                        steps = position.Key - i;
                    }

                    var answer = (steps * (steps + 1)) / 2;

                    fuel += answer * position.Count;
                }
                array[i - min] = fuel;
            }

            var minFuel = array.Min();
            Console.WriteLine($"Fuel required: {minFuel}");
            #endregion
        }
    }
}
