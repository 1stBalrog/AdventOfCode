using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2021
{
    internal class Day9
    {
        internal static void Main()
        {
            var input = File.ReadAllLines("Year2021/Day9_Input.txt");

            #region Part1
            //var x = input.Count();
            //var y = input.First().Count();

            //var map = new int[x][];
            //for (var i = 0; i < x; i++)
            //{
            //    map[i] = input[i].Select(x => Convert.ToInt32(x.ToString())).ToArray();
            //}

            //var lowPoints = new List<int>();
            //for (int i = 0; i < x; i++)
            //{
            //    for(var j = 0; j < y; j++)
            //    {
            //        if (i == 0) // Top
            //        {
            //            if(j == 0) // Left
            //            {
            //                var current = map[i][j];
            //                var bottom = map[i + 1][j];
            //                var right = map[i][j + 1];
            //                if(current < bottom && current < right)
            //                {
            //                    lowPoints.Add(current);
            //                }
            //            }
            //            else if(j == y - 1) // Right
            //            {
            //                var current = map[i][j];
            //                var bottom = map[i + 1][j];
            //                var left = map[i][j - 1];
            //                if (current < bottom && current < left)
            //                {
            //                    lowPoints.Add(current);
            //                }
            //            }
            //            else // Middle
            //            {
            //                var current = map[i][j];
            //                var bottom = map[i + 1][j];
            //                var left = map[i][j - 1];
            //                var right = map[i][j + 1];
            //                if (current < bottom && current < left && current < right)
            //                {
            //                    lowPoints.Add(current);
            //                }
            //            }
            //        }
            //        else if(i == x - 1) // Bottom
            //        {
            //            if (j == 0) // Left
            //            {
            //                var current = map[i][j];
            //                var top = map[i - 1][j];
            //                var right = map[i][j + 1];
            //                if (current < top && current < right)
            //                {
            //                    lowPoints.Add(current);
            //                }
            //            }
            //            else if (j == y - 1) // Right
            //            {
            //                var current = map[i][j];
            //                var top = map[i - 1][j];
            //                var left = map[i][j - 1];
            //                if (current < top && current < left)
            //                {
            //                    lowPoints.Add(current);
            //                }
            //            }
            //            else // Middle
            //            {
            //                var current = map[i][j];
            //                var top = map[i - 1][j];
            //                var left = map[i][j - 1];
            //                var right = map[i][j + 1];
            //                if (current < top && current < left && current < right)
            //                {
            //                    lowPoints.Add(current);
            //                }
            //            }
            //        }
            //        else // Middle
            //        {
            //            if (j == 0) // Left
            //            {
            //                var current = map[i][j];
            //                var top = map[i - 1][j];
            //                var bottom = map[i + 1][j];
            //                var right = map[i][j + 1];
            //                if (current < top && current < bottom && current < right)
            //                {
            //                    lowPoints.Add(current);
            //                }
            //            }
            //            else if (j == y - 1) // Right
            //            {
            //                var current = map[i][j];
            //                var top = map[i - 1][j];
            //                var bottom = map[i + 1][j];
            //                var left = map[i][j - 1];
            //                if (current < top && current < bottom && current < left)
            //                {
            //                    lowPoints.Add(current);
            //                }
            //            }
            //            else // Middle
            //            {
            //                var current = map[i][j];
            //                var top = map[i - 1][j];
            //                var bottom = map[i + 1][j];
            //                var left = map[i][j - 1];
            //                var right = map[i][j + 1];
            //                if (current < top && current < bottom && current < left && current < right)
            //                {
            //                    lowPoints.Add(current);
            //                }
            //            }
            //        }
            //    }
            //}

            //var risk = lowPoints.Sum() + lowPoints.Count;
            //Console.WriteLine($"Risk: {risk}");
            #endregion

            #region Part2
            var x = input.Count();
            var y = input.First().Count();

            var map = new int[x][];
            for (var i = 0; i < x; i++)
            {
                map[i] = input[i].Select(x => Convert.ToInt32(x.ToString())).ToArray();
            }

            var basins = new List<int>();
            for (int i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++)
                {
                    if (i == 0) // Top
                    {
                        if (j == 0) // Left
                        {
                            var current = map[i][j];
                            var bottom = map[i + 1][j];
                            var right = map[i][j + 1];
                            if (current < bottom && current < right)
                            {
                                basins.Add(GetBasinSize(map, i, j, x, y));
                            }
                        }
                        else if (j == y - 1) // Right
                        {
                            var current = map[i][j];
                            var bottom = map[i + 1][j];
                            var left = map[i][j - 1];
                            if (current < bottom && current < left)
                            {
                                basins.Add(GetBasinSize(map, i, j, x, y));
                            }
                        }
                        else // Middle
                        {
                            var current = map[i][j];
                            var bottom = map[i + 1][j];
                            var left = map[i][j - 1];
                            var right = map[i][j + 1];
                            if (current < bottom && current < left && current < right)
                            {
                                basins.Add(GetBasinSize(map, i, j, x, y));
                            }
                        }
                    }
                    else if (i == x - 1) // Bottom
                    {
                        if (j == 0) // Left
                        {
                            var current = map[i][j];
                            var top = map[i - 1][j];
                            var right = map[i][j + 1];
                            if (current < top && current < right)
                            {
                                basins.Add(GetBasinSize(map, i, j, x, y));
                            }
                        }
                        else if (j == y - 1) // Right
                        {
                            var current = map[i][j];
                            var top = map[i - 1][j];
                            var left = map[i][j - 1];
                            if (current < top && current < left)
                            {
                                basins.Add(GetBasinSize(map, i, j, x, y));
                            }
                        }
                        else // Middle
                        {
                            var current = map[i][j];
                            var top = map[i - 1][j];
                            var left = map[i][j - 1];
                            var right = map[i][j + 1];
                            if (current < top && current < left && current < right)
                            {
                                basins.Add(GetBasinSize(map, i, j, x, y));
                            }
                        }
                    }
                    else // Middle
                    {
                        if (j == 0) // Left
                        {
                            var current = map[i][j];
                            var top = map[i - 1][j];
                            var bottom = map[i + 1][j];
                            var right = map[i][j + 1];
                            if (current < top && current < bottom && current < right)
                            {
                                basins.Add(GetBasinSize(map, i, j, x, y));
                            }
                        }
                        else if (j == y - 1) // Right
                        {
                            var current = map[i][j];
                            var top = map[i - 1][j];
                            var bottom = map[i + 1][j];
                            var left = map[i][j - 1];
                            if (current < top && current < bottom && current < left)
                            {
                                basins.Add(GetBasinSize(map, i, j, x, y));
                            }
                        }
                        else // Middle
                        {
                            var current = map[i][j];
                            var top = map[i - 1][j];
                            var bottom = map[i + 1][j];
                            var left = map[i][j - 1];
                            var right = map[i][j + 1];
                            if (current < top && current < bottom && current < left && current < right)
                            {
                                basins.Add(GetBasinSize(map, i, j, x, y));
                            }
                        }
                    }
                }
            }

            var biggestThree = basins.OrderByDescending(x => x).Take(3).ToArray();
            var size = biggestThree[0] * biggestThree[1] * biggestThree[2];
            Console.WriteLine($"Size: {size}");
            #endregion
        }

        private static int GetBasinSize(int[][] map, int i, int j, int x, int y)
        {
            var visited = new HashSet<int>();
            var count = 0;
            GetSurrounding(ref visited, ref count, map, i, j, x, y);

            return count;
        }

        private static void GetSurrounding(ref HashSet<int> visited, ref int count, int[][] map, int i, int j, int x, int y)
        {
            var currentNode = i * 1000 + j;
            if (visited.Contains(currentNode))
                return;
            visited.Add(currentNode);

            if (map[i][j] == 9)
                return;

            count++;

            if (i == 0) // Top
            {
                if (j == 0) // Left
                {
                    GetSurrounding(ref visited, ref count, map, i + 1, j, x, y);
                    GetSurrounding(ref visited, ref count, map, i, j + 1, x, y);
                }
                else if (j == y - 1) // Right
                {
                    GetSurrounding(ref visited, ref count, map, i + 1, j, x, y);
                    GetSurrounding(ref visited, ref count, map, i, j - 1, x, y);
                }
                else // Middle
                {
                    GetSurrounding(ref visited, ref count, map, i + 1, j, x, y);
                    GetSurrounding(ref visited, ref count, map, i, j - 1, x, y);
                    GetSurrounding(ref visited, ref count, map, i, j + 1, x, y);
                }
            }
            else if (i == x - 1) // Bottom
            {
                if (j == 0) // Left
                {
                    GetSurrounding(ref visited, ref count, map, i - 1, j, x, y);
                    GetSurrounding(ref visited, ref count, map, i, j + 1, x, y);
                }
                else if (j == y - 1) // Right
                {
                    GetSurrounding(ref visited, ref count, map, i - 1, j, x, y);
                    GetSurrounding(ref visited, ref count, map, i, j - 1, x, y);
                }
                else // Middle
                {
                    GetSurrounding(ref visited, ref count, map, i - 1, j, x, y);
                    GetSurrounding(ref visited, ref count, map, i, j - 1, x, y);
                    GetSurrounding(ref visited, ref count, map, i, j + 1, x, y);
                }
            }
            else // Middle
            {
                if (j == 0) // Left
                {
                    GetSurrounding(ref visited, ref count, map, i - 1, j, x, y);
                    GetSurrounding(ref visited, ref count, map, i + 1, j, x, y);
                    GetSurrounding(ref visited, ref count, map, i, j + 1, x, y);
                }
                else if (j == y - 1) // Right
                {
                    GetSurrounding(ref visited, ref count, map, i - 1, j, x, y);
                    GetSurrounding(ref visited, ref count, map, i + 1, j, x, y);
                    GetSurrounding(ref visited, ref count, map, i, j - 1, x, y);
                }
                else // Middle
                {
                    GetSurrounding(ref visited, ref count, map, i - 1, j, x, y);
                    GetSurrounding(ref visited, ref count, map, i + 1, j, x, y);
                    GetSurrounding(ref visited, ref count, map, i, j - 1, x, y);
                    GetSurrounding(ref visited, ref count, map, i, j + 1, x, y);
                }
            }
        }
    }
}
