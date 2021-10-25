using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MazeGame;

namespace MazeGameTesting
{
    public class GameMechanicsTests
    {
        string MethodAnswer;
        string ExpectedAnswer;

        [Test]

        public void RemoveChallengeTest()
        {
            string[,] grid = LevelCompiler.CompileFileToArray("C:/Users/micky/source/repos/MazeGame/MazeGameTesting/TestLevel.txt");
            World testworld = new World(grid);
            testworld.Grid[3, 0] = " ";
            MethodAnswer = testworld.GetElementAt(0, 3);
            ExpectedAnswer = " ";
            Assert.AreEqual(MethodAnswer, ExpectedAnswer);

        }
        [Test]
        //public void ResetCursorTest()
        //{
        //    string[,] grid = LevelCompiler.CompileFileToArray("C:/Users/micky/source/repos/MazeGame/MazeGameTesting/TestLevel.txt");
        //    World testworld = new World(grid);
        //    Player TestPlayer = new Player(0, 0);
        //    Game TestGame = new Game();
        //    TestGame.Start();
        //    TestPlayer.ResetCursor(0, 1);
        //    MethodAnswer = testworld.GetElementAt(0, 1);
        //    ExpectedAnswer = TestPlayer.GetPlayerCharacter();
        //    Assert.AreEqual(MethodAnswer, ExpectedAnswer);

        //}


    }
}
