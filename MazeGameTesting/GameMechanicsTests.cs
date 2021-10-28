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
        int IntMethodAnswer;
        int IntExpectedAnswer;

        [Test]

        public void RemoveChallengeTest()
        {
            string[,] grid = LevelCompiler.CompileFileToArray("../../../TestLevel.txt");
            World testworld = new World(grid);
            testworld.Grid[3, 0] = " ";
            MethodAnswer = testworld.GetElementAt(0, 3);
            ExpectedAnswer = " ";
            Assert.AreEqual(MethodAnswer, ExpectedAnswer);

        }
        [Test]
        public void TestChallengeCounter()
        {
            string[,] grid = LevelCompiler.CompileFileToArray("../../../TestLevel.txt");
            World testworld = new World(grid);
            IntMethodAnswer = testworld.ChallengesInRoom();
            IntExpectedAnswer = 11;
            Assert.AreEqual(IntMethodAnswer, IntExpectedAnswer);
        }



    }
}
