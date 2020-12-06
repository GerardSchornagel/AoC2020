using System;
using System.IO;
using System.Collections.Generic;

namespace Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("../../../input.txt");
            string baseStream = sr.ReadToEnd();
            string[] input = baseStream.Split($"\r\n");
            List<string> solutions = new List<string>();
            int i = 0;

            /* DAY 01: PART 1
             * Just a loop-in-a-loop to bruteforce all the numbers as lefthand & righthand of the sum.
             * When 2020 is tested true, the left & right are saved to be repeated and multiplied at the end.
             * This means you get all solutions if there, but they all will be doubled (L+R & R+L)
             * SOLUTION 399+1621=2020 ; 399*1621=646779
             */
            solutions.Add("Day 01: Part 01");

            foreach (string line in input)
            {
                int left = int.Parse(line);
                foreach (string compare in input)
                {
                    int right = int.Parse(compare);
                    int outcome = left + right;

                    if (outcome == 2020) { solutions.Add((left + "+" + right + "=" + (left + right) + "=" + (left * right)).ToString()); i++; }
                }
            }

            /* DAY 01: PART 2
             * Same as Part 1 but with three sides: Left, Middle & Right
             * This is about the least efficient way, but it serves it purpose and optimizing is not a requirement.
             * Otherwise I would come up with something that was more efficient by using actual math ^_^
             * *edit: I did optimized a bit, simply by looking if the 1st+2nd is already bigger then 2020 to skip that row.
             * SOLUTION 591+1021+408=2020 ; 591*1021*408=246191688
             */
            solutions.Add("Day 01: Part 02");

            foreach (string first in input)
            {
                int left = int.Parse(first);
                foreach (string second in input)
                {
                    int middle = int.Parse(second);
                    int intermediate = left + middle;
                    if (intermediate <= 2020) // Ultra-effcient high IQ optimzed streamlined wonder of code!
                    {
                        foreach (string third in input)
                        {
                            int right = int.Parse(third);
                            int outcome = left + middle + right;

                            if (outcome == 2020) { solutions.Add((left + "+" + middle + "+" + right + "=" + (left + middle + right) + "=" + (left * middle * right)).ToString()); i++; }
                        }
                    }
                }
            }
            
            Console.WriteLine("--------------------");
            foreach (string output in solutions) { Console.WriteLine(output); }
        }
    }
}