using System;
using System.Text;
using System.Collections.Generic;
using AmericanBowlingGame.Frames;

namespace AmericanBowlingGame
{
    public class ScoreCalculator:IScoreCalculator
    {
        private List<int> _rolls;
        private List<IFrame> _frames;

        public ScoreCalculator()
        {
            _rolls = new List<int>();
            _frames = new List<IFrame>();
        }

        public ScoreCalculator(List<int> rolls)
        {
            _rolls = rolls;
            _frames = new List<IFrame>();
        }
        public void RollWithOpenFrame(int firstRollPin, int secondRollPin)
        {
            _frames.Add(new OpenFrame(_rolls, firstRollPin, secondRollPin));
        }

        public void RollWithSpareFrame(int firstRollPin, int secondRollPin)
        {
            _frames.Add(new SpareFrame(_rolls, firstRollPin, secondRollPin));
        }

        public void RollWithStrikeFrame()
        {
            _frames.Add(new StrikeFrame(_rolls));
        }

        public void BonusRoll(int pins)
        {
            _rolls.Add(pins);
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
