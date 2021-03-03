using System;
using System.Collections.Generic;
using System.Text;

namespace AmericanBowlingGame.Frames
{
    public class OpenFrame:Frame
    {
        public OpenFrame(List<int> rolls, int firstRoll, int secondRoll):base(rolls)
        {
            rolls.Add(firstRoll);
            rolls.Add(secondRoll);
        }

        public override int Score()
        {
            return Rolls[StartingRoll] + Rolls[StartingRoll + 1];
        }

        override public int FrameSize()
        {
            return 2;
        }
    }
}
