using System;
using System.Collections.Generic;
using System.IO;

namespace Day07
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //-- PART 1
            {
                // Get input of given problem.
                StreamReader sr = new StreamReader("../../../input.txt");
                string baseStream = sr.ReadToEnd();
                string[] input = baseStream.Split($"\r\n"); //Split per rule
                string[,] rules = new string[input.Length, 10];
                List<string> goldBags = new List<string>();
                List<string> goldCheck = new List<string>();
                List<string> goldFound = new List<string>();

                int i = 0;
                int g = 0;

                // "Translate" for easier processing.
                foreach (string line in input)
                {
                    string[] lineSplit = line.Split(" ");

                    rules[i, 0] = new string(lineSplit[0]);
                    rules[i, 1] = new string(lineSplit[1]);
                    if (lineSplit.Length >= 7) { rules[i, 2] = new string(lineSplit[5]); rules[i, 3] = new string(lineSplit[6]); } // 1 bag
                    if (lineSplit.Length >= 11) { rules[i, 4] = new string(lineSplit[9]); rules[i, 5] = new string(lineSplit[10]); } // 2 bags
                    if (lineSplit.Length >= 15) { rules[i, 6] = new string(lineSplit[13]); rules[i, 7] = new string(lineSplit[14]); } // 3 bags
                    if (lineSplit.Length >= 19) { rules[i, 8] = new string(lineSplit[17]); rules[i, 9] = new string(lineSplit[18]); } // 4 bags
                    i++;
                }

                // Get shiny gold bags
                i = 0;
                while (i < (rules.Length / 10))
                {
                    if (rules[i, 2] == "shiny" & rules[i, 3] == "gold") { goldCheck.Add(rules[i, 0]); goldCheck.Add(rules[i, 1]); }
                    if (rules[i, 4] == "shiny" & rules[i, 5] == "gold") { goldCheck.Add(rules[i, 0]); goldCheck.Add(rules[i, 1]); }
                    if (rules[i, 6] == "shiny" & rules[i, 7] == "gold") { goldCheck.Add(rules[i, 0]); goldCheck.Add(rules[i, 1]); }
                    if (rules[i, 8] == "shiny" & rules[i, 9] == "gold") { goldCheck.Add(rules[i, 0]); goldCheck.Add(rules[i, 1]); }
                    i++;
                }

                while (goldCheck.Count != 0) //Loop the checklist until no new is provided
                {
                    g = 0;
                    while (g < goldCheck.Count) //Loop until current checklist is empty
                    {
                        i = 0;
                        while (i < (rules.Length / 10)) //Loop until all rules are checked
                        {
                            if (rules[i, 2] == goldCheck[g] & rules[i, 3] == goldCheck[g + 1]) { goldFound.Add(rules[i, 0]); goldFound.Add(rules[i, 1]); }
                            if (rules[i, 4] == goldCheck[g] & rules[i, 5] == goldCheck[g + 1]) { goldFound.Add(rules[i, 0]); goldFound.Add(rules[i, 1]); }
                            if (rules[i, 6] == goldCheck[g] & rules[i, 7] == goldCheck[g + 1]) { goldFound.Add(rules[i, 0]); goldFound.Add(rules[i, 1]); }
                            if (rules[i, 8] == goldCheck[g] & rules[i, 9] == goldCheck[g + 1]) { goldFound.Add(rules[i, 0]); goldFound.Add(rules[i, 1]); }
                            i++;
                        }
                        g += 2;
                    }

                    i = 0;
                    while (i < goldCheck.Count) //Stick checked bags together in List
                    {
                        goldBags.Add(goldCheck[i] + " " + goldCheck[i + 1]);
                        i += 2;
                    }
                    goldCheck.Clear();
                    goldCheck.AddRange(goldFound); //Fill in new checklist
                    goldFound.Clear();
                }

                // Display all bags that can contain gold.
                goldBags.Sort();
                List<string> goldOutput = new List<string>();

                // Copy unique entry's to outputBags
                foreach (string bag in goldBags) { if (goldOutput.Contains(bag)) { } else { goldOutput.Add(bag); } }

                // Itterate to Console and give total of goldOutput
                foreach (string output in goldOutput)
                {
                    Console.WriteLine(output);
                }
                Console.WriteLine(goldOutput.Count); // 238
            }


        }
    }
}