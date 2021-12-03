using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2021
{
    internal class Day3
    {
        internal static void Main()
        {
            var lines = File.ReadAllLines("Year2021/Day3_Input.txt");

            var length = lines.First().Length;
            if (!lines.All(l => l.Length == length))
                throw new ArgumentException();

            #region Part1
            //string gamma = "";
            //string epsilon = "";

            //for (int i = 0; i < length; i++)
            //{
            //    var list = lines.Select(x => x[i]).ToList();
            //    var zeroCount = list.Count(x => x == '0');
            //    var oneCount = list.Count - zeroCount;

            //    if (zeroCount > oneCount)
            //    {
            //        gamma += "0";
            //        epsilon += "1";
            //    }
            //    else
            //    {
            //        gamma += "1";
            //        epsilon += "0";
            //    }
            //}

            //var gammaValue = Convert.ToInt32(gamma, 2);
            //var epsilonValue = Convert.ToInt32(epsilon, 2);

            //Console.WriteLine($"Gamma: {gammaValue}");
            //Console.WriteLine($"Epsilon: {epsilonValue}");

            //Console.WriteLine($"Multiplied: {gammaValue * epsilonValue}");
            #endregion

            #region Part2
            var oxygen = lines;
            for (int i = 0; i < length; i++)
            {
                if (oxygen.Count() == 1)
                    break;

                var list = oxygen.Select(x => x[i]).ToList();
                var zeroCount = list.Count(x => x == '0');
                var oneCount = list.Count - zeroCount;

                //Oxygen: If Same number, keep '1'
                if (zeroCount > oneCount)
                {
                    oxygen = oxygen.Where(x => x[i] == '0').ToArray();
                }
                else
                {
                    oxygen = oxygen.Where(x => x[i] == '1').ToArray();
                }
            }

            var co2 = lines;
            for (int i = 0; i < length; i++)
            {
                if (co2.Count() == 1)
                    break;

                var list = co2.Select(x => x[i]).ToList();
                var zeroCount = list.Count(x => x == '0');
                var oneCount = list.Count - zeroCount;

                //Oxygen: If Same number, keep '1'
                if (zeroCount > oneCount)
                {
                    co2 = co2.Where(x => x[i] == '1').ToArray();
                }
                else
                {
                    co2 = co2.Where(x => x[i] == '0').ToArray();
                }
            }

            var oxygenValue = Convert.ToInt32(oxygen[0], 2);
            var co2Value = Convert.ToInt32(co2[0], 2);

            Console.WriteLine($"Oxygen: {oxygenValue}");
            Console.WriteLine($"CO2: {co2Value}");

            Console.WriteLine($"Multiplied: {oxygenValue * co2Value}");
            #endregion
        }
    }
}
