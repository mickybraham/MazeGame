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
            Player TestPlayer = new Player(0, 0);
            MethodAnswer = TestPlayer.GetCoinValue();
            ExpectedAnswer = 0;
            Assert.AreEqual(ExpectedAnswer, MethodAnswer);
        }
        [Test]
        public void TestAddGold()
        {
            Player TestPlayer = new Player(0, 0);
            MethodAnswer = TestPlayer.AddGold();
            ExpectedAnswer = 50;
            Assert.AreEqual(ExpectedAnswer, MethodAnswer);
        }
        [Test]
        public void TestRemoveGold()
        {
            Player TestPlayer = new Player(0, 0);
            MethodAnswer = TestPlayer.RemoveGold();
            ExpectedAnswer = -25;
            Assert.AreEqual(ExpectedAnswer, MethodAnswer);
        }
    }
}
