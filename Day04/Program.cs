using System;
using System.IO;
using System.Collections.Generic;

namespace Day04
{
    class Program
    {
        /* DAY 04
         * Part 1 was really easy to do. Divide the collection in indivual passports, then
         * divide into information. Check for enough entries; 8 is perfect, 7 only when
         * there was no CID present.
         * Part 2 was a pain in the behind, I had problems with coding the right validations
         * until I went all-out with KeyValue pairs and overengineered checks (length, format, value).
         */

        static void Main(string[] args)
        {
            // Get input of given problem.
            StreamReader sr = new StreamReader("../../../input.txt");
            string baseStream = sr.ReadToEnd();
            string[] input = baseStream.Split($"\r\n\r\n"); //Split per passport

            // Prepare for splitting credentials
            int i = 0;
            IList<KeyValuePair<string, string>>[] passports;
            IList<KeyValuePair<string, string>> collection;

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

            //-- PART 01 BEGIN
            int answerPart01 = 0;
            foreach (IList<KeyValuePair<string, string>> output in passports) //Part 01: Check how many complete; 7 pieces of information w/o CID accounted.
            {
                bool valid = true; // Only flag on errors
                if (output.Count < 7) { valid = false; } // not enough information.
                if (output.Count == 7) // Always true unless cid is given. (meaning 1 of the req. 7 is missing)
                {
                    foreach (KeyValuePair<string, string> outputRow in output)
                    {
                        if (outputRow.Key == "cid") { valid = false; }
                    }
                }
                if (valid) { answerPart01++; } // If passport is seems complete, add 1 to answerPart1
            }

            Console.WriteLine("Part 1: " + answerPart01); //264
            //-- PART 01 END

            //--PART 02 BEGIN
            int answerPart02 = 0;
            foreach (IList<KeyValuePair<string, string>> output in passports) // Take passport 1-by-1
            {
                //Part 02: Check how many valid according ruleset; 7 pieces of information excluding CID.
                bool checkCNT = true; // Only flag on errors
                bool checkCID = true; // Only flag on errors
                bool checkBYR = true; // Only flag on errors
                bool checkIYR = true; // Only flag on errors
                bool checkEYR = true; // Only flag on errors
                bool checkHGT = true; // Only flag on errors
                bool checkHCL = true; // Only flag on errors
                bool checkECL = true; // Only flag on errors
                bool checkPID = true; // Only flag on errors


                if (output.Count < 7) { checkCNT = false; } // Not enough information.
                if (output.Count >= 7) // Enough info, let's check
                {
                    foreach (KeyValuePair<string, string> outputRow in output)
                    {
                        string cKey = outputRow.Key;
                        string cValue = outputRow.Value;

                        // cid (Country ID) - When part of 7-piece passport then false.
                        if (cKey == "cid") { if (output.Count == 7) { checkCID = false; } }

                        // byr(Birth Year) - four digits; at least 1920 and at most 2002.
                        if (cKey == "byr")
                        {
                            if (cValue.Length == 4)
                            {
                                try
                                {
                                    int num = int.Parse(cValue);
                                    if (num < 1920 | num > 2002) { checkBYR = false; } // Outside of range
                                }
                                catch (Exception) { checkBYR = false; } // Not an Int
                            }
                            else { checkBYR = false; } // Not 4 characters
                        }

                        // iyr (Issue Year) - four digits; at least 2010 and at most 2020.
                        if (cKey == "iyr")
                        {
                            if (cValue.Length == 4)
                            {
                                try
                                {
                                    int num = int.Parse(cValue);
                                    if (num < 2010 | num > 2020) { checkIYR = false; } // Outside of Range
                                }
                                catch (Exception) { checkIYR = false; } // Not an Int.
                            }
                            else { checkIYR = false; } // Not 4 Characters
                        }

                        // eyr (Expiration Year) - four digits; at least 2020 and at most 2030.
                        if (cKey == "eyr")
                        {
                            if (cValue.Length == 4)
                            {
                                try
                                {
                                    int num = int.Parse(cValue);
                                    if (num < 2020 | num > 2030) { checkEYR = false; } // Outside of Range
                                }
                                catch (Exception) { checkEYR = false; } // Not an int
                            }
                            else { checkEYR = false; } // Not 4 characters
                        }

                        // pid (Passport ID) - nine digits; including leading zeroes. 
                        if (cKey == "pid") // int is too small for 9-digit numbers, float would do.
                        {
                            if (cValue.Length == 9)
                            {
                                try
                                {
                                    float num = float.Parse(cValue);
                                    if (num < 0 | num > 999999999) { checkEYR = false; } // Outside of Range | <= Peace of mind-code (not needed)
                                }
                                catch (Exception) { checkPID = false; } // Not a float
                            }
                            else { checkPID = false; } // Not 9 characters
                        }

                        // hgt (Height) - a number followed by either cm or in:
                        // -If cm, the number must be at least 150 and at most 193.
                        // -If in, the number must be at least 59 and at most 76.
                        if (cKey == "hgt") // Check for unit cm or in, ifelse false.
                        {
                            if (cValue.Length == 4 | cValue.Length == 5)
                            {
                                if (cValue.EndsWith("cm"))
                                {
                                    try
                                    {
                                        int num = int.Parse(cValue.Remove(cValue.Length - 2));
                                        if (num < 150 | num > 193) { checkHGT = false; } // Outside of Range
                                    }
                                    catch (Exception) { checkHGT = false; } // Not an int
                                }
                                else if (cValue.EndsWith("in"))
                                {
                                    try
                                    {
                                        int num = int.Parse(cValue.Remove(cValue.Length - 2));
                                        if (num < 59 | num > 76) { checkHGT = false; } // Outside of Range
                                    }
                                    catch (Exception) { checkHGT = false; } // Not an int
                                }
                                else { checkHGT = false; } // No unit at end
                            }
                            else { checkHGT = false; }  // Length of cValue is false (4 or 5)
                        }

                        // hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
                        if (cKey == "hcl")
                        {
                            if (cValue.Length == 7 & cValue.StartsWith("#"))
                            {
                                string hex = cValue.Substring(1);
                                try { int num = Int32.Parse(hex, System.Globalization.NumberStyles.HexNumber); }
                                catch (Exception) { checkHCL = false; } // Not a hexadecimal
                            }
                            else { checkHCL = false; } // Not a 7 character string beginning with #
                        }

                        // ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
                        if (cKey == "ecl")
                        {
                            if (cValue != "amb" & cValue != "blu" & cValue != "brn" & cValue != "gry" & cValue != "grn" & cValue != "hzl" & cValue != "oth")
                            { checkECL = false; } // Not 1 of above
                        }
                    }
                }
                if (checkCNT & checkCID & checkBYR & checkIYR & checkEYR & checkHGT & checkHCL & checkECL & checkPID)
                { answerPart02++; } // If all checks are true, add 1 to answerPart2
            }
            //--PART 02 END
            Console.WriteLine("Part 2: " + answerPart02); //224 ( 7th try: *sad face* )
        }
    }
}