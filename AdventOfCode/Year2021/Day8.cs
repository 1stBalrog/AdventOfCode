using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2021
{
    internal class Day8
    {
        internal static void Main()
        {
            var input = File.ReadAllLines("Year2021/Day8_Input.txt");

            #region Part1
            //var output = input.SelectMany(x => x.Split(" | ")[1].Split(' '));
            //var count = output.Count(x => x.Length == 2 || x.Length == 3 || x.Length == 4 || x.Length == 7);
            //Console.WriteLine($"Count: {count}");
            #endregion

            #region Part2
            var entries = new List<long>();
            foreach (var line in input)
            {
                var split = line.Split(" | ");
                var patterns = split[0].Split(' ');
                var output = split[1].Split(' ').Select(x => x.OrderBy(y => y).ToArray()).ToArray();

                var one = patterns.First(x => x.Length == 2).OrderBy(x => x).ToArray();
                var seven = patterns.First(x => x.Length == 3).OrderBy(x => x).ToArray();
                var four = patterns.First(x => x.Length == 4).OrderBy(x => x).ToArray();
                var eight = patterns.First(x => x.Length == 7).OrderBy(x => x).ToArray();

                var sixNineZero = patterns.Where(x => x.Length == 6).ToArray();
                var twoThreeFive = patterns.Where(x => x.Length == 5).ToArray();

                char[] six, nine, zero;
                six = nine = zero = Array.Empty<char>();
                foreach (var element in sixNineZero)
                {
                    var except = element.Intersect(one);
                    if (except.Count() == 1)
                    {
                        six = element.OrderBy(x => x).ToArray();
                        continue;
                    }
                    var intersect = element.Intersect(four);
                    if (intersect.Count() == 4)
                    {
                        nine = element.OrderBy(x => x).ToArray();
                        continue;
                    }
                    zero = element.OrderBy(x => x).ToArray();
                }

                var c = zero.Except(six).First();
                var e = zero.Except(nine).First();

                char[] two, three, five;
                two = three = five = Array.Empty<char>();
                foreach (var element in twoThreeFive)
                {
                    if (!element.Contains(c))
                    {
                        five = element.OrderBy(x => x).ToArray();
                        continue;
                    }
                    if (element.Contains(e))
                    {
                        two = element.OrderBy(x => x).ToArray();
                        continue;
                    }
                    three = element.OrderBy(x => x).ToArray();
                }

                char[] lineNumber = new char[4];
                for (int i = 0; i < output.Length; i++)
                {
                    var element = new string(output[i]);
                    char number;
                    if (element == new string(zero))
                        number = '0';
                    else if (element == new string(one))
                        number = '1';
                    else if (element == new string(two))
                        number = '2';
                    else if (element == new string(three))
                        number = '3';
                    else if (element == new string(four))
                        number = '4';
                    else if (element == new string(five))
                        number = '5';
                    else if (element == new string(six))
                        number = '6';
                    else if (element == new string(seven))
                        number = '7';
                    else if (element == new string(eight))
                        number = '8';
                    else
                        number = '9';

                    lineNumber[i] = number;
                }
                entries.Add(Convert.ToInt32(new string(lineNumber)));
            }

            var totalSum = entries.Sum();
            Console.WriteLine($"Total sum: {totalSum}");
            #endregion
        }
    }
}
