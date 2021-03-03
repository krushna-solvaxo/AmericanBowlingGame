using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmericanBowlingGame.Tests
{
    [TestFixture]
    public class GameTest
    {
        private Game _game;

        [SetUp]
        public void Setup()
        {
            _game = new Game();
        }

        [Test]
        public void Gutter_game_score_should_be_zero_test()
        {
            Roll(0, 20);
            Assert.AreEqual(0, _game.GetScore());
        }

        [Test]
        public void WhenAllRollWithOnePinDown()
        {
            Roll(1, 20);
            Assert.AreEqual(20, _game.GetScore());
        }

        [Test]
        public void WhenFirstTwoRollResultSpareFrame()
        {
            Roll(9, 1);
            Roll(1, 1);
            Roll(1, 18);
            Assert.AreEqual(29, _game.GetScore());
        }

        [Test]
        public void WhenFirstTwoRollResultStrikeFrame()
        {
            Roll(10, 1); // strike
            Roll(5, 1);
            Roll(3, 1);
            Roll(0, 16); // Roll 16 time with 0 pins drwaned
            Assert.AreEqual(26, _game.GetScore());
        }

        [Test]
        public void WhenLastFrameResultsIntoSpareFrame()
        {
            Roll(0, 18); // Roll 18 time with 0 pins drwaned
            Roll(4, 1);
            Roll(6, 1);

            //bonus roll
            Roll(5, 1);
            Assert.AreEqual(15, _game.GetScore());
        }

        [Test]
        public void WhenLastFrameResultsIntoStrikeFrame()
        {
            Roll(0, 18); // Roll 18 time with 0 pins drwaned
            Roll(10, 1);

            // Two bonus roll
            Roll(5, 1);
            Roll(3, 1);
            Assert.AreEqual(18, _game.GetScore());
        }

        [Test]
        public void WhenPerfectBowlingGame()
        {
            Roll(10, 10);

            //two bonus roll
            Roll(10, 1);
            Roll(10, 1);
            Assert.AreEqual(300, _game.GetScore());
        }

        [Test]
        public void WhenRollsWithAlternateStrikeAndSpareFrames()
        {
            Roll(10, 1);
            Roll(5, 2);
            Roll(10, 1);
            Roll(5, 2);
            Roll(10, 1);
            Roll(5, 2);
            Roll(10, 1);
            Roll(5, 2);
            Roll(10, 1);
            Roll(5, 2);
            // bonus roll
            Roll(10, 1);
            Assert.AreEqual(200, _game.GetScore());
        }
        [Test]
        public void WhenRandomRollsShouldReturnValidScore()
        {
            Roll(10, 1);
            Roll(9, 1);
            Roll(1, 1);
            Roll(5, 1);
            Roll(5, 1);
            Roll(7, 1);
            Roll(2, 1);
            Roll(10, 1);
            Roll(10, 1);
            Roll(10, 1);
            Roll(9, 1);
            Roll(0, 1);
            Roll(8, 1);
            Roll(2, 1);
            Roll(9, 1);
            Roll(1, 1);
            //bonus roll
            Roll(10, 1);
            Assert.AreEqual(187, _game.GetScore());
        }

        private void Roll(int pins, int times)
        {
            for (int i = 0; i < times; i++)
            {
                _game.Roll(pins);
            }
        }

    }
}
