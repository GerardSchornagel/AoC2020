using System;
using System.IO;

namespace Day06
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get input of given problem.
            StreamReader sr = new StreamReader("../../../input.txt");
            string baseStream = sr.ReadToEnd();
            string[] input = baseStream.Split($"\r\n\r\n"); //Split per group

            //--PART 01 BEGIN
            {
                int answerPart1 = 0;
                int[] groupUniques = new int[input.Length];
                int i = 0;

                foreach (string group in input)
                {
                    groupUniques[i] = 0;
                    if (group.Contains("a")) { groupUniques[i]++; }
                    if (group.Contains("b")) { groupUniques[i]++; }
                    if (group.Contains("c")) { groupUniques[i]++; }
                    if (group.Contains("d")) { groupUniques[i]++; }
                    if (group.Contains("e")) { groupUniques[i]++; }
                    if (group.Contains("f")) { groupUniques[i]++; }
                    if (group.Contains("g")) { groupUniques[i]++; }
                    if (group.Contains("h")) { groupUniques[i]++; }
                    if (group.Contains("i")) { groupUniques[i]++; }
                    if (group.Contains("j")) { groupUniques[i]++; }
                    if (group.Contains("k")) { groupUniques[i]++; }
                    if (group.Contains("l")) { groupUniques[i]++; }
                    if (group.Contains("m")) { groupUniques[i]++; }
                    if (group.Contains("n")) { groupUniques[i]++; }
                    if (group.Contains("o")) { groupUniques[i]++; }
                    if (group.Contains("p")) { groupUniques[i]++; }
                    if (group.Contains("q")) { groupUniques[i]++; }
                    if (group.Contains("r")) { groupUniques[i]++; }
                    if (group.Contains("s")) { groupUniques[i]++; }
                    if (group.Contains("t")) { groupUniques[i]++; }
                    if (group.Contains("u")) { groupUniques[i]++; }
                    if (group.Contains("v")) { groupUniques[i]++; }
                    if (group.Contains("w")) { groupUniques[i]++; }
                    if (group.Contains("x")) { groupUniques[i]++; }
                    if (group.Contains("y")) { groupUniques[i]++; }
                    if (group.Contains("z")) { groupUniques[i]++; }

                    answerPart1 += groupUniques[i];
                    // Next if statement is for aligning the Console output.
                    if (groupUniques[i] < 10) { Console.WriteLine("   " + groupUniques[i]); } else { Console.WriteLine("  " + groupUniques[i]); }
                }

                Console.WriteLine("____ +");
                Console.WriteLine(answerPart1.ToString()); //6351
            }

        }
    }
}