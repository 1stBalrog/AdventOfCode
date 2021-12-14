using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2021
{
    internal class Day10
    {
        private static char[] OpenChars = new char[] { '(', '[', '{', '<' };
        private static char[] ClosingChars = new char[] { ')', ']', '}', '>' };

        internal static void Main()
        {
            var input = File.ReadAllLines("Year2021/Day10_Input.txt");

            #region Part1
            //var wrongCharacters = new List<char>();
            //foreach (var line in input)
            //{
            //    var code = line;
            //    while (true)
            //    {
            //        if (code.Contains("()"))
            //        {
            //            code = code.Replace("()", "");
            //        }
            //        else if (code.Contains("[]"))
            //        {
            //            code = code.Replace("[]", "");
            //        }
            //        else if (code.Contains("{}"))
            //        {
            //            code = code.Replace("{}", "");
            //        }
            //        else if (code.Contains("<>"))
            //        {
            //            code = code.Replace("<>", "");
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }
            //    if (string.IsNullOrEmpty(code))
            //    {
            //        //Everything good
            //        continue;
            //    }

            //    var wrongCharacter = code.FirstOrDefault(x => ClosingChars.Contains(x));
            //    if(wrongCharacter != '\0')
            //        wrongCharacters.Add(wrongCharacter);
            //}

            //long score = 0;
            //foreach (var character in wrongCharacters)
            //{
            //    switch (character)
            //    {
            //        case ')':
            //            score += 3;
            //            break;
            //        case ']':
            //            score += 57;
            //            break;
            //        case '}':
            //            score += 1197;
            //            break;
            //        case '>':
            //            score += 25137;
            //            break;
            //        default:
            //            throw new NotImplementedException();
            //    }
            //}
            //Console.WriteLine($"Total score: {score}");
            #endregion

            #region Part2
            var incomplete = new List<string>();
            foreach (var line in input)
            {
                var code = line;
                while (true)
                {
                    if (code.Contains("()"))
                    {
                        code = code.Replace("()", "");
                    }
                    else if (code.Contains("[]"))
                    {
                        code = code.Replace("[]", "");
                    }
                    else if (code.Contains("{}"))
                    {
                        code = code.Replace("{}", "");
                    }
                    else if (code.Contains("<>"))
                    {
                        code = code.Replace("<>", "");
                    }
                    else
                    {
                        break;
                    }
                }
                if (string.IsNullOrEmpty(code))
                {
                    //Everything good
                    continue;
                }

                var wrongCharacter = code.FirstOrDefault(x => ClosingChars.Contains(x));
                if (wrongCharacter == '\0')
                    incomplete.Add(code);
            }

            var scores = new List<long>();
            foreach (var line in incomplete)
            {
                long score = 0;
                for (int i = line.Length - 1; i >= 0; i--)
                {
                    //Multiply by 5
                    score *= 5;

                    //Add Character value
                    switch (line[i])
                    {
                        case '(':
                            score += 1;
                            break;
                        case '[':
                            score += 2;
                            break;
                        case '{':
                            score += 3;
                            break;
                        case '<':
                            score += 4;
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                }
                scores.Add(score);
            }

            scores.Sort();
            var middleScore = scores[scores.Count / 2];
            Console.WriteLine($"Total score: {middleScore}");
            #endregion
        }
    }
}
