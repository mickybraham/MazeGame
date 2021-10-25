using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace MazeGame
{
    public class LevelCompiler
    {
        public static string[,] CompileFileToArray(string filepath)
        {
            string[] lines = File.ReadAllLines(filepath);
            string firstline = lines[0];
            int rows = lines.Length;
            int columns = firstline.Length;
            string[,] grid = new string[rows, columns];

            for (int y = 0; y < rows; y++)
            {
                string line = lines[y];
                for (int x = 0; x < columns; x++)
                {
                    char currentChar = line[x];
                    grid[y, x] = currentChar.ToString();
                }
            }

            return grid;
        }
    }
}
