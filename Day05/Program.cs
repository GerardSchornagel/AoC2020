using System;
using System.IO;
using System.Collections.Generic;

namespace Day05
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get input of given problem.
            StreamReader sr = new StreamReader("../../../input.txt");
            string baseStream = sr.ReadToEnd();
            string[] input = baseStream.Split($"\r\n"); //Split per scan

            // Prepare for splitting scans
            int i = 0;
            int[,] boardingpasses = new int[input.Length, 3];
            int answerPart1 = 0;

            //--PART 01
            {

                foreach (string pass in input)
                {
                    int seatF = 0;
                    int seatB = 128;
                    int seatL = 0;
                    int seatR = 8;

                    string[] converter = pass.Split();

                    foreach (char characterConvert in pass)
                    {
                        if (characterConvert.ToString() == "F") { seatB = seatB - ((seatB - seatF) / 2); }
                        if (characterConvert.ToString() == "B") { seatF = seatF + ((seatB - seatF) / 2); }
                        if (characterConvert.ToString() == "L") { seatR = seatR - ((seatR - seatL) / 2); }
                        if (characterConvert.ToString() == "R") { seatL = seatL + ((seatR - seatL) / 2); }
                    }

                    boardingpasses[i, 0] = seatF;
                    boardingpasses[i, 1] = seatL;
                    boardingpasses[i, 2] = (seatF * 8) + seatL;
                    if (answerPart1 < boardingpasses[i, 2])
                    {
                        answerPart1 = boardingpasses[i, 2];
                    }
                    i++;
                }
                Console.WriteLine(answerPart1.ToString()); //935
            }
        }
    }
}