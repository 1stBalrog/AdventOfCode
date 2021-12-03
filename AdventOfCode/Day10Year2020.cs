using System.Diagnostics;

namespace AdventOfCode
{
    internal class Day10Year2020
    {
        internal static void Main()
        {
            #region Fix input values
            var values = Value.Input.ToList();

            // Add lowest and highest values
            values.Add(0);
            values.Add(values.Max() + 3);

            values.Sort();

            Value.Input = values.ToArray();
            Value.Max = values.Max();
            #endregion

            #region Part 1
            //var count1 = 0;
            //var count3 = 0;

            //foreach (var value in values)
            //{
            //    if (values.Contains(value + 1))
            //        count1++;
            //    else if (values.Contains(value + 2))
            //        continue;
            //    else if (values.Contains(value + 3))
            //        count3++;
            //}

            //Console.WriteLine($"1 Jolt: {count1}");
            //Console.WriteLine($"3 Jolt: {count3}");

            //Console.WriteLine($"1 Jolt multiplied by 3 Jolt: {count1 * count3}");
            #endregion

            #region Part 2
            var inverted = values.OrderByDescending(x => x).Skip(1);
            Value.Cache[Value.Max] = 1;

            foreach (var value in inverted)
            {
                long current = 0;
                for (int i = 1; i <= 3; i++)
                {
                    if (Value.Cache.TryGetValue(value + i, out var count))
                        current += count;
                }

                Value.Cache[value] = current;
            }

            Value.Count = Value.Cache[0];

            Console.WriteLine($"Possible Arrangements: {Value.Count}");
            #endregion
        }
        class Value
        {
            internal static long Count = 0;
            internal static int Max = 0;

            // Test input Small
            internal static int[] Input2 = new int[] { 1, 4, 5, 6, 7, 10, 11, 12, 15, 16, 19 };

            // Test input Large
            internal static int[] Input3 = new int[] { 1, 2, 3, 4, 7, 8, 9, 10, 11, 14, 17, 18, 19, 20, 23, 24, 25, 28, 31, 32, 33, 34, 35, 38, 39, 42, 45, 46, 47, 48, 49 };

            // Real input
            internal static int[] Input = new[]
            {
        80
        ,87
        ,10
        ,122
        ,57
        ,142
        ,134
        ,59
        ,113
        ,139
        ,101
        ,41
        ,138
        ,112
        ,46
        ,96
        ,43
        ,125
        ,36
        ,54
        ,133
        ,17
        ,42
        ,98
        ,7
        ,114
        ,78
        ,67
        ,77
        ,28
        ,149
        ,58
        ,20
        ,105
        ,31
        ,19
        ,18
        ,27
        ,40
        ,71
        ,117
        ,66
        ,21
        ,72
        ,146
        ,90
        ,97
        ,94
        ,123
        ,1
        ,119
        ,30
        ,84
        ,61
        ,91
        ,118
        ,2
        ,29
        ,104
        ,73
        ,13
        ,76
        ,24
        ,148
        ,68
        ,111
        ,131
        ,83
        ,49
        ,8
        ,132
        ,9
        ,64
        ,79
        ,124
        ,95
        ,88
        ,135
        ,3
        ,51
        ,39
        ,6
        ,60
        ,108
        ,14
        ,35
        ,147
        ,89
        ,34
        ,65
        ,50
        ,145
        ,128
    };

            internal static Dictionary<int, long> Cache = new Dictionary<int, long>();
        }
    }
}