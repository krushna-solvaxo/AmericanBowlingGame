using System;
using System.Collections.Generic;
using System.Text;

namespace AmericanBowlingGame
{
    public class Game
    {
        private List<int> rolls;
        private IScoreCalculator _scoreCalculator;
        private readonly int _numberOfFrames =10;
        public Game()
        {
            rolls = new List<int>();
        }

        public void Roll(int pins)
        {
            rolls.Add(pins);
        }

        public int GetScore()
        {
            _scoreCalculator = new ScoreCalculator();
            int frameIndex = 0;
            for (int frame = 0; frame < _numberOfFrames; frame++)
            {
                if (isSpare(frameIndex))
                {
                    _scoreCalculator.RollWithSpareFrame(rolls[frameIndex], rolls[frameIndex + 1]);
                    frameIndex += 2;
                }
                else if (isStrike(frameIndex))
                {
                    _scoreCalculator.RollWithStrikeFrame();
                    frameIndex++;
                }
                else
                {
                    _scoreCalculator.RollWithOpenFrame(rolls[frameIndex], rolls[frameIndex + 1]);
                    frameIndex += 2;
                }
            }

            // check if last frame is strik or spare by 
            if (isStrike(frameIndex - 1))
            {
                _scoreCalculator.BonusRoll(rolls[frameIndex]);
                _scoreCalculator.BonusRoll(rolls[frameIndex+1]);
            }
            else if(isSpare(frameIndex - 2)) {
                _scoreCalculator.BonusRoll(rolls[frameIndex]);
            }
            return _scoreCalculator.Score();
        }

        #region private methods
        private bool isSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        }

        private bool isStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10;
        }
        #endregion
    }
}
