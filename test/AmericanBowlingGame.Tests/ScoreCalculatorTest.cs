using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmericanBowlingGame.Tests
{
    [TestFixture]
    public class ScoreCalulatorTest
    {
        private ScoreCalculator _scoreCalculator;

        [SetUp]
        public void Setup()
        {
            _scoreCalculator = new ScoreCalculator();
        }

        [Test] 
        public void WhenRollGutterGame()
        {
            RollsWithMultipleOpenFrame(10, 0, 0);
            Assert.AreEqual(0, _scoreCalculator.Score());
        }

        [Test]
        public void WhenAllRollWithOnePinDown()
        {
            RollsWithMultipleOpenFrame(10, 1, 1);
            Assert.AreEqual(20, _scoreCalculator.Score());
        }

        [Test] 
        public void WhenRollWithFirstSpareFrame()
        {
            _scoreCalculator.RollWithSpareFrame(4, 6);
            _scoreCalculator.RollWithOpenFrame(3, 5);
            RollsWithMultipleOpenFrame(8, 0, 0);
            Assert.AreEqual(21, _scoreCalculator.Score());
        }

        [Test]
        public void WhenRollWithSpareFrameWithDifferentPins()
        {
            _scoreCalculator.RollWithSpareFrame(4, 6);
            _scoreCalculator.RollWithOpenFrame(5, 3);
            RollsWithMultipleOpenFrame(8, 0, 0);
            Assert.AreEqual(23, _scoreCalculator.Score());
        }

        [Test]
        public void WhenRollWithFirstStrikeFrame()
        {
            _scoreCalculator.RollWithStrikeFrame();
            _scoreCalculator.RollWithOpenFrame(5, 3);
            RollsWithMultipleOpenFrame(8, 0, 0);
            Assert.AreEqual(26, _scoreCalculator.Score());
        }

        [Test]
        public void WhenRollWithFinalStrikeFrame()
        {
            RollsWithMultipleOpenFrame(9, 0, 0);
            _scoreCalculator.RollWithStrikeFrame();
            _scoreCalculator.BonusRoll(5);
            _scoreCalculator.BonusRoll(3);
            Assert.AreEqual(18, _scoreCalculator.Score()); 
        }

        [Test]
        public void WhenRollWithFinalSpareFrame()
        {
            RollsWithMultipleOpenFrame(9, 0, 0);
            _scoreCalculator.RollWithSpareFrame(4, 6);
            _scoreCalculator.BonusRoll(5);
            Assert.AreEqual(15, _scoreCalculator.Score());
        }

        [Test]
        public void WhenPerfectBowlingGame()
        {
            for (int i = 0; i < 10; i++)
                _scoreCalculator.RollWithStrikeFrame();
            _scoreCalculator.BonusRoll(10);
            _scoreCalculator.BonusRoll(10);
            Assert.AreEqual(300, _scoreCalculator.Score());
        }

        [Test]
        public void WhenAlternateStrikeAndSpareFrames()
        {
            for (int i = 0; i < 5; i++)
            {
                _scoreCalculator.RollWithStrikeFrame();
                _scoreCalculator.RollWithSpareFrame(4, 6);
            }
            _scoreCalculator.BonusRoll(10);
            Assert.AreEqual(200, _scoreCalculator.Score());
        }

        [Test]
        public void WhenRandomFramesShouldReturnValidScore()
        {
            _scoreCalculator.RollWithStrikeFrame();
            _scoreCalculator.RollWithSpareFrame(9, 1);
            _scoreCalculator.RollWithSpareFrame(5, 5);
            _scoreCalculator.RollWithOpenFrame(7, 2);
            _scoreCalculator.RollWithStrikeFrame();
            _scoreCalculator.RollWithStrikeFrame();
            _scoreCalculator.RollWithStrikeFrame();
            _scoreCalculator.RollWithOpenFrame(9, 0);
            _scoreCalculator.RollWithSpareFrame(8, 2);
            _scoreCalculator.RollWithSpareFrame(9, 1);
            _scoreCalculator.BonusRoll(10);
            Assert.AreEqual(187, _scoreCalculator.Score());
        }

        #region private methods
        private void RollsWithMultipleOpenFrame(int frameCount, int firstRoll, int secondRoll)
        {
            for (int frame = 0; frame < frameCount; frame++)
            {
                _scoreCalculator.RollWithOpenFrame(firstRoll, secondRoll);
            }
        }
        #endregion
    }
}
