using System;
using System.IO;
using System.Collections.Generic;

namespace Day03
{
    class Program
    {
        /*
         * DAY 03 PART 1&2
         * Looking back on the previous two puzzles I saw the second part being the
         * same problem with 1 complexity more. I decided to code this one less hardcoded
         * and ready for multiple inputs. Strategy worked, I only had to add
         * the List travel and move some variables with a multiply at the end.
         * Height is complete and the Width is repeatable. So with every Loop-iteration the
         * repition of the map is taken of the X-iteration leaving the remainder. This will
         * tell if there is a # underneath or not.
         */
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("../../../input.txt");
            string baseStream = sr.ReadToEnd();
            string[] input = baseStream.Split($"\r\n");
            int mapWidth = input[0].Length;
            int mapHeigth = input.Length;

            List<string> travel = new List<string>
            {
                "1,1", //60
                "3,1", //191
                "5,1", //64
                "7,1", //63
                "1,2"  //32
            };
            List<int> answers = new List<int>();

            foreach (string problem in travel)
            {
                int iterationY = 0;
                int occurences = 0;
                int i = 0;
                int travelX = int.Parse(problem.Substring(0, 1));
                int travelY = int.Parse(problem.Substring(2, 1));

                while (iterationY < mapHeigth)
                {
                    int positionX = travelX * i;
                    Math.DivRem(positionX, mapWidth, out int remainder);

                    string occupied = input[iterationY].Substring(remainder, 1);
                    if (occupied == "#") { occurences++; }

                    iterationY += travelY;
                    i++;
                }

                answers.Add(occurences);
                Console.WriteLine(occurences);
            }
            int answer = answers[0] * answers[1] * answers[2] * answers[3] * answers[4];
            Console.WriteLine(answer.ToString()); //1478615040
        }
    }
}
