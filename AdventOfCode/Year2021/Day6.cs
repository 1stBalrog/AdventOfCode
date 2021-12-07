using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2021
{
    internal class Day6
    {
        internal static void Main()
        {
            var input = File.ReadAllLines("Year2021/Day6_Input.txt").First().Split(',').Select(x => Convert.ToInt32(x)).ToList();

            #region Part1
            //for (int i = 0; i < 80; i++)
            //{
            //    var newFish = input.Count(x => x == 0);
            //    input = input.Select(x => x == 0 ? 6 : x - 1).ToList();

            //    input.AddRange(Enumerable.Repeat(8, newFish).ToArray());
            //}

            //var totalFish = input.Count();

            //Console.WriteLine($"Total: {totalFish}");
            #endregion

            #region Part2
            //Performance-Issues from ~200 away to 256.
            //Solution: Split in 2 parts of 128 each
            for (int i = 0; i < 128; i++)
            {
                var newFish = input.Count(x => x == 0);
                input = input.Select(x => x == 0 ? 6 : x - 1).ToList();

                input.AddRange(Enumerable.Repeat(8, newFish).ToArray());
            }

            var groups = input.GroupBy(x => x);
            var countArray = Enumerable.Repeat(0l, groups.Count()).ToArray();
            var count = 0;
            foreach (var group in groups)
            {
                var list = new List<long>();
                list.Add(group.Key);
                for (int i = 0; i < 128; i++)
                {
                    var newFish = list.Count(x => x == 0);
                    list = list.Select(x => x == 0 ? 6 : x - 1).ToList();

                    list.AddRange(Enumerable.Repeat(8l, newFish).ToArray());
                }
                countArray[count] = (long)list.Count * (long)group.Count();
                count++;
            }

            var total = countArray.Sum();
            Console.WriteLine($"Total: {total}");
            #endregion
        }
    }
}
//1,1,1,3,3,2,1,1,1,1,1,4,4,1,4,1,4,1,1,4,1,1,1,3,3,2,3,1,2,1,1,1,1,1,1,1,3,4,1,1,4,3,1,2,3,1,1,1,5,2,1,1,1,1,2,1,2,5,2,2,1,1,1,3,1,1,1,4,1,1,1,1,1,3,3,2,1,1,3,1,4,1,2,1,5,1,4,2,1,1,5,1,1,1,1,4,3,1,3,2,1,4,1,1,2,1,4,4,5,1,3,1,1,1,1,2,1,4,4,1,1,1,3,1,5,1,1,1,1,1,3,2,5,1,5,4,1,4,1,3,5,1,2,5,4,3,3,2,4,1,5,1,1,2,4,1,1,1,1,2,4,1,2,5,1,4,1,4,2,5,4,1,1,2,2,4,1,5,1,4,3,3,2,3,1,2,3,1,4,1,1,1,3,5,1,1,1,3,5,1,1,4,1,4,4,1,3,1,1,1,2,3,3,2,5,1,2,1,1,2,2,1,3,4,1,3,5,1,3,4,3,5,1,1,5,1,3,3,2,1,5,1,1,3,1,1,3,1,2,1,3,2,5,1,3,1,1,3,5,1,1,1,1,2,1,2,4,4,4,2,2,3,1,5,1,2,1,3,3,3,4,1,1,5,1,3,2,4,1,5,5,1,4,4,1,4,4,1,1,2
