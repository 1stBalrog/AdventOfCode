using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2021
{
    internal class Day12
    {
        internal static void Main()
        {
            var input = File.ReadAllLines("Year2021/Day12_Input.txt");

            var paths = new List<Path>();
            foreach (var line in input)
            {
                var path = new Path(line);
                paths.Add(path);
            }

            //Startpoint = "start"
            //Endpoint = "end"
            var pathsTaken = new List<string>();
            Move(paths, "start", "start", pathsTaken);

            Console.WriteLine($"paths: {pathsTaken.Count}");
        }

        private static void Move(List<Path> allPaths, string currentNode, string currentPath, List<string> pathsTaken)
        {
            #region Part1
            //if (currentNode == "end")
            //{
            //    pathsTaken.Add(currentPath);
            //    return;
            //}

            //var paths = allPaths.Where(x => x.PointA == currentNode || x.PointB == currentNode).ToList();
            //var nodes = paths.Select(x => x.PointA).Union(paths.Select(x => x.PointB)).Distinct().Where(x => x != currentNode).ToList();

            //foreach (var node in nodes)
            //{
            //    if (currentPath.Split(',').Where(x => !x.All(char.IsUpper)).Contains(node))
            //        continue;

            //    Move(allPaths, node, currentPath + "," + node, pathsTaken);
            //}
            #endregion

            #region Part2
            if (currentNode == "end")
            {
                //Path must stop when reaching end
                pathsTaken.Add(currentPath);
                return;
            }

            var paths = allPaths.Where(x => x.PointA == currentNode || x.PointB == currentNode).ToList();
            var nodes = paths.Select(x => x.PointA).Union(paths.Select(x => x.PointB)).Distinct().Where(x => x != currentNode).ToList();

            foreach (var node in nodes)
            {
                //Start can only be visited once
                if (node == "start")
                    continue;

                var lowerNodes = currentPath.Split(',').Where(x => !x.All(char.IsUpper));

                //1 lower node can be visited twice
                if (lowerNodes.GroupBy(x => x).Any(x => x.Count() > 1) && lowerNodes.Contains(node))
                    continue;

                Move(allPaths, node, currentPath + "," + node, pathsTaken);
            }
            #endregion
        }

        private class Path
        {
            public Path(string line)
            {
                var points = line.Split('-');

                PointA = points[0];
                PointB = points[1];
            }

            public string PointA { get; set; }
            public string PointB { get; set; }

            public override string ToString() => $"{PointA}-{PointB}";
        }
    }
}
