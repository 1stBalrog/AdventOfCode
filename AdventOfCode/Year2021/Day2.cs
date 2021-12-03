using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2021
{
    internal class Day2
    {
        internal static void Main()
        {
            var lines = File.ReadAllLines("Year2021/Day2_Input.txt");
            var depth = 0;
            var forward = 0;

            #region Part1
            //foreach (var line in lines)
            //{
            //    var split = line.Split(' ');

            //    if (split.Length != 2)
            //        continue;

            //    if (!int.TryParse(split[1], out var value))
            //        continue;

            //    switch (split[0])
            //    {
            //        case "forward":
            //            forward += value;
            //            break;
            //        case "down":
            //            depth += value;
            //            break;
            //        case "up":
            //            depth -= value;
            //            break;
            //        default:
            //            throw new ArgumentNullException(nameof(split));
            //    }
            //}
            #endregion

            #region Part2
            var aim = 0;

            foreach(var line in lines)
            {
                var split = line.Split(' ');

                if (split.Length != 2)
                    continue;

                if (!int.TryParse(split[1], out var value))
                    continue;

                switch (split[0])
                {
                    case "forward":
                        forward += value;
                        depth += aim * value;
                        break;
                    case "down":
                        aim += value;
                        break;
                    case "up":
                        aim -= value;
                        break;
                    default:
                        throw new ArgumentNullException(nameof(split));
                }
            }
            #endregion

            Console.WriteLine($"Forward: {forward}");
            Console.WriteLine($"Depth: {depth}");

            Console.WriteLine($"Multiplied: {forward * depth}");
        }
    }
}
