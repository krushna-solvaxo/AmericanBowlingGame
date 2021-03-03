using System;
using System.Collections.Generic;
using System.Text;

namespace AmericanBowlingGame
{
    public interface IScoreCalculator
    {
        void RollWithOpenFrame(int firstRollPin, int secondRollPin);

        void RollWithSpareFrame(int firstRollPin, int secondRollPin);

        void RollWithStrikeFrame();

        void BonusRoll(int roll);

        int Score();
    }
}
