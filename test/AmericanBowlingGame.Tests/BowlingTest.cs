using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmericanBowlingGame.Tests
{
    [TestFixture]
    public class BowlingTest
    {
        private BowlingGame _bowlingGame;

        [SetUp]
        public void Setup()
        {
            _bowlingGame = new BowlingGame();
        }

        [Test] 
        public void WhenRollGutterGame()
        {
            RollsWithMultipleOpenFrame(10, 0, 0);
            Assert.AreEqual(0, _bowlingGame.Score());
        }

        [Test]
        public void WhenAllRollWithOnePinDown()
        {
            RollsWithMultipleOpenFrame(10, 1, 1);
            Assert.AreEqual(20, _bowlingGame.Score());
        }

        [Test] 
        public void WhenRollWithFirstSpareFrame()
        {
            _bowlingGame.RollWithSpareFrame(4, 6);
            _bowlingGame.RollWithOpenFrame(3, 5);
            RollsWithMultipleOpenFrame(8, 0, 0);
            Assert.AreEqual(21, _bowlingGame.Score());
        }

        [Test]
        public void WhenRollWithSpareFrameWithDifferentPins()
        {
            _bowlingGame.RollWithSpareFrame(4, 6);
            _bowlingGame.RollWithOpenFrame(5, 3);
            RollsWithMultipleOpenFrame(8, 0, 0);
            Assert.AreEqual(23, _bowlingGame.Score());
        }

        [Test]
        public void WhenRollWithFirstStrikeFrame()
        {
            _bowlingGame.RollWithStrikeFrame();
            _bowlingGame.RollWithOpenFrame(5, 3);
            RollsWithMultipleOpenFrame(8, 0, 0);
            Assert.AreEqual(26, _bowlingGame.Score());
        }

        [Test]
        public void WhenRollWithFinalStrikeFrame()
        {
            RollsWithMultipleOpenFrame(9, 0, 0);
            _bowlingGame.RollWithStrikeFrame();
            _bowlingGame.BonusRoll(5);
            _bowlingGame.BonusRoll(3);
            Assert.AreEqual(18, _bowlingGame.Score()); 
        }

        [Test]
        public void WhenRollWithFinalSpareFrame()
        {
            RollsWithMultipleOpenFrame(9, 0, 0);
            _bowlingGame.RollWithSpareFrame(4, 6);
            _bowlingGame.BonusRoll(5);
            Assert.AreEqual(15, _bowlingGame.Score());
        }

        [Test]
        public void WhenPerfectBowlingGame()
        {
            for (int i = 0; i < 10; i++)
                _bowlingGame.RollWithStrikeFrame();
            _bowlingGame.BonusRoll(10);
            _bowlingGame.BonusRoll(10);
            Assert.AreEqual(300, _bowlingGame.Score());
        }

        [Test]
        public void WhenAlternateStrikeAndSpareFrames()
        {
            for (int i = 0; i < 5; i++)
            {
                _bowlingGame.RollWithStrikeFrame();
                _bowlingGame.RollWithSpareFrame(4, 6);
            }
            _bowlingGame.BonusRoll(10);
            Assert.AreEqual(200, _bowlingGame.Score());
        }

        [Test]
        public void WhenRandomFramesShouldReturnValidScore()
        {
            _bowlingGame.RollWithStrikeFrame();
            _bowlingGame.RollWithSpareFrame(9, 1);
            _bowlingGame.RollWithSpareFrame(5, 5);
            _bowlingGame.RollWithOpenFrame(7, 2);
            _bowlingGame.RollWithStrikeFrame();
            _bowlingGame.RollWithStrikeFrame();
            _bowlingGame.RollWithStrikeFrame();
            _bowlingGame.RollWithOpenFrame(9, 0);
            _bowlingGame.RollWithSpareFrame(8, 2);
            _bowlingGame.RollWithSpareFrame(9, 1);
            _bowlingGame.BonusRoll(10);
            Assert.AreEqual(187, _bowlingGame.Score());
        }

        #region private methods
        private void RollsWithMultipleOpenFrame(int frameCount, int firstRoll, int secondRoll)
        {
            for (int frame = 0; frame < frameCount; frame++)
            {
                _bowlingGame.RollWithOpenFrame(firstRoll, secondRoll);
            }
        }
        #endregion
    }
}
