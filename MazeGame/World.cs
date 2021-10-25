using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace MazeGame
{
    public class World
    {
        public string[,] Grid;
        private int Rows;
        private int Columns;

        public World(string[,] grid)
        {
            Grid = grid;
            Rows = Grid.GetLength(0);
            Columns = Grid.GetLength(1);
        }

        public void Draw()
        {
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                {
                    string element = Grid[y, x];
                    SetCursorPosition(x, y);
                    Write(element);
                }
            }
        }

        public string GetElementAt(int x, int y)
        {
            return Grid[y, x];
        }

        public bool isPositionValid(int x, int y)
        {
            //check boundaries
            if (x < 0 || y < 0 || x >= Columns || y >= Rows)
            {
                return false;
            }
            // check valid position
            return Grid[y, x] == " " || Grid[y, x] == "X" || Grid[y, x] == "B" || Grid[y, x] == "C" || Grid[y, x] == "E" || Grid[y, x] == "D" || Grid[y, x] == "F" || Grid[y, x] == "G";
        }
    }
}
