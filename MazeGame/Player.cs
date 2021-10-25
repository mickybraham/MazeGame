using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace MazeGame
{
    public class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        private string PlayerCharacter;
        private ConsoleColor PlayerColour;
        public int coins;

        public Player(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            PlayerCharacter = "0";
            PlayerColour = ConsoleColor.Red;
            coins = 0;
        }

        public void Draw()
        {
            ForegroundColor = PlayerColour;
            SetCursorPosition(X, Y);
            Write(PlayerCharacter);
            ResetColor();
        }
        public void ResetCursor(int newX,int newY)
        {
            X = newX;
            Y = newY;
            SetCursorPosition(X, Y);
        }
        public int GetCoinValue()
        {
            return coins;
        }
        //just added these 
        public int AddGold()
        {
            coins = coins + 50;
            return coins;
        }
        public int RemoveGold()
        {
            coins = coins - 25;
            return coins;
        }

        public string GetPlayerCharacter()
        {
            return PlayerCharacter;
        }



    }
}
