using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2021
{
    internal class Day14
    {
        private static int section = 4;
        private static int iterations = 10;

        internal static void Main()
        {
            var input = File.ReadAllLines("Year2021/Day14_Input.txt");

            #region Input
            var polymer = input[0];
            // 1 is an empty Line
            var rules = new List<(string section, string insert)>();
            for (int i = 2; i < input.Length; i++)
            {
                var split = input[i].Split("->");
                rules.Add((split[0].Trim(), split[1].Trim()));
            }
            #endregion

            #region Part1
            ////10 Polymerizations
            //for (int i = 0; i < 10; i++)
            //{
            //    var tmpPolymer = string.Empty;
            //    for (int j = 0; j < polymer.Length - 1; j++)
            //    {
            //        var section = polymer[j].ToString() + polymer[j + 1];
            //        var insert = rules.First(x => x.section == section).insert;
            //        tmpPolymer += polymer[j] + insert;
            //    }
            //    tmpPolymer += polymer.Last();
            //    polymer = tmpPolymer;
            //}

            //var groups = polymer.GroupBy(x => x).OrderBy(x => x.Count());
            //var least = groups.First();
            //var most = groups.Last();

            //var quantity = most.Count() - least.Count();
            //Console.WriteLine($"Quantity: {quantity}");
            #endregion

            #region Part2
            //Fill PolyList
            foreach (var rule in rules)
            {
                if (!PolyList.Contains(rule.section[0]))
                {
                    PolyList.Add(rule.section[0]);
                }

                if (!PolyList.Contains(rule.section[1]))
                {
                    PolyList.Add(rule.section[1]);
                }
            }

            FillSectionPolymerization(rules);

            var sectionCount = new Dictionary<char, long>();
            foreach (var poly in PolyList)
            {
                sectionCount.Add(poly, 0);
            }

            for (int i = 0; i < polymer.Length - 1; i++)
            {
                var section = polymer[i].ToString() + polymer[i + 1];
                var count = CountSections(section, 1);
                foreach (var poly in PolyList)
                {
                    sectionCount[poly] += count[poly];
                }
            }
            sectionCount[polymer.Last()] += 1;

            long most, least;
            most = least = sectionCount.First().Value;

            foreach (var poly in PolyList)
            {
                var val = sectionCount[poly];
                if (val > most)
                {
                    most = val;
                }
                if (val < least)
                {
                    least = val;
                }
            }

            var quantity = most - least;
            Console.WriteLine($"Quantity: {quantity}");
            #endregion
        }

        private static readonly Dictionary<string, string> SectionPolymerization = new();
        private static readonly Dictionary<string, string[]> SectionPolymerizationParts = new();

        private static readonly List<char> PolyList = new();
        private static readonly Dictionary<string, Dictionary<char, long>> SectionCounter = new();

        private static void FillSectionPolymerization(List<(string section, string insert)> rules)
        {
            foreach (var rule in rules)
            {
                var tmpPart = rule.section;
                for (int i = 0; i < section; i++)
                {
                    var tmpPolymer = string.Empty;
                    for (int j = 0; j < tmpPart.Length - 1; j++)
                    {
                        var section = tmpPart[j].ToString() + tmpPart[j + 1];
                        var insert = rules.First(x => x.section == section).insert;
                        tmpPolymer += tmpPart[j] + insert;
                    }

                    tmpPolymer += rule.section.Last();
                    tmpPart = tmpPolymer;
                }
                SectionPolymerization.Add(rule.section, tmpPart);

                var parts = new List<string>();
                for (int i = 0; i < tmpPart.Length - 1; i++)
                {
                    var section = tmpPart[i].ToString() + tmpPart[i + 1];
                    parts.Add(section);
                }
                SectionPolymerizationParts.Add(rule.section, parts.ToArray());
            }
        }

        private static Dictionary<char, long> CountSections(string polymer, int depth)
        {
            if (SectionCounter.TryGetValue(polymer + depth, out var result))
            {
                return result;
            }

            //Initialize
            var sectionCount = new Dictionary<char, long>();
            foreach (var poly in PolyList)
            {
                sectionCount.Add(poly, 0);
            }

            if (SectionCounter.TryGetValue(polymer + depth, out var count))
            {
                foreach (var poly in PolyList)
                {
                    sectionCount[poly] += count[poly];
                }
                return sectionCount;
            }

            if (depth < iterations)
            {
                var sections = SectionPolymerizationParts[polymer];
                foreach (var section in sections)
                {
                    var subCount = CountSections(section, depth + 1);

                    foreach (var poly in PolyList)
                    {
                        sectionCount[poly] += subCount[poly];
                    }
                }
                //sectionCount[polymer.Last()]++;
            }
            else
            {
                var sections = SectionPolymerization[polymer];
                foreach (var section in sections)
                {
                    sectionCount[section]++;
                }
                sectionCount[polymer.Last()]--;
            }

            SectionCounter.Add(polymer + depth, sectionCount);
            return sectionCount;
        }
    }
}
