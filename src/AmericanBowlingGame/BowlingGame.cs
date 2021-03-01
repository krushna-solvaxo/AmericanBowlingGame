using System;
using System.Text;
using System.Collections.Generic;
using AmericanBowlingGame.Frames;

namespace AmericanBowlingGame
{
    public class BowlingGame
    {
        private List<int> _rolls;
        private List<IFrame> _frames;

        public BowlingGame()
        {
            _rolls = new List<int>();
            _frames = new List<IFrame>();
        }
        public void RollWithOpenFrame(int firstRoll, int secondRoll)
        {
            _frames.Add(new OpenFrame(_rolls, firstRoll, secondRoll));
        }

        public void RollWithSpareFrame(int firstRoll, int secondRoll)
        {
            _frames.Add(new SpareFrame(_rolls, firstRoll, secondRoll));
        }

        public void RollWithStrikeFrame()
        {
            _frames.Add(new StrikeFrame(_rolls));
        }

        public void BonusRoll(int roll)
        {
            _rolls.Add(roll);
        }

        public int Score()
        {
            int totalScore = 0;
            foreach(var frame in _frames)
            {
                totalScore = totalScore + frame.Score();
            }
            return totalScore;
        }
    }
}
