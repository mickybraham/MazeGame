using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MazeGame;

namespace MazeGameTesting
{
    public class WealthCalculationsTests
    {
        int MethodAnswer;
        int ExpectedAnswer;
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestInitialValue()
        {
            string[,] grid = LevelCompiler.CompileFileToArray("C:/Users/micky/source/repos/MazeGame/MazeGameTesting/TestLevel.txt");
            World testworld = new World(grid);
            Player TestPlayer = new Player(0, 0);
            TestPlayer.Draw();
            MethodAnswer = TestPlayer.GetCoinValue();
            ExpectedAnswer = 0;
            Assert.AreEqual(ExpectedAnswer, MethodAnswer);
        }
        [Test]
        public void TestAddGold()
        {
            string[,] grid = LevelCompiler.CompileFileToArray("C:/Users/micky/source/repos/MazeGame/MazeGameTesting/TestLevel.txt");
            World testworld = new World(grid);
            Player TestPlayer = new Player(0, 0);
            TestPlayer.Draw();
            MethodAnswer = TestPlayer.AddGold();
            ExpectedAnswer = 50;
            Assert.AreEqual(ExpectedAnswer, MethodAnswer);
        }
        [Test]
        public void TestRemoveGold()
        {
            string[,] grid = LevelCompiler.CompileFileToArray("C:/Users/micky/source/repos/MazeGame/MazeGameTesting/TestLevel.txt");
            World testworld = new World(grid);
            Player TestPlayer = new Player(0, 0);
            TestPlayer.Draw();
            MethodAnswer = TestPlayer.RemoveGold();
            ExpectedAnswer = -25;
            Assert.AreEqual(ExpectedAnswer, MethodAnswer);
        }
    }
}
