using System;
using System.IO;
using System.Collections.Generic;

namespace Day04
{
    class Program
    {
        /* Test on complete passports, but ignore CID. How many are valid?
         * byr (Birth Year)
         * iyr (Issue Year)
         * eyr (Expiration Year)
         * hgt (Height)
         * hcl (Hair Color)
         * ecl (Eye Color)
         * pid (Passport ID)
         * cid (Country ID)         
         */

        static void Main(string[] args)
        {
            // Get input of given problem.
            StreamReader sr = new StreamReader("../../../input.txt");
            string baseStream = sr.ReadToEnd();
            string[] input = baseStream.Split($"\r\n\r\n"); //Split per passport

            // Prepare for splitting
            IList<KeyValuePair<string, string>>[] passports;
            IList<KeyValuePair<string, string>> collection;
            int i = 0;
            foreach (string line in input) { input[i] = line.Replace("\r\n", " "); i++; } //Replace 'Enter' with space
            passports = new IList<KeyValuePair<string, string>>[input.Length];

            // Convert input[] > credentials > information = KeyValuePair in collection in passports
            i = 0;
            foreach (string line in input) // Put in temporary and copy total to passports.
            {
                collection = new List<KeyValuePair<string, string>>();
                string[] credentials = line.Split(" ");
                foreach (string information in credentials) //Add each piece of information in a KeyValue List
                {
                    collection.Add(KeyValuePair.Create(information.Split(":")[0], information.Split(":")[1]));
                }
                passports[i] = collection; //Copy to Passport database
                i++;
            }

            // Check how many valid; 7 pieces of information w/o CID accounted.
            int answerPart01 = 0;
            foreach (IList<KeyValuePair<string, string>> output in passports) // Take passport 1-by-1
            {
                bool valid = true; // If there is one error it will be switched to false
                if (output.Count < 7) { valid = false; }
                if (output.Count == 7) // Always true unless cid is given. (meaning 1 of the req. 7 is missing)
                {
                    foreach (KeyValuePair<string, string> outputRow in output)
                    {
                        if (outputRow.Key == "cid") { valid = false; }
                    }
                }

                if (valid) { answerPart01++; } // If passport is valid add 1 to answerPart1
            }

            Console.WriteLine("Part 1: " + answerPart01); //264
        }
    }
}