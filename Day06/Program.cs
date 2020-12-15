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

            //--PART 02 BEGIN
            {
                int answerPart2 = 0;
                int[] groupCommons = new int[input.Length];
                int i = 0;

                foreach (string group in input)
                {
                    string[] groupIndividual = group.Split("\r\n");
                    int groupSize = groupIndividual.Length;
                    groupCommons[i] = 0;

                    decimal occA = 0;
                    foreach (string question in groupIndividual) { if (question.Contains("a")) { occA++; } }
                    occA = Math.Floor(occA / groupSize);
                    decimal occB = 0;
                    foreach (string question in groupIndividual) { if (question.Contains("b")) { occB++; } }
                    occB = Math.Floor(occB / groupSize);
                    decimal occC = 0;
                    foreach (string question in groupIndividual) { if (question.Contains("c")) { occC++; } }
                    occC = Math.Floor(occC / groupSize);
                    decimal occD = 0;
                    foreach (string question in groupIndividual) { if (question.Contains("d")) { occD++; } }
                    occD = Math.Floor(occD / groupSize);
                    decimal occE = 0;
                    foreach (string question in groupIndividual) { if (question.Contains("e")) { occE++; } }
                    occE = Math.Floor(occE / groupSize);
                    decimal occF = 0;
                    foreach (string question in groupIndividual) { if (question.Contains("f")) { occF++; } }
                    occF = Math.Floor(occF / groupSize);
                    decimal occG = 0;
                    foreach (string question in groupIndividual) { if (question.Contains("g")) { occG++; } }
                    occG = Math.Floor(occG / groupSize);
                    decimal occH = 0;
                    foreach (string question in groupIndividual) { if (question.Contains("h")) { occH++; } }
                    occH = Math.Floor(occH / groupSize);
                    decimal occI = 0;
                    foreach (string question in groupIndividual) { if (question.Contains("i")) { occI++; } }
                    occI = Math.Floor(occI / groupSize);
                    decimal occJ = 0;
                    foreach (string question in groupIndividual) { if (question.Contains("j")) { occJ++; } }
                    occJ = Math.Floor(occJ / groupSize);
                    decimal occK = 0;
                    foreach (string question in groupIndividual) { if (question.Contains("k")) { occK++; } }
                    occK = Math.Floor(occK / groupSize);
                    decimal occL = 0;
                    foreach (string question in groupIndividual) { if (question.Contains("l")) { occL++; } }
                    occL = Math.Floor(occL / groupSize);
                    decimal occM = 0;
                    foreach (string question in groupIndividual) { if (question.Contains("m")) { occM++; } }
                    occM = Math.Floor(occM / groupSize);
                    decimal occN = 0;
                    foreach (string question in groupIndividual) { if (question.Contains("n")) { occN++; } }
                    occN = Math.Floor(occN / groupSize);
                    decimal occO = 0;
                    foreach (string question in groupIndividual) { if (question.Contains("o")) { occO++; } }
                    occO = Math.Floor(occO / groupSize);
                    decimal occP = 0;
                    foreach (string question in groupIndividual) { if (question.Contains("p")) { occP++; } }
                    occP = Math.Floor(occP / groupSize);
                    decimal occQ = 0;
                    foreach (string question in groupIndividual) { if (question.Contains("q")) { occQ++; } }
                    occQ = Math.Floor(occQ / groupSize);
                    decimal occR = 0;
                    foreach (string question in groupIndividual) { if (question.Contains("r")) { occR++; } }
                    occR = Math.Floor(occR / groupSize);
                    decimal occS = 0;
                    foreach (string question in groupIndividual) { if (question.Contains("s")) { occS++; } }
                    occS = Math.Floor(occS / groupSize);
                    decimal occT = 0;
                    foreach (string question in groupIndividual) { if (question.Contains("t")) { occT++; } }
                    occT = Math.Floor(occT / groupSize);
                    decimal occU = 0;
                    foreach (string question in groupIndividual) { if (question.Contains("u")) { occU++; } }
                    occU = Math.Floor(occU / groupSize);
                    decimal occV = 0;
                    foreach (string question in groupIndividual) { if (question.Contains("v")) { occV++; } }
                    occV = Math.Floor(occV / groupSize);
                    decimal occW = 0;
                    foreach (string question in groupIndividual) { if (question.Contains("w")) { occW++; } }
                    occW = Math.Floor(occW / groupSize);
                    decimal occX = 0;
                    foreach (string question in groupIndividual) { if (question.Contains("x")) { occX++; } }
                    occX = Math.Floor(occX / groupSize);
                    decimal occY = 0;
                    foreach (string question in groupIndividual) { if (question.Contains("y")) { occY++; } }
                    occY = Math.Floor(occY / groupSize);
                    decimal occZ = 0;
                    foreach (string question in groupIndividual) { if (question.Contains("z")) { occZ++; } }
                    occZ = Math.Floor(occZ / groupSize);

                    decimal occTotal = (occA + occB + occC + occD + occE + occF + occG + occH + occI + occJ + occK + occL + occM + occN + occO + occP + occQ + occR + occS + occT + occU + occV + occW + occX + occY + occZ);
                    answerPart2 += int.Parse(occTotal.ToString());
                }

                Console.WriteLine();
                Console.WriteLine("Part 02: " + answerPart2.ToString()); //3143
            }
        }
    }
}