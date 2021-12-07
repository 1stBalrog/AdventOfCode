using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2021
{
    internal class Day1
    {
        internal static void Main()
        {
            var lines = File.ReadAllLines("Year2021/Day1_lines.txt").Select(x => Convert.ToInt32(x)).ToArray();

            #region Part1
            //var increased = 0;
            //for (int i = 1; i < lines.Length; i++)
            //{
            //    if (lines[i] > lines[i - 1])
            //        increased++;
            //}

            //Console.WriteLine(increased);
            #endregion

            #region Part2
            var windows = new List<int>();
            for (int i = 0; i < lines.Length-2; i++)
            {
                var window = lines[i] + lines[i + 1] + lines[i + 2];
                windows.Add(window);
            }

            var increased = 0;
            for (int i = 1; i < windows.Count; i++)
            {
                if (windows[i] > windows[i - 1])
                    increased++;
            }

            Console.WriteLine(increased);
            #endregion
        }
    }
}
