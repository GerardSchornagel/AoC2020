using System;
using System.IO;

namespace Day02
{
    class Program
    {

        static void Main(string[] args)
        {
            /* Day 02: Part 1
             * Input will be divided into separate line, these will be splitted by the separators and divided into variables.
             * Then the quantity of the given character is counted in the problem and checked if it falls outside the range given.
             * All the answers will be true or false into a complete list.
             * At the end the True's are counted and outputted as answer.
             * 
             * Day 02: Part 2
             * In the same iteration of part 1 there will be checked if against the comply to the real rules.
             */
            StreamReader sr = new StreamReader("../../../input.txt");
            string baseStream = sr.ReadToEnd();
            string[] input = baseStream.Split($"\r\n");
            int i = 0;
            string[] solutionsPart1 = new string[input.Length];
            string[] solutionsPart2 = new string[input.Length];

            foreach (string line in input)
            {
                string[] splittedWhitespace = line.Split($" "); //14-15 q: qqqqqqqqqqqqqqqq | [0]="14-15"   [1]="q:"    [2]="qqqqqqqqqqqqqqqq"

                string[] range = splittedWhitespace[0].Split("-"); // 14-15 | [0]="14" [1]="15"
                int min = int.Parse(range[0]); //14
                int max = int.Parse(range[1]); //15

                char character = char.Parse(splittedWhitespace[1].Substring(0, 1)); //q
                string problem = splittedWhitespace[2]; //qqqqqqqqqqqqqqqq  | =16*q

                int occurences = 0;

                //-- Begin Part 01
                foreach (char focus in problem.ToCharArray())
                {
                    if (focus == character) { occurences++; } //16
                }

                if (occurences >= min && occurences <= max) { solutionsPart1[i] = "true"; } else { solutionsPart1[i] = "false"; }
                //-- End Part 01

                //-- Begin Part 02
                if (char.Parse(problem.Substring(min - 1, 1)) == character) // 1st match
                {
                    if (char.Parse(problem.Substring(max - 1, 1)) == character)
                    { solutionsPart2[i] = "false"; } // double match = false
                    else { solutionsPart2[i] = "true"; } // single match of #1 = true
                }
                else if (char.Parse(problem.Substring(max - 1, 1)) == character) // 2nd match w/o 1st
                { solutionsPart2[i] = "true"; } // single match of #2 = true
                else { solutionsPart2[i] = "false"; } // no match at all
                //-- End Part 02

                i++; // Next iteration
            }

            int answerPart1 = 0;
            foreach (string value in solutionsPart1)
            {
                if (value == "true") { answerPart1++; }
            }
            Console.WriteLine();
            Console.WriteLine("Day 02: Part 1");
            Console.WriteLine(answerPart1); //515

            int answerPart2 = 0;
            foreach (string value in solutionsPart2)
            {
                if (value == "true") { answerPart2++; }
            }
            Console.WriteLine("-------");
            Console.WriteLine("Day 02: Part 2");
            Console.WriteLine(answerPart2); //711
        }
    }
}