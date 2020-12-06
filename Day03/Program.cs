using System;
using System.IO;
using System.Collections.Generic;

namespace Day03
{
    class Program
    {
        /* ...#..............#.#....#..#..F
         * ...#..#..#..............#..#...T
         * ....#.#.......#............#...T
         * ..##.....##.........#........##T
         * ...#...........#...##.#...#.##.F
         * ..#.#...#....#.....#........#..F
         * ....##.###.....#..#.......#....T
         * .#..##...#.....#......#..#.....F
        */
        // (0,0) 3 Left + 1 Down
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("../../../input.txt");
            string baseStream = sr.ReadToEnd();
            string[] input = baseStream.Split($"\r\n");
            int mapWidth = input[0].Length;
            int mapHeigth = input.Length;
            int travelX = 3;
            int travelY = 1;
            int iterationY = 0;
            int occurence = 0;
            int i = 0;

            while (iterationY < mapHeigth)
            {
                //positionX //travelX * i
                //repititionWidth //divide postitionx by mapwidth
                //totalWidth //take whole number multiply by width
                //newX //positionx - prev.step



                if (ocupied == "#")
                {
                    occurence++;
                }

                iterationY += travelY;
                i++;
            }

            Console.WriteLine(occurence);
        }
    }
}
