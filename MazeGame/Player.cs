using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace MazeGame
{
    class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        private string PlayerCharacter;
        private ConsoleColor PlayerColour;

        public Player(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            PlayerCharacter = "0";
            PlayerColour = ConsoleColor.Red;
        }

        public void Draw()
        {
            ForegroundColor = PlayerColour;
            SetCursorPosition(X, Y);
            Write(PlayerCharacter);
            ResetColor();
        }

    }
}
