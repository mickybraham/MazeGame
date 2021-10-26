using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;


namespace MazeGame
{
    public class Game
    {
        private Player NewPlayer;
        public int x;
        int coins;

        //create lists
        List<World> worlds = new List<World>();
        List<Challenge> challenges = new List<Challenge>();

        public void Start()
        {
            //Create grids
            string[,] grid = LevelCompiler.CompileFileToArray("../../../level1.txt");
            string[,] grid2 = LevelCompiler.CompileFileToArray("../../../level2.txt");
            string[,] grid3 = LevelCompiler.CompileFileToArray("../../../level3.txt");
            //string[,] grid4 = LevelCompiler.CompileFileToArray("level4.txt");

            //Create Player
            NewPlayer = new Player(2, 0); 
            //x = 2;

            //Create Worlds
            World world1 = new World(grid);
            World world2 = new World(grid2);
            World world3 = new World(grid3);
            //World world4 = new World(grid4);

            //Add Worlds to List
            worlds.Add(world1);
            worlds.Add(world2);
            worlds.Add(world3);
            //worlds.Add(world4);

            var random = new Random();
            this.x = random.Next(worlds.Count);

            //Create challenge objects 
            Challenge C1 = new Challenge("How many prime numbers are there between 0 & 50", "15");
            Challenge C2 = new Challenge("If 7 becomes 13 and 11 becomes 21, what does 16 become?", "31");
            Challenge C3 = new Challenge("What is next in this sequence: 2, 5, 9, 14", "20");
            Challenge C4 = new Challenge("How many sides does an decagon have", "10");

            //Add challenges to list
            challenges.Add(C1);
            challenges.Add(C2);
            challenges.Add(C3);
            challenges.Add(C4);
            runGame();
        }
        private void Instructions()
        {
            Console.WriteLine("Welcome to Michael's Maze game");
            Console.WriteLine("\n\nInstructions:\n\n");
            Console.WriteLine("1. Use the arrows keys to navigate the maze\n");
            Console.WriteLine("2. Take on Challenges and explore by navigating to letters marked on the map\n");
            Console.WriteLine("3. You will receive gold for successfully answering a challenge\n");
            Console.WriteLine("4. If you answer incorrectly be prepared to lose your gold\n");
            Console.WriteLine("5. To finish the game find E\n");
            Console.WriteLine("6. The aim of the game is to finish with as much gold as possible\n");
            Console.WriteLine("7. To restart the game press R\n");
        }
        private void Login()
        {
            Console.WriteLine("Please Login below to start:\n\n");
            Console.WriteLine("To start enter name:");
            string UserName = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            string password = Console.ReadLine();
            coins = NewPlayer.GetCoinValue();
        }

        private void GameEnd()
        {
            Clear();
            Console.WriteLine("You have exited the maze");
            Console.WriteLine($"You managed to collect {NewPlayer.GetCoinValue()} gold, Well done.");
            Console.WriteLine("Press Y to play again, N to exit");
            string yn = Console.ReadLine();
            if (yn == "Y")
            {
                Start();
            }
 
            ReadKey(true);
        }

        private void DrawFrame()
        {
            Clear();
            worlds[x].Draw();
            NewPlayer.Draw();
        }
        private void HandleInput()
        {
            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            switch(key)
            {
                case ConsoleKey.UpArrow:
                    if (worlds[x].isPositionValid(NewPlayer.X, NewPlayer.Y - 1))
                    {
                        NewPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (worlds[x].isPositionValid(NewPlayer.X, NewPlayer.Y + 1))
                    {
                        NewPlayer.Y += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (worlds[x].isPositionValid(NewPlayer.X - 1, NewPlayer.Y))
                    {
                        NewPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (worlds[x].isPositionValid(NewPlayer.X + 1, NewPlayer.Y))
                    {
                        NewPlayer.X += 1;
                    }
                    break;
                case ConsoleKey.R:
                    Clear();
                    Start();
                    break;
                default:
                    break;
            }
        }

        public void DisplayChallenge()
        {
            //Ask Challenge Question and take userinput
            Console.WriteLine(challenges[0].GetQuestion());
            string useranswer = Console.ReadLine();
            if (challenges[0].GetAnswer() == useranswer)
            {
                Console.WriteLine("Congratulations, you have earned 50 gold");
                NewPlayer.AddGold();
                Console.WriteLine($"You have {NewPlayer.GetCoinValue()} Gold");
                challenges.RemoveAt(0);
                
            }
            else
            {
                Console.WriteLine("Wrong answer, you lose 25 gold");
                NewPlayer.RemoveGold();
                Console.WriteLine($"You have {NewPlayer.GetCoinValue()} Gold");
                challenges.RemoveAt(0);
                
            }
        }
        private void runGame()
        {
            Instructions();
            Login();

            while (true)
            {
                // Draw Everything
                DrawFrame();

                //Check for player input from keyboard and move player
                HandleInput();

                //check if player has reached milestones
                string elementAtPlayerPos = worlds[x].GetElementAt(NewPlayer.X, NewPlayer.Y);

                //When player reaches X 
                if (elementAtPlayerPos == "X" && (challenges.Count == 2 || challenges.Count == 0))
                {
                    x = x + 1;
                    NewPlayer.ResetCursor(1, 0);
                }
                if (elementAtPlayerPos == "X" && challenges.Count >= 3)
                {
                    NewPlayer.ResetCursor(0, 21);
                    Console.WriteLine("You must complete more challenges to pass please explore further");
                    System.Threading.Thread.Sleep(6000);
                    if (x == 0)
                    {
                        NewPlayer.ResetCursor(44, 19);
                    }
                    if (x == 1)
                    {
                        NewPlayer.ResetCursor(44, 8);
                    }

                }
                //When player reaches E
                if (elementAtPlayerPos == "E" && challenges.Count == 0)
                {
                    break;
                }
                if (elementAtPlayerPos == "E" && challenges.Count > 0)
                {
                    NewPlayer.ResetCursor(0, 21);
                    Console.WriteLine("You must complete more challenges to pass please explore further");
                    System.Threading.Thread.Sleep(6000);
                    NewPlayer.ResetCursor(44, 20);
                }

                //When player reaches B
                if (elementAtPlayerPos == "B")
                {
                    x = x - 1;
                    if (x == 0)
                    {
                        NewPlayer.ResetCursor(44, 19);
                    }
                    if (x == 1)
                    {
                        NewPlayer.ResetCursor(44, 8);
                    }
                }

                //When player reaches C
                if (elementAtPlayerPos == "C")
                {
                    NewPlayer.ResetCursor(0, 21);
                    DisplayChallenge();
                    System.Threading.Thread.Sleep(600);
                    worlds[x].Grid[19,10] = " ";
                    NewPlayer.ResetCursor(9, 19);
                }

                //When player reaches D
                if (elementAtPlayerPos == "D")
                {
                    NewPlayer.ResetCursor(0, 21);
                    DisplayChallenge();
                    System.Threading.Thread.Sleep(600);
                    worlds[x].Grid[1, 43] = " ";
                    NewPlayer.ResetCursor(42, 1);
                }

                //When player reaches F
                if (elementAtPlayerPos == "F")
                {
                    NewPlayer.ResetCursor(0, 22);
                    DisplayChallenge();
                    System.Threading.Thread.Sleep(600);
                    worlds[x].Grid[7, 44] = " ";
                    NewPlayer.ResetCursor(44, 7);
                }

                //When player reaches G
                if (elementAtPlayerPos == "G")
                {
                    NewPlayer.ResetCursor(0, 22);
                    DisplayChallenge();
                    System.Threading.Thread.Sleep(600);
                    worlds[x].Grid[19, 5] = " ";
                    NewPlayer.ResetCursor(5, 19);
                }
                //Give the console a chance to render
                System.Threading.Thread.Sleep(5);
                
            }
            GameEnd();
        }

    }
}
