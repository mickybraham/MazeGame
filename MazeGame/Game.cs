using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace MazeGame
{
    class Game
    {
        private World NewWorld;
        private Player NewPlayer;
        public int level;



        public void Start()
        {


           string[,] grid = LevelCompiler.CompileFileToArray("level1.txt");
            
            NewWorld = new World(grid);


            NewPlayer = new Player(2, 0);


            runGame();
            
            //Console.WriteLine(newWorld.isPositionValid(0, 0)); //false
            //Console.WriteLine(newWorld.isPositionValid(1, 1)); //true
            //Console.WriteLine(newWorld.isPositionValid(6, 1)); //true


        }

        
        private void Instructions()
        {
            Console.WriteLine("Welcome to Michael's Maze game");
            Console.WriteLine("Instructions:");
            Console.WriteLine("Use the arrows keys to navigate the maze and reach the X");
            Console.WriteLine("To start enter name:");
            string UserName = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            string password = Console.ReadLine();
        }

        private void GameEnd()
        {
            Clear();
            Console.WriteLine("Well done you have been successful");
            Console.WriteLine("Press any key to finish");
            ReadKey(true);
        }

        private void DrawFrame()
        {
            Clear();
            NewWorld.Draw();
            NewPlayer.Draw();
        }
        private void HandleInput()
        {
            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            switch(key)
            {
                case ConsoleKey.UpArrow:
                    if (NewWorld.isPositionValid(NewPlayer.X, NewPlayer.Y - 1))
                    {
                        NewPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (NewWorld.isPositionValid(NewPlayer.X, NewPlayer.Y + 1))
                    {
                        NewPlayer.Y += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (NewWorld.isPositionValid(NewPlayer.X - 1, NewPlayer.Y))
                    {
                        NewPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (NewWorld.isPositionValid(NewPlayer.X + 1, NewPlayer.Y))
                    {
                        NewPlayer.X += 1;
                    }
                    break;
                default:
                    break;
            }
        }
        private void runGame()
        {
            Instructions();
            while (true)
            {
                // Draw Everything
                DrawFrame();

                //Check for player input from keyboard and move player
                HandleInput();

                //check if player has reached the exit
                string elementAtPlayerPos = NewWorld.GetElementAt(NewPlayer.X, NewPlayer.Y);

                if (elementAtPlayerPos == "X")
                {
                    level = level + 1;
                    break;
                }
                
                //Give the console a chance to render
                System.Threading.Thread.Sleep(5);
                
            }

            GameEnd();
        }

    }
}
