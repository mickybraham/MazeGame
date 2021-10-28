using NUnit.Framework;
using MazeGame;

namespace MazeGameTesting
{
    public class Tests
    {
        bool MethodAnswer;
        bool ExpectedAnswer;
        [SetUp]
        public void Setup()
        {

        }
        //Boundary Tests - by checking one valid position and two invalid positions, based on x and y positions
        [Test]
        public void BoundaryTest1()
        {
            string[,] grid = LevelCompiler.CompileFileToArray("../../../TestLevel.txt");
            World testworld = new World(grid);
            MethodAnswer = testworld.isPositionValid(0, 0);
            ExpectedAnswer = true;
            Assert.AreEqual(ExpectedAnswer, MethodAnswer);
        }
        [Test]
        public void BoundaryTest2()
        {
            string[,] grid = LevelCompiler.CompileFileToArray("../../../TestLevel.txt");
            World testworld = new World(grid);
            MethodAnswer = testworld.isPositionValid(27, 1);
            ExpectedAnswer = false;
            Assert.AreEqual(ExpectedAnswer, MethodAnswer);
        }
        [Test]
        public void BoundaryTest3()
        {
            string[,] grid = LevelCompiler.CompileFileToArray("../../../TestLevel.txt");
            World testworld = new World(grid);
            MethodAnswer = testworld.isPositionValid(1, 13);
            ExpectedAnswer = false;
            Assert.AreEqual(ExpectedAnswer, MethodAnswer);
        }
        [Test]
        //Check validity of position - by checking if the character at a certain position is valid
        public void ValidityTest1()
        {
            string[,] grid = LevelCompiler.CompileFileToArray("../../../TestLevel.txt");
            World testworld = new World(grid);
            // (23,0) position is X and should therefore be valid
            MethodAnswer = testworld.isPositionValid(23, 0);
            ExpectedAnswer = true;
            Assert.AreEqual(ExpectedAnswer, MethodAnswer);
        }
        [Test]
        public void ValidityTest2()
        {
            string[,] grid = LevelCompiler.CompileFileToArray("../../../TestLevel.txt");
            World testworld = new World(grid);
            // (21,0) position is W and should therefore be invalid
            MethodAnswer = testworld.isPositionValid(21, 0);
            ExpectedAnswer = false;
            Assert.AreEqual(ExpectedAnswer, MethodAnswer);
        }
        [Test]
        public void ValidityTest3()
        {
            string[,] grid = LevelCompiler.CompileFileToArray("../../../TestLevel.txt");
            World testworld = new World(grid);
            // (1,0) position is B and should therefore be valid
            MethodAnswer = testworld.isPositionValid(1, 0);
            ExpectedAnswer = true;
            Assert.AreEqual(ExpectedAnswer, MethodAnswer);
        }
    }
}