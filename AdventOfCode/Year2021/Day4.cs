using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2021
{
    internal class Day4
    {
        internal static void Main()
        {
            #region Input
            var lines = File.ReadAllLines("Year2021/Day4_Input.txt");

            var numberPool = lines.First().Split(',').Select(x => Convert.ToInt32(x)).ToList();
            var boards = new List<int[][]>();

            var boardCount = (lines.Length - 1) / 6;
            for (var i = 0; i < boardCount; i++)
            {
                var currentBoard = new int[5][];
                var currentBoardLines = lines.Skip(1 + 6 * i + 1).Take(5).ToList();
                if (currentBoardLines.Count != 5)
                    continue;

                for (var j = 0; j < currentBoardLines.Count; j++)
                {
                    currentBoard[j] = currentBoardLines[j].Split(' ').Where(x => x != "").Select(x => Convert.ToInt32(x)).ToArray();
                }
                boards.Add(currentBoard);
            }
            #endregion

            #region Part1
            //var numbers = new List<int>();
            //var winnerFound = false;
            //var winner = Array.Empty<int[]>();
            //foreach (var number in numberPool)
            //{
            //    numbers.Add(number);
            //    foreach (var board in boards)
            //    {
            //        winnerFound = BoardWins(board, numbers);

            //        if (winnerFound)
            //        {
            //            winner = board;
            //            break;
            //        }
            //    }

            //    if (winnerFound)
            //    {
            //        break;
            //    }
            //}

            //var unmarked = new List<int>();
            //for (int i = 0; i < 5; i++)
            //{
            //    unmarked.AddRange(winner[i].Where(x => !numbers.Contains(x)));
            //}

            //var score = unmarked.Sum() * numbers.Last();

            //Console.WriteLine($"Score: {score}");
            #endregion

            #region Part2
            var numbers = new List<int>();
            var looserFound = false;
            var looser = Array.Empty<int[]>();
            foreach (var number in numberPool)
            {
                numbers.Add(number);
                for (int i = boards.Count; i > 0; i--)
                {
                    if (BoardWins(boards[i - 1], numbers))
                    {
                        if (boards.Count == 1)
                        {
                            looser = boards[0];
                            looserFound = true;
                            break;
                        }

                        boards.RemoveAt(i - 1);
                    }
                }

                if (looserFound)
                {
                    break;
                }
            }

            var unmarked = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                unmarked.AddRange(looser[i].Where(x => !numbers.Contains(x)));
            }

            var score = unmarked.Sum() * numbers.Last();

            Console.WriteLine($"Score: {score}");
            #endregion
        }

        private static bool BoardWins(int[][] board, List<int> numbers)
        {
            //Lines
            for (int i = 0; i < 5; i++)
            {
                if (board[i].ToList().All(x => numbers.Contains(x)))
                {
                    return true;
                }
            }

            //Columns
            for (int i = 0; i < 5; i++)
            {
                if (board.Select(x => x[i]).All(x => numbers.Contains(x)))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
